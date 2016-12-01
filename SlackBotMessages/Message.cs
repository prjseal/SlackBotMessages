using System;
using System.Net;
using System.Text;
using System.IO;

namespace SlackBotMessages
{
    /// <summary>
    /// A message with the structure required by slack
    /// </summary>
    public class Message
    {
        public string Text { get; set; }
        public string Channel { get; set; }
        public string UserName { get; set; }
        public string Icon_Emoji { get; set; }

        /// <summary>
        /// Creates the message with just the text.
        /// Slack will use the defaults for the channel, username and icon_emoji
        /// </summary>
        /// <param name="text">The content of the message</param>
        public Message(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates the message with the text and the channel to send it to
        /// Slack will use the defaults for the username and icon_emoji
        /// </summary>
        /// <param name="text">The content of the message</param>
        /// <param name="channel">The name of the channel to send the message to</param>
        public Message(string text, string channel)
        {
            Text = text;
            Channel = channel;
        }

        /// <summary>
        /// Creates the message with the text and the channel to send it to
        /// Slack will use the default for the icon_emoji
        /// </summary>
        /// <param name="text">The content of the message</param>
        /// <param name="channel">The name of the channel to send the message to</param>
        /// <param name="username">The username of the bot when it shows in slack</param>
        public Message(string text, string channel, string username)
        {
            Text = text;
            Channel = channel;
            UserName = username;
        }

        /// <summary>
        /// Creates the message with all properties set
        /// </summary>
        /// <param name="text">The content of the message</param>
        /// <param name="channel">The name of the channel to send the message to</param>
        /// <param name="username">The username of the bot when it shows in slack</param>
        /// <param name="icon_emoji">The emoji icon to use when displaying the message</param>
        public Message(string text, string channel, string username, string icon_emoji)
        {
            Text = text;
            Channel = channel;
            UserName = username;
            Icon_Emoji = icon_emoji;
        }
    }
}
