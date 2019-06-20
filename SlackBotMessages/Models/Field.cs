using Newtonsoft.Json;

namespace SlackBotMessages.Models
{
    /// <summary>
    ///     Add fields to attachments
    /// </summary>
    public class Field
    {
        /// <summary>
        ///     The title may not contain markup and will be escaped for you
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     "Text value of the field. May contain standard message markup
        ///     and must be escaped as normal. May be multi-line.",
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        ///     An optional flag indicating whether the value is short enough
        ///     to be displayed side-by-side with other values.
        /// </summary>
        [JsonProperty("short")]
        public bool Short { get; set; }
    }
}