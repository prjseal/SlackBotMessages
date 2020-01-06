using System.ComponentModel.DataAnnotations;

namespace SlackBotMessages.Enums
{
    public enum ResponseType
    {
        /// <summary>
        /// Responses are visible to the entire channel
        /// </summary>
        in_channel,

        /// <summary>
        /// Responses are just visible to the user
        /// </summary>
        ephemeral
    }
}
