using Azure.AI.Language.QuestionAnswering;
using System.Threading.Tasks;

namespace QnAMakerRuntimeAPI.Providers
{
    public interface IQnAGateway
    {
        Task<AnswersResult> AnswerQuestion(string question, string userId = "user1", int resultCount = 1);
    }
}