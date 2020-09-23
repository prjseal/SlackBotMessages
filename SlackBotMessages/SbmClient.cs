using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlackBotMessages.Models;

namespace SlackBotMessages
{
    public class SbmClient : ISbmClient
    {
        /// <summary>
        ///     The http client used for posting the data to the slack web hook.
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        ///     Create the Slack Bot Messages client and set the web hook url.
        /// </summary>
        /// <param name="webHookUrl"></param>
        public SbmClient(string webHookUrl)
        {
            _client = new HttpClient();
            WebHookUrl = webHookUrl;
        }
        
        public SbmClient(HttpClient client, string webHookUrl)
        {
            _client = client;
            WebHookUrl = webHookUrl;
        }

        /// <summary>
        ///     The web hook url to send the message to
        /// </summary>
        private string WebHookUrl { get; }
        
        /// <summary>
        ///     Calls the process request method with your message data
        /// </summary>
        /// <param name="message">The message you would like to send to slack</param>
        /// <returns>The response body from the server</returns>
        public Task<string> Send(Message message)
        {
            var requestBody = JsonConvert.SerializeObject(message);
            return ProcessRequest(WebHookUrl, requestBody);
        }

        /// <summary>
        ///     Calls the ProcessRequestAsync method with your message data
        /// </summary>
        /// <param name="message">The message you would like to send to slack</param>
        /// <returns>The response body from the server</returns>
        public Task<string> SendAsync(Message message)
        {
            var requestBody = JsonConvert.SerializeObject(message);
            return ProcessRequestAsync(WebHookUrl, requestBody);
        }

        /// <summary>
        ///     The method used to send the message data to the slack web hook
        /// </summary>
        /// <param name="webHookUrl">The web hook url to send the message to</param>
        /// <param name="requestBody">The message model in json format</param>
        /// <returns></returns>
        private async Task<string> ProcessRequest(string webHookUrl, string requestBody)
        {
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri(webHookUrl);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    var response = _client.SendAsync(request).Result;
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "Error when posting to the web hook url. Error Message: " + ex.Message;
            }
        }

        /// <summary>
        ///     The method used to send the message data to the slack web hook, using ConfigureAwait(false)
        /// </summary>
        /// <param name="webHookUrl">The web hook url to send the message to</param>
        /// <param name="requestBody">The message model in json format</param>
        /// <returns></returns>
        private async Task<string> ProcessRequestAsync(string webHookUrl, string requestBody)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(webHookUrl)))
                using (var content = new StringContent(requestBody, Encoding.UTF8, "application/json"))
                {
                    request.Content = content;
                    using (var response = await _client.SendAsync(request).ConfigureAwait(false))
                        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                return "Error when posting to the web hook url. Error Message: " + ex.Message;
            }
        }
    }
}