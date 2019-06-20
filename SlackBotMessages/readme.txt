
  ____  _            _      ____        _     __  __                                     
 / ___|| | __ _  ___| | __ | __ )  ___ | |_  |  \/  | ___  ___ ___  __ _  __ _  ___  ___ 
 \___ \| |/ _` |/ __| |/ / |  _ \ / _ \| __| | |\/| |/ _ \/ __/ __|/ _` |/ _` |/ _ \/ __|
  ___) | | (_| | (__|   <  | |_) | (_) | |_  | |  | |  __/\__ \__ \ (_| | (_| |  __/\__ \
 |____/|_|\__,_|\___|_|\_\ |____/ \___/ \__| |_|  |_|\___||___/___/\__,_|\__, |\___||___/
                                                                         |___/           
                                                                            																			  
-----------------------------------------------------------------------------------------

A .NET library to enable you to send rich formatted bot messages in slack, by posting messages to Slack's incoming WebHook Urls

This library has been completely re-written giving you the ability and control to send better
looking messages in Slack programmatically.

# Registering for your WebHook Url with Slack #
https://my.slack.com/services/new/incoming-webhook/

- Sign in to Slack
- Choose a channel to post to
- Then click on the green button Add Incoming WebHooks integration
- You will be given a WebHook Url. Keep this private. Use it when you set up the SBMClient. See example below.

Have a look at the Tests project to see the examples of how to use the library
https://github.com/prjseal/SlackBotMessages/blob/master/SlackBotMessages.Tests/BasicTests.cs

# Here are some usage examples: #

------------------------------------------------------------------------------------------

// A simple message which has a custom username and image for the user, which looks like it has been sent by Paul Seal

var client = new SbmClient("https://hooks.slack.com/services/Your/WebHook/Url");
var message = new Message
{
	Username = "Paul Seal",
	Text = "Hello from Paul",
	IconUrl = "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-17/669285832007_48.png"
};
client.Send(message);

------------------------------------------------------------------------------------------

// This sends a message which looks like the Pingdom alerts. It uses the fluent methods for setting things like the user, color and fields etc

var client = new SbmClient("https://hooks.slack.com/services/Your/WebHook/Url");
var message = new Message()
	.SetUserWithIconUrl("Pingbot", "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
	.AddAttachment(
		new Attachment("Google is down (Incident #12345)")
			.SetColor(Color.Red)
			.AddField("Google is down (Incident #12345)","<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>")
		);
client.Send(message);

------------------------------------------------------------------------------------------

   ( (
    ) )
  ........    If you want show your appreciation for this package, you can buy me a coffee
  |      |]   
  \      /    https://codeshare.co.uk/coffee
   `----'