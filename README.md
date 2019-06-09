![SlackBotMessages Logo](https://github.com/prjseal/SlackBotMessages/blob/master/sbm_logo.png "SlackBotMessages Logo")

# SlackBotMessages

[![Nuget Downloads](https://img.shields.io/nuget/dt/SlackBotMessages.svg)](https://www.nuget.org/packages/SlackBotMessages)

A .NET library to enable you to send bot messages in slack, by posting messages to Slack's incoming WebHook Urls

## NuGet

Install via NuGet: ``` Install-Package SlackBotMessages ```

[Or click here to go to the NuGet package landing page](https://www.nuget.org/packages/SlackBotMessages)

## Registering for your WebHook Url with Slack

[Click here to set up an incoming WebHook] (https://my.slack.com/services/new/incoming-webhook/)

- Sign in to Slack
- Choose a channel to post to
- Then click on the green button Add Incoming WebHooks integration
- You will be given a WebHook Url. Keep this private. Use it when you set up the SBMClient. See example below.

```javascript
// Usage example
// This will send a message to the slack channel with the message, username and emoji of your choice 

using SlackBotMessages;

SBMClient client = new SBMClient("https://hooks.slack.com/services/Your/WebHook/Url");
Message msg = new Message("Hello World", "general", "codeshare.co.uk",":poop:");
client.Send(msg);

```

You can try it out in the test project.
