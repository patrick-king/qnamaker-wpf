using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using Azure.AI.Language.QuestionAnswering;
using Azure.Core;
using Azure;

namespace QnAMakerRuntimeAPI.Providers
{
    public class QnAGateway : IQnAGateway
    {
        private IConfiguration _configuration;
        public QnAGateway(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<AnswersResult> AnswerQuestion(string question, string userId, int resultCount = 1)
        {
            //From the Deploy Knowledge Base page in Language Studio - Prediction URL, but drop everything after azure.com becuase 
            //the SDK will supply those settings. Your url should look like this when using the SDK: https://<My Language Service>.cognitiveservices.azure.com"
            var runtimeEndpoint = new Uri(_configuration["QuestionAnswering.Endpoint"]);
            //From Azure Portal Language resource - Keys and Endpoint, pick one of the keys.
            var runtimeKey = _configuration["QuestionAnswering.APIKey"];
            //From the Deploy Knowledge Base page in Language Studio (Can extract projectName and DeploymentName from the example Prediction URL)
            string projectName = _configuration["QuestionAnswering.ProjectName"];
            string deploymentName = _configuration["QuestionAnswering.DeploymentName"];

            var runtimeCreds = new AzureKeyCredential(runtimeKey);

            //Runtime client for asking questions
            QuestionAnsweringClient rtClient = new QuestionAnsweringClient(runtimeEndpoint,runtimeCreds);

            AnswersOptions options = new AnswersOptions()
            {
                ConfidenceThreshold = 0.39,//The minimum relevance score to accept
                Size = resultCount//How many answers to return, maximum
            };
              
          
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);

         
            return await rtClient.GetAnswersAsync(question, project, options);
         

        }

    }

}
