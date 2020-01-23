using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace QnAMakerRuntimeAPI.Providers
{
    public class QnAGateway : IQnAGateway
    {
        private IConfiguration _configuration;
        public QnAGateway(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<QnASearchResultList> AnswerQuestion(string question, string userId, int resultCount = 1)
        {
            //From QnA Knowledgebase - embedded GUID in POST portion
            var runtimeKB = _configuration["QNA_KB_ID"];
            //From QnA Knowledgebase - HOST
            var runtimeEndpoint = _configuration["QNA_RuntimeEndpoint"];
            //From QnA Knowledgebase - Authorization Endpoint Key
            var runtimeKey = _configuration["QNA_RuntimeKey"];

            var runtimeCreds = new EndpointKeyServiceClientCredentials(runtimeKey);

            //Runtime client for asking questions
            using (QnAMakerRuntimeClient rtClient = new QnAMakerRuntimeClient(runtimeCreds) { 
                RuntimeEndpoint = runtimeEndpoint 
            })
            {
                QueryDTO query = new QueryDTO()
                {
                    Question = question, //The text of the question
                    ScoreThreshold = 0.55, //The minimum relevance score to accept
                    Top = resultCount //How many answers to return, maximum
                };

               return await rtClient.Runtime.GenerateAnswerAsync(runtimeKB, query).ConfigureAwait(false);

            }

        }

    }

}
