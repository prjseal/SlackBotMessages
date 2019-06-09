using System;
using System.IO;
using System.Net;
using System.Text;

namespace SlackBotMessages
{
    /// <summary>
    /// Sends you slack bot messages using web hooks
    /// </summary>
    public class SBMClient
    {
        public string WebHookUrl { get; set; }

        public SBMClient(string webHookUrl)
        {
            WebHookUrl = webHookUrl;
        }

        /// <summary>
        /// Calls the process request method with your message data
        /// </summary>
        /// <param name="message">The message you would like to send to slack</param>
        /// <returns>The response from the server</returns>
        public string Send(Message message)
        {
            return ProcessRequest(WebHookUrl, PreparePostData(message));
        }

        /// <summary>
        /// Gets the JSON data from the message and puts it into a payload parameter
        /// </summary>
        /// <param name="message">The message you would like to send to slack</param>
        /// <returns>A string for the payload containing the slack message</returns>
        private string PreparePostData(Message message)
        {
            StringBuilder postData = new StringBuilder();
            postData.Append("payload={");

            if (!String.IsNullOrEmpty(message.Text))
            {
                postData.Append("\"text\":\"" + message.Text + "\"");
            }

            if (!String.IsNullOrEmpty(message.Channel))
            {
                postData.Append(",\"channel\":\"" + message.Channel + "\"");
            }

            if (!String.IsNullOrEmpty(message.Icon_Emoji))
            {
                postData.Append(",\"icon_emoji\":\"" + message.Icon_Emoji + "\"");
            }

            if (!String.IsNullOrEmpty(message.UserName))
            {
                postData.Append(",\"username\": \"" + message.UserName + "\"");
            }

            postData.Append("}");
            return postData.ToString();
        }

        /// <summary>
        /// Calls a web request using the webhook url and the data from the message
        /// </summary>
        /// <param name="webhookUrl">The webhook url to send the message to</param>
        /// <param name="sbPostData">A string for the payload containing the slack message</param>
        /// <returns>The response from the server</returns>
        private string ProcessRequest(string webhookUrl, string sbPostData)
        {
            WebRequest request = WebRequest.Create(webhookUrl);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(sbPostData.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
