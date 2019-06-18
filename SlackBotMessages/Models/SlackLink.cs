namespace SlackBotMessages.Models
{
    public class SlackLink
    {
        private string Url { get; }
        private string Text { get; }

        public SlackLink(string url, string text)
        {
            Url = url;
            Text = text;
        }

        public override string ToString()
        {
            string linkText = !string.IsNullOrWhiteSpace(Text) ? Text : Url;
            return $"<{Url}|{linkText}>";
        }
    }
}