using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBotMessages.Enums;

namespace SlackBotMessages.Models
{
    /// <summary>
    /// Send rich messages using attachments
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Create an attachment
        /// </summary>
        public Attachment()
        {
        }

        /// <summary>
        /// Create an attachment and define the fallback text
        /// </summary>
        /// <param name="fallbackText">Text to be shown by Slack clients
        /// which understand attachments but choose not to show them.</param>
        public Attachment(string fallbackText)
        {
            Fallback = fallbackText;
        }

        /// <summary>
        /// Create an attachment and define the fallback text and pretext
        /// </summary>
        /// <param name="fallbackText">Text to be shown by Slack clients
        /// which understand attachments but choose not to show them.</param>
        /// <param name="pretext">Text to be shown just above an attachment</param>
        public Attachment(string fallbackText, string pretext)
        {
            Fallback = fallbackText;
            Pretext = pretext;
        }

        /// <summary>
        /// Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.
        /// </summary>
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        /// <summary>
        /// This is the main text in a message attachment, and can contain
        /// standard message markup. The content will automatically collapse
        /// if it contains 700+ characters or 5+ linebreaks, and will display
        /// a "Show more..." link to expand the content. Links posted in the
        /// text field will not unfurl.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Optional text that should appear above the formatted data
        /// </summary>
        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Fields are displayed in a table on the message
        /// </summary>
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// Small text used to display the author's name.
        /// </summary>
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// A valid URL that will hyperlink the author_name text mentioned
        /// above. Will only work if author_name is present.
        /// </summary>
        [JsonProperty("author_link")]
        public string AuthorLink { get; set; }

        /// <summary>
        /// A valid URL that displays a small 16x16px image to the left of
        /// the author_name text. Will only work if author_name is present.
        /// </summary>
        [JsonProperty("author_icon")]
        public string AuthorIcon { get; set; }

        /// <summary>
        /// The title is displayed as larger, bold text near the top of a
        /// message attachment.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// By passing a valid URL in the title_link parameter (optional),
        /// the title text will be hyperlinked.
        /// </summary>
        [JsonProperty("title_link")]
        public string TitleLink { get; set; }

        /// <summary>
        /// A valid URL to an image file that will be displayed inside a
        /// message attachment. We currently support the following
        /// formats: GIF, JPEG, PNG, and BMP.
        ///
        /// Large images will be resized to a maximum width of 360px
        /// or a maximum height of 500px, while still maintaining the
        /// original aspect ratio.
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// A valid URL to an image file that will be displayed as a
        /// thumbnail on the right side of a message attachment. We
        /// currently support the following formats: GIF, JPEG, PNG,
        /// and BMP.The thumbnail's longest dimension will be scaled
        /// down to 75px while maintaining the aspect ratio of the image.
        /// The filesize of the image must also be less than 500 KB.For
        /// best results, please use images that are already 75px by 75px.
        /// </summary>
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Add some brief text to help contextualize and identify an
        /// attachment. Limited to 300 characters, and may be truncated
        /// further when displayed to users in environments with limited
        /// screen real estate.
        /// </summary>
        [JsonProperty("footer")]
        public string Footer { get; set; }

        /// <summary>
        /// To render a small icon beside your footer text, provide a
        /// publicly accessible URL string in the footer_icon field.
        /// You must also provide a footer for the field to be recognized.
        /// We'll render what you provide at 16px by 16px. It's best to
        /// use an image that is similarly sized.
        /// </summary>
        [JsonProperty("footer_icon")]
        public string FooterIcon { get; set; }

        /// <summary>
        /// By providing the timestamp field with an integer value in
        /// "epoch time", the attachment will display an additional
        /// timestamp value as part of the attachment's footer.
        /// </summary>
        [JsonProperty("ts")]
        public int FooterTimeStamp { get; set; }

        /// <summary>
        /// Set the properties needed to show a footer
        /// </summary>
        /// <param name="footerText">The text to show in the footer</param>
        /// <param name="footerIcon">The small icon to show in the footer</param>
        /// <param name="footerTimeStamp">A DateTime object representing the timestamp</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetFooter(string footerText, string footerIcon, DateTime footerTimeStamp)
        {
            Footer = footerText;
            FooterIcon = footerIcon;

            var epochTime = (footerTimeStamp - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            FooterTimeStamp = (int) epochTime;
            return this;
        }

        /// <summary>
        /// Add a field to the Attachment
        /// </summary>
        /// <param name="title">The title which will show in bold</param>
        /// <param name="value">The value to display under the title</param>
        /// <param name="_short">A bool to say if the field value is short so
        /// the field can be displayed side by side with other short fields</param>
        /// <returns>The updated attachment</returns>
        public Attachment AddField(string title, string value, bool _short)
        {
            if (Fields == null)
            {
                Fields = new List<Field>();
            }

            Fields.Add(new Field()
            {
                Title = title,
                Value = value,
                Short = _short
            });

            return this;
        }

        /// <summary>
        /// Add Author details to the Attachment
        /// </summary>
        /// <param name="authorName">Name of the Author</param>
        /// <param name="authorLink">Link for the Author, this will
        /// make the name an hyperlink</param>
        /// <param name="authorIcon">Icon for the Author</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetAuthor(string authorName, string authorLink = null, string authorIcon = null)
        {
            AuthorName = authorName;
            AuthorLink = authorLink;
            AuthorIcon = authorIcon;
            return this;
        }

        /// <summary>
        /// Set the pretext for the attachment
        /// </summary>
        /// <param name="pretext">The text which shows just above the attachment</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetPretext(string pretext)
        {
            Pretext = pretext;
            return this;
        }

        /// <summary>
        /// Set the image to display in the Attachment
        /// </summary>
        /// <param name="imageUrl">The url of the image to display</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetImage(string imageUrl)
        {
            ImageUrl = imageUrl;
            return this;
        }

        /// <summary>
        /// Set the thumb url to show in the attachment
        /// </summary>
        /// <param name="thumbUrl">The url of a small image which will be cropped
        /// to a 75x75 square</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetThumbUrl(string thumbUrl)
        {
            ThumbUrl = thumbUrl;
            return this;
        }

        /// <summary>
        /// Set the color of the attachment, using an enum of colors
        /// </summary>
        /// <param name="color">An enum for the predefined colors</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetColor(Color color)
        {
            switch (color)
            {
                case Enums.Color.Red:
                    Color = "danger";
                    break;
                case Enums.Color.Orange:
                    Color = "warning";
                    break;
                case Enums.Color.Green:
                    Color = "good";
                    break;
                default:
                    Color = null;
                    break;
            }

            return this;
        }

        /// <summary>
        /// Set the color of the attachment, using a css hex code
        /// </summary>
        /// <param name="colorHexCode">The CSS hex code color</param>
        /// <returns>The updated attachment</returns>
        public Attachment SetColor(string colorHexCode)
        {
            Color = colorHexCode;
            return this;
        }
    }
}