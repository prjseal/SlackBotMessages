using System.ComponentModel;

namespace SlackBotMessages.Enums
{
    public enum ResponseType
    {
        /// <summary>
        /// Responses are visible to the entire channel
        /// </summary>
        [Description("in_channel")]
        InChannel,
        
        /// <summary>
        /// Responses are just visible to the user
        /// </summary>
        [Description("ephemeral")]
        Ephemeral
    }
}
