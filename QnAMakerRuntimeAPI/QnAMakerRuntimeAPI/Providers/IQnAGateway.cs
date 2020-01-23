using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System.Threading.Tasks;

namespace QnAMakerRuntimeAPI.Providers
{
    public interface IQnAGateway
    {
        Task<QnASearchResultList> AnswerQuestion(string question, string userId = "user1", int resultCount = 1);
    }
}