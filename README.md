# qnamaker-wpf
This is a sample of a minimal WPF UI connecting to Azure QnA Maker's GenerateAnswer api to run queries against a QnA Maker knowledge base.

## To Use
1. Create your own Azure QnA Maker service and upload some documents. Get started at https://www.qnamaker.ai/
2. After downloading this repo, open appsettings.json and add your own endpoint, key, and knowledgebase id, which you can get from the KB settings in the QnA Maker portal.
3. You will need tools for .NET core. This project was developed with Visual Studio 2019, and currently targets .NET 3.1.
4. This POC will show a link to open the corresponding document that the answer came from. If you want that functionality, place your documents somewhere accessible to the running app and put that path in the appsettings.json "HelpDocumentsPath" setting.

If you are not looking for a WPF solution particularly, there is an easy out-of-the-box [Azure Bot Service UI](https://docs.microsoft.com/en-us/azure/cognitive-services/qnamaker/quickstarts/create-publish-knowledge-base#create-a-bot") that you can configure with QnA Maker.
