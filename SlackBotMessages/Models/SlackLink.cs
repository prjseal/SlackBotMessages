namespace SlackBotMessages.Models
{
    public class SlackLink
    {
        /// <summary>
        ///     Create a slack link
        /// </summary>
        /// <param name="url">The link url</param>
        /// <param name="text">The link text</param>
        public SlackLink(string url, string text)
        {
            Url = url;
            Text = text;
        }

        /// <summary>
        ///     The link url
        /// </summary>
        private string Url { get; }

        /// <summary>
        ///     The link text
        /// </summary>
        private string Text { get; }

        /// <summary>
        ///     Override of the ToString method to render the link properly
        /// </summary>
        /// <returns>A url formatted correctly for Slack</returns>
        public override string ToString()
        {
            var linkText = !string.IsNullOrWhiteSpace(Text) ? Text : Url;
            return $"<{Url}|{linkText}>";
        }
    }
}