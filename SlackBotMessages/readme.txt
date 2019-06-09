
  ____  _            _      ____        _     __  __                                     
 / ___|| | __ _  ___| | __ | __ )  ___ | |_  |  \/  | ___  ___ ___  __ _  __ _  ___  ___ 
 \___ \| |/ _` |/ __| |/ / |  _ \ / _ \| __| | |\/| |/ _ \/ __/ __|/ _` |/ _` |/ _ \/ __|
  ___) | | (_| | (__|   <  | |_) | (_) | |_  | |  | |  __/\__ \__ \ (_| | (_| |  __/\__ \
 |____/|_|\__,_|\___|_|\_\ |____/ \___/ \__| |_|  |_|\___||___/___/\__,_|\__, |\___||___/
                                                                         |___/           
                                                                            																			  
-----------------------------------------------------------------------------------------

A .NET library to enable you to send bot messages in slack, by posting messages to Slack's incoming WebHook Urls

Registering for your WebHook Url with Slack
https://my.slack.com/services/new/incoming-webhook/

- Sign in to Slack
- Choose a channel to post to
- Then click on the green button Add Incoming WebHooks integration
- You will be given a WebHook Url. Keep this private. Use it when you set up the SBMClient. See example below.

// Usage example
// This will send a message to the slack channel with the message, username and emoji of your choice 

using SlackBotMessages;

SBMClient client = new SBMClient("https://hooks.slack.com/services/Your/WebHook/Url");
Message msg = new Message("Hello World", "general", "codeshare.co.uk",":poop:");
client.Send(msg);

-----------------------------------------------------------------------------------------

   ( (
    ) )
  ........    You can show your appreciation for this package, by buying me a coffee
  |      |]   
  \      /    https://codeshare.co.uk/coffee
   `----'