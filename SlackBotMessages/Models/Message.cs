using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBotMessages.Enums;
using SlackBotMessages.ExtensionMethods;

namespace SlackBotMessages.Models
{
    public class Message
    {
        private string _responseType;

        /// <summary>
        ///     Create a message
        /// </summary>
        public Message()
        {
        }

        /// <summary>
        ///     Create a new message object and set the main text
        /// </summary>
        /// <param name="text">The main text to show in the message</param>
        public Message(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     The name of the channel selected as a destination for the message
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        ///     The username to show next to the message
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        ///     The icon emoji to show along side the username
        /// </summary>
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        /// <summary>
        ///     A url for an image to show along side the username
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        ///     The main text to display in the message
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Set this to true if you want slack to try to unfurl links
        ///     in this message
        /// </summary>
        [JsonProperty("unfurl_links")]
        public bool UnfurlLinks { get; set; }


        /// <summary>
        ///     Set this to true if you want slack to try to unfurl media
        ///     in this message
        /// </summary>
        [JsonProperty("unfurl_media")]
        public bool UnfurlMedia { get; set; }

        /// <summary>
        ///     Add a collection of attachments to the message to make it have richer formatting.
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("response_type")]
        private string ResponseType
        {
            get => string.IsNullOrEmpty(_responseType) ? "in_channel" : _responseType;
            set => _responseType = value;
        }

        /// <summary>
        ///     Add an attachment to the message
        /// </summary>
        /// <param name="attachment">The attachment to add</param>
        /// <returns>The updated message</returns>
        public Message AddAttachment(Attachment attachment)
        {
            if (Attachments == null) Attachments = new List<Attachment>();

            Attachments.Add(attachment);
            return this;
        }

        /// <summary>
        ///     Set the username and emoji for the message
        /// </summary>
        /// <param name="username">The username to display</param>
        /// <param name="iconEmoji">The emoji icon to display with the username</param>
        /// <returns>The updated message</returns>
        public Message SetUserWithEmoji(string username, string iconEmoji)
        {
            Username = username;
            IconEmoji = iconEmoji;
            return this;
        }

        /// <summary>
        ///     Set the username and icon url for the message
        /// </summary>
        /// <param name="username">The username to display</param>
        /// <param name="iconUrl">The url of an icon to display next to the username</param>
        /// <returns>The updated message</returns>
        public Message SetUserWithIconUrl(string username, string iconUrl)
        {
            Username = username;
            IconUrl = iconUrl;
            return this;
        }

        /// <summary>
        ///     Sets the channel to display this message in
        /// </summary>
        /// <param name="channel">The channel to display this message in</param>
        /// <returns>The updated message</returns>
        public Message SetChannel(string channel)
        {
            Channel = channel;
            return this;
        }

        /// <summary>
        ///     Sets the response type to either reply to the entire channel or to just the user. Helpful for Slash Commands. Default is InChannel.
        /// </summary>
        /// <param name="responseType">How you want the response to be displayed.</param>
        /// <returns></returns>
        public Message SetResponseType(ResponseType responseType)
        {
            ResponseType = responseType.DescriptionAttr();
            return this;
        }
    }
}