using System.Threading.Tasks;
using SlackBotMessages.Models;

namespace SlackBotMessages
{
    public interface ISbmClient
    {
        Task<string> SendAsync(Message message);
        Task<string> Send(Message message);
    }
}