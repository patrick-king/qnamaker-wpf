﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
using QnAMakerRuntimeAPI.UICore;
using QnAMakerRuntimeAPI.Providers;
using Azure.AI.Language.QuestionAnswering;
using Azure;
using System.IO;

namespace QnAMakerRuntimeAPI.ViewModel
{
	public class QnAViewModel : ViewModelBase, IQnAViewModel
	{
        private IConfiguration _config;
		private string _localDocsLib;
		public QnAViewModel(IConfiguration config)
		{
            _config = config;
            SearchResults = new ObservableCollection<HelpResultItem>();

            SubmitQuestionCommand = new RelayCommand(GetHelpResults_Execute, GetHelpResults_CanExecute);

			_localDocsLib = _config["HelpDocumentsPath"];
		}

		private string mQuestionText;
		public string QuestionText
		{
			get { return mQuestionText; }
			set
			{
				if (mQuestionText != value)
				{
					mQuestionText = value;
					RaisePropertyChanged(nameof(QuestionText));
                    CommandManager.InvalidateRequerySuggested();
				}
			}
		}


		private string mSourceDocumentURL;
		public string SourceDocumentURL
		{
			get { return mSourceDocumentURL; }
			set
			{
				if (mSourceDocumentURL != value)
				{
					mSourceDocumentURL = value;
					RaisePropertyChanged(nameof(SourceDocumentURL));
				}
			}
		}


		private string mAnswerText;
		public string AnswerText
		{
			get { return mAnswerText; }
			set
			{
				if (mAnswerText != value)
				{
					mAnswerText = value;
					RaisePropertyChanged(nameof(AnswerText));
				}
			}
		}


		private ObservableCollection<HelpResultItem> mSearchResults;
		public ObservableCollection<HelpResultItem> SearchResults
		{
			get { return mSearchResults; }
			set
			{
				if (mSearchResults != value)
				{
					mSearchResults = value;
					RaisePropertyChanged(nameof(SearchResults));
				}
			}
		}


        #region  SubmitQuestionCommand             

        private ICommand mSubmitQuestionCommand;
		public ICommand SubmitQuestionCommand
        {
			get { return mSubmitQuestionCommand; }
			set
			{
				if (mSubmitQuestionCommand != value)
				{
					mSubmitQuestionCommand = value;
					RaisePropertyChanged(nameof(SubmitQuestionCommand));
				}
			}
		}

        

        public bool GetHelpResults_CanExecute()
		{
            return true;
		}

		public void GetHelpResults_Execute()
		{
            if (string.IsNullOrEmpty(QuestionText))
            {
                return;
            }

            //Call service to get results
            Cursor oldCursor = Mouse.OverrideCursor;
            try
            {
                SearchResults.Clear();
                
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                IQnAGateway qnag = new QnAGateway(_config);

				
                Task<AnswersResult> searchTask = Task.Run(() => qnag.AnswerQuestion(QuestionText, "user1", 5 ));
                AnswersResult results = searchTask.Result;

                var answerResults = new List<HelpResultItem>();
                foreach (var answer in results.Answers)
                {
					var theResult = new HelpResultItem()
					{
						MatchedText = answer.Answer,
						RelevancyScore = answer.Confidence.GetValueOrDefault() * 100,
						SourceDocumentURL = answer.Source,
						LocalDocumentURL = (_localDocsLib != null && answer.Source != null) ? Path.Combine(_localDocsLib, answer.Source) : null
                    };
                    answerResults.Add(theResult);
                }

                SearchResults = new ObservableCollection<HelpResultItem>(answerResults);
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                Mouse.OverrideCursor = oldCursor;
            }

        }
		#endregion


	}
}
