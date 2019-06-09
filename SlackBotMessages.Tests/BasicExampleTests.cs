using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlackBotMessages.Tests
{
    [TestClass]
    public class BasicExampleTests
    {
        [TestMethod]
        public void Send_Message_Success()
        {
            //Registering for your WebHook Url with Slack
            //https://my.slack.com/services/new/incoming-webhook/

            //-Sign in to Slack
            //    - Choose a channel to post to
            //    - Then click on the green button Add Incoming WebHooks integration
            //    - You will be given a WebHook Url.Keep this private. Use it when you set up the SBMClient.See example below.

            // Usage example
            // This will send a message to the slack channel with the message, username and emoji of your choice 

            var client = new SBMClient("https://hooks.slack.com/services/Your/WebHook/Url");
            var msg = new Message("Hello World", "general", "codeshare.co.uk", ":poop:");
            var response = client.Send(msg);
            Assert.AreEqual("ok", response);
        }
    }
}
