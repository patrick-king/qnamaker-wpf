using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Interop;
using QnAMakerRuntimeAPI.UICore;

namespace QnAMakerRuntimeAPI.ViewModel
{
    public class HelpResultItem : ViewModelBase
    {

        public HelpResultItem()
        {

          
            ViewDocumentCommand = new RelayCommand(ViewDocument_Execute, ViewDocument_CanExecute);
        }
        

        private string mMatchedText;
        public string MatchedText
        {
            get { return mMatchedText; }
            set
            {
                if (mMatchedText != value)
                {
                    mMatchedText = value;
                    RaisePropertyChanged(nameof(MatchedText));
                }
            }
        }


        private double mRelevancyScore;
        public double RelevancyScore
        {
            get { return mRelevancyScore; }
            set
            {
                if (mRelevancyScore != value)
                {
                    mRelevancyScore = value;
                    RaisePropertyChanged(nameof(RelevancyScore));
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


        private string mLocalDocumentURL;
        public string LocalDocumentURL
        {
            get { return mLocalDocumentURL; }
            set
            {
                if (mLocalDocumentURL != value)
                {
                    mLocalDocumentURL = value;
                    RaisePropertyChanged(nameof(LocalDocumentURL));
                }
            }
        }


        #region  ViewDocumentCommand             

        private ICommand mViewDocumentCommand;
        public ICommand ViewDocumentCommand
        {
            get { return mViewDocumentCommand; }
            set
            {
                if (mViewDocumentCommand != value)
                {
                    mViewDocumentCommand = value;
                    RaisePropertyChanged(nameof(ViewDocumentCommand));
                }
            }
        }


        public bool ViewDocument_CanExecute()
        {
            return !string.IsNullOrEmpty(LocalDocumentURL);
        }

        public void ViewDocument_Execute()
        {
            //send to shell to open
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = LocalDocumentURL;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
        #endregion


    }
}