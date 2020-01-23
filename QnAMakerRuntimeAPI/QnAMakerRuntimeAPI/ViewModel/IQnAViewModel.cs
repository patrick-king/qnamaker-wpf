using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QnAMakerRuntimeAPI.ViewModel
{
    public interface IQnAViewModel
    {
        ICommand SubmitQuestionCommand { get; set; }
        string QuestionText { get; set; }
        ObservableCollection<HelpResultItem> SearchResults { get; set; }
       

    }
}