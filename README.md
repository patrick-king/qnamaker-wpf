# qnamaker-wpf
This is a sample of a minimal WPF UI connecting to Azure QnA Maker's GenerateAnswer api to run queries against a QnA Maker knowledge base.

#To Use
1. Create your own QnA Maker service. Get started at https://www.qnamaker.ai/
2. Open appsettings.json and add your own endpoint, key, and knowledgebase id, which you can get from the KB in the QnA Maker portal.
3. This POC will show a link to open the corresponding document that the answer came from. If you want that functionality, place your documents somewhere accessible to the running app and put that path in the appsettings.json "HelpDocumentsPath" setting.
