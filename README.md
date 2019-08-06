![SlackBotMessages Logo](https://github.com/prjseal/SlackBotMessages/blob/master/sbmlogo.jpg "SlackBotMessages Logo")

# SlackBotMessages

[![Nuget Downloads](https://img.shields.io/nuget/dt/SlackBotMessages.svg)](https://www.nuget.org/packages/SlackBotMessages)

A .NET library to enable you to send rich formatted bot messages in slack, by posting messages to Slack's incoming WebHook Urls

This library has been completely re-written giving you the ability and control to send better
looking messages in Slack programmatically.

It is Compatible with .NET Core, .NET Framework and more. See the below chart:

![Compatibility Chart](https://github.com/prjseal/SlackBotMessages/blob/master/images/compatibility.png "Compatibility Chart")

Have a look at the [test project](https://github.com/prjseal/SlackBotMessages/blob/master/SlackBotMessages.Tests/BasicTests.cs) to see the examples of how to use the library

## NuGet

Install via NuGet: ``` Install-Package SlackBotMessages ```

[Or click here to go to the NuGet package landing page](https://www.nuget.org/packages/SlackBotMessages)

## Registering for your WebHook Url with Slack

[Click here to set up an incoming WebHook](https://my.slack.com/services/new/incoming-webhook/)

- Sign in to Slack
- Choose a channel to post to
- Then click on the green button Add Incoming WebHooks integration
- You will be given a WebHook Url. Keep this private. Use it when you set up the SBMClient. See example below.

## Usage examples

### Emoji Icon Example

![Emoji Icon Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/alienemoji.png "Emoji Icon Example")

```
/// <summary>
///     A simple example of a message which looks like it has been send by an alien
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message
{
    Username = "Alien",
    Text = "Hello from an Alien",
    IconEmoji = Emoji.Alien
};

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Custom Icon Url Example

![Custom Icon Url Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/customiconurl.png "Custom Icon Url Example")

```
/// <summary>
///     A simple message which has a custom username and image for the user,
///     which looks like it has been sent by Paul Seal
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message
{
    Username = "Paul Seal",
    Text = "Hello from Paul",
    IconUrl = "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-17/669285832007_48.png"
};

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Multiple Attachments Example

![Multiple Attachments Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/multipleattachments.png "Multiple Attachments Example")

```
/// <summary>
///     This test give you an example of adding multiple attachments of different colors.
///     It shows you how you could use attachments to show the status of something
/// </summary>

var client = new SbmClient(WebHookUrl);

var msg = new Message
{
    Text = "You are using Slack Bot Messages by Paul Seal from codeshare.co.uk",
    Channel = "general",
    Username = "SlackBotMessages",
    IconUrl = "https://codeshare.co.uk/media/1505/sbmlogo.jpg",
    Attachments = new List<Attachment>
    {
        new Attachment
        {
            Fallback = "This is for slack clients which choose not to display the attachment.",
            Pretext = "This line appears before the attachment",
            Text = "This line of text appears inside the attachment",
            Color = "good",
            Fields = new List<Field>
            {
                new Field
                {
                    Title = Emoji.HeavyCheckMark + " Success",
                    Value = "You can add multiple lines to an attachment\n\nLike this\n\nAnd this."
                }
            }
        },
        new Attachment
        {
            Fallback =
                "Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.",
            Pretext = "Optional text that should appear above the formatted attachment",
            Text = "Optional text that should appear within the attachment",
            Color = "warning",
            Fields = new List<Field>
            {
                new Field
                {
                    Title = Emoji.Warning + " Warning",
                    Value = "This is a warning."
                }
            }
        },
        new Attachment
        {
            Fallback =
                "Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.",
            Pretext = "Optional text that should appear above the formatted data",
            Text = "Check out my blog " + new SlackLink("https://codeshare.co.uk", "codeshare.co.uk"),
            Color = "danger",
            Fields = new List<Field>
            {
                new Field
                {
                    Title = Emoji.X + " Error",
                    Value =
                        "You can use emojis in the text too.\n\nWe've added nearly 900 of them already that you can use with intellisense.\n\nJust start typing `Emoji.` and you will see the available list."
                }
            }
        }
    }
};

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Pingdom Down Alert Example

![Pingdom Down Alert Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/pingbot.png "Pingdom Down Alert Example")

```
/// <summary>
///     This is an example which looks like a Pingdom Down alert
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message
{
    Username = "Pingbot",
    IconUrl = "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png",
    Attachments = new List<Attachment>
    {
        new Attachment
        {
            Color = "danger",
            Fallback = "Google is down (Incident #12345)",
            Fields = new List<Field>
            {
                new Field
                {
                    Title = "Google is down (Incident #12345)",
                    Value =
                        "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>"
                }
            }
        }
    }
};

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Pingdom Up Alert Example

```
/// <summary>
///     This is an example which looks like a Pingdom Up alert
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message
{
    Username = "Pingbot",
    IconUrl = "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png",
    Attachments = new List<Attachment>
    {
        new Attachment
        {
            Color = "good",
            Fallback = "Google is up (Incident #12345)",
            Fields = new List<Field>
            {
                new Field
                {
                    Title = "Google is up (Incident #12345)",
                    Value =
                        "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>"
                }
            }
        }
    }
};

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Pingdom Down Alert Example - Fluent Methods

```
/// <summary>
///     This gives the same result as the Pingdom down example above,
///     except it uses the fluent methods for setting things like the
///     user, color and fields etc
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message().SetUserWithIconUrl("Pingbot",
        "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
    .AddAttachment(
        new Attachment("Google is down (Incident #12345)")
            .SetColor(Color.Red)
            .AddField("Google is down (Incident #12345)",
                "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>")
    );

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Pingdom Up Alert Example - Fluent Methods

```
/// <summary>
///     This gives the same result as the Pingdom up example above,
///     except it uses the fluent methods for setting things like the
///     user, color and fields etc
/// </summary>
    
var client = new SbmClient(WebHookUrl);

var message = new Message().SetUserWithIconUrl("Pingbot",
        "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
    .AddAttachment(
        new Attachment("Google is up (Incident #12345)")
            .SetColor(Color.Green)
            .AddField("Google is up (Incident #12345)",
                "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>")
    );

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Footer Example

![Footer Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/footer.png "Footer Example")

```
/// <summary>
///     This example shows you how you can add a footer to the message
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message()
    .SetChannel("general")
    .SetUserWithIconUrl("SlackBotMessages", "https://codeshare.co.uk/media/1505/sbmlogo.jpg")
    .AddAttachment(
        new Attachment("Lorem ipsum dolor sit amet ...")
            .SetColor("#ff00ff")
            .AddField("A love story",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Fames ac turpis egestas integer eget aliquet nibh praesent tristique. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Ultrices tincidunt arcu non sodales neque sodales. Ac auctor augue mauris augue neque gravida in fermentum et. Facilisi nullam vehicula ipsum a. Ac turpis egestas integer eget aliquet nibh praesent tristique. Vitae ultricies leo integer malesuada nunc vel risus commodo. Justo nec ultrices dui sapien eget mi proin sed. At auctor urna nunc id cursus metus aliquam eleifend. Purus sit amet luctus venenatis. Cursus in hac habitasse platea dictumst quisque. Pharetra sit amet aliquam id diam. In vitae turpis massa sed. Massa massa ultricies mi quis.")
            .SetFooter("Paul Seal",
                "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-18/656803539986_48.png",
                DateTime.UtcNow)
    );

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Thumbnail Example

![Thumbnail Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/thumbnail.png "Thumbnail Example")

```
/// <summary>
///     This example shows you how you can add a thumbnail image to the message
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message()
    .SetChannel("general")
    .SetUserWithIconUrl("SlackBotMessages", "https://codeshare.co.uk/media/1505/sbmlogo.jpg")
    .AddAttachment(
        new Attachment("Lorem ipsum dolor sit amet ...")
            .SetColor("#0000ff")
            .AddField("A love story with a thumbnail",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Fames ac turpis egestas integer eget aliquet nibh praesent tristique. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Ultrices tincidunt arcu non sodales neque sodales. Ac auctor augue mauris augue neque gravida in fermentum et. Facilisi nullam vehicula ipsum a. Ac turpis egestas integer eget aliquet nibh praesent tristique. Vitae ultricies leo integer malesuada nunc vel risus commodo. Justo nec ultrices dui sapien eget mi proin sed. At auctor urna nunc id cursus metus aliquam eleifend. Purus sit amet luctus venenatis. Cursus in hac habitasse platea dictumst quisque. Pharetra sit amet aliquam id diam. In vitae turpis massa sed. Massa massa ultricies mi quis.")
            .SetThumbUrl(
                "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-19/658365479699_48.png")
    );

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Rich Card With Image Example

![Rich Card With Image Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/devto.png "Rich Card With Image Example")

```
/// <summary>
///     An example of a rich card showing a link, custom username and icon, author details
///     Field containing the title and value and an image to enrich the card.
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message("https://dev.to/")
    .SetUserWithIconUrl("Slack Bot Messages", "https://codeshare.co.uk/media/1505/sbmlogo.jpg")
    .AddAttachment(
        new Attachment("Sorting the tools")
            .SetAuthor("dev.to",
                authorIcon:
                "https://slack-imgs.com/?c=1&o1=wi32.he32.si&url=https%3A%2F%2Fpracticaldev-herokuapp-com.freetls.fastly.net%2Fassets%2Fapple-icon-e9a036e0385d6e1e4ddef50be5e583800c0b5ca325d4998a640c38602d23b26c.png")
            .SetColor("#DDDDDD")
            .AddField("The DEV Community", "Where programmers share ideas and help each other grow.")
            .SetImage("https://thepracticaldev.s3.amazonaws.com/i/6hqmcjaxbgbon8ydw93z.png")
    );

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Short Fields Example

![Short Fields Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/shortfields.png "Short Fields Example")

```
/// <summary>
///     This example shows you how you can add short fields side by side
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message();
message.AddAttachment(new Attachment()
    .AddField("Lorem", "Ipsum Dolor", true)
    .AddField("Sit", "Amet", true)
    .AddField("Consectetur", "Adipiscing elit", true)
    .AddField("Eiusmod", "Tempor incididunt", true)
    .AddField("A love story",
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Fames ac turpis egestas integer eget aliquet nibh praesent tristique. Ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Ultrices tincidunt arcu non sodales neque sodales. Ac auctor augue mauris augue neque gravida in fermentum et. Facilisi nullam vehicula ipsum a. Ac turpis egestas integer eget aliquet nibh praesent tristique. Vitae ultricies leo integer malesuada nunc vel risus commodo. Justo nec ultrices dui sapien eget mi proin sed. At auctor urna nunc id cursus metus aliquam eleifend. Purus sit amet luctus venenatis. Cursus in hac habitasse platea dictumst quisque. Pharetra sit amet aliquam id diam. In vitae turpis massa sed. Massa massa ultricies mi quis.")
);

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Notification To Channel Example

![Notification To Channel Example](https://github.com/prjseal/SlackBotMessages/blob/master/images/notifications.png "Notification To Channel Example")

```
/// <summary>
///     This example shows you how you can send a @channel notification
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message("<!channel> hey this is cool");

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Notification To Group Example

```
/// <summary>
///     This example shows you how you can send a @group notification
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message("<!group> this is cool");

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Notification To Here Example

```
/// <summary>
///     This example shows you how you can send a @here notification
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message("<!here> this is cool");

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```

### Notification To Everyone Example

```
/// <summary>
///     This example shows you how you can send a @everyone notification
/// </summary>

var client = new SbmClient(WebHookUrl);

var message = new Message("<!everyone> this is cool");

client.Send(message);
//or send it fully async like this:
//await client.SendAsync(message).ConfigureAwait(false);
```
