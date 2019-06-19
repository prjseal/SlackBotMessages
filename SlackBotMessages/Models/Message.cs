using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBotMessages.Models
{
    public class Message
    {
        public Message()
        {
        }

        /// <summary>
        /// Create a new message object and set the main text
        /// </summary>
        /// <param name="text">The main text to show in the message</param>
        public Message(string text)
        {
            Text = text;
        }

        /// <summary>
        /// The name of the channel selected as a destination for the message
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// The username to show next to the message
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The icon emoji to show along side the username
        /// </summary>
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        /// <summary>
        /// A url for an image to show along side the username
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The main text to display in the message
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Set this to true if you want slack to try to unfurl links
        /// in this message
        /// </summary>
        [JsonProperty("unfurl_links")]
        public bool UnfurlLinks { get; set; }


        /// <summary>
        /// Set this to true if you want slack to try to unfurl media
        /// in this message
        /// </summary>
        [JsonProperty("unfurl_media")]
        public bool UnfurlMedia { get; set; }

        /// <summary>
        /// Add a collection of attachments to the message to make it have richer formatting.
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        public Message AddAttachment(Attachment attachment)
        {
            if (Attachments == null)
            {
                Attachments = new List<Attachment>();
            }
            
            Attachments.Add(attachment);
            return this;
        }
        
        public Message SetUser(string username, string iconEmoji = null, string iconUrl = null)
        {
            Username = username;
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            return this;
        }
        
        
        public Message SetChannel(string channel)
        {
            Channel = channel;
            return this;
        }
    }
}