# qnamaker-wpf
This is a sample of a minimal WPF UI connecting to Azure Language Services' Custom Question Answering GetAnswer api to run queries against a knowledge base built from your own documents and urls.

## To Use
1. Create your own Azure Language service, configure it for Custom Question Answering and upload some documents. Get started at https://azure.microsoft.com/en-us/products/cognitive-services/question-answering/
2. After downloading this repo, open appsettings.json or your client secrets file and add your own endpoint, key, and project name, which you can get from the KB deployment settings in the Azure Language Studio web portal. 
3. You will need tools for .NET core. This project was developed with Visual Studio 2022, and currently targets .NET 6.
4. This POC will show a link to open the corresponding document that the answer came from. If you want that functionality, place your documents somewhere accessible to the running app and put that path in the appsettings.json "HelpDocumentsPath" setting.

If you are not looking for a WPF solution in particular, there is an easy out-of-the-box Azure Bot Service UI that you can configure with custom question answering. You can use it from most any app platform since there are both SDK's and a langugage-agnostic REST API.
