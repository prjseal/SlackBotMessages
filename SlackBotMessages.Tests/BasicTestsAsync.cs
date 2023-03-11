using NUnit.Framework;
using SlackBotMessages.Enums;
using SlackBotMessages.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBotMessages.Tests
{
    public class BasicAsyncTests
    {
        private static string WebHookUrl =>
            "https://hooks.slack.com/services/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";

        /// <summary>
        ///     A simple example of a message which looks like it has been send by an alien
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Emoji_Icon_Example_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message
            {
                Username = "Alien",
                Text = "Hello from an Alien",
                IconEmoji = Emoji.Alien
            };

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }


        /// <summary>
        ///     A simple message which has a custom username and image for the user,
        ///     which looks like it has been sent by Paul Seal
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Custom_Icon_Url_Example_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message
            {
                Username = "Paul Seal",
                Text = "Hello from Paul",
                IconUrl = "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-17/669285832007_48.png"
            };

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This test give you an example of adding multiple attachments of different colors.
        ///     It shows you how you could use attachments to show the status of something
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Send_Rich_Message_Success_Async()
        {
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

            var response = await client.SendAsync(msg).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This is an example which looks like a Pingdom Down alert
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Pingbot_Alert_Website_Down_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This is an example which looks like a Pingdom Up alert
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Pingbot_Alert_Website_Up_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This gives the same result as the Pingdom down example above,
        ///     except it uses the fluent methods for setting things like the
        ///     user, color and fields etc
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Pingbot_Alert_Website_Down_Fluent_Example_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message().SetUserWithIconUrl("Pingbot",
                    "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
                .AddAttachment(
                    new Attachment("Google is down (Incident #12345)")
                        .SetColor(Color.Red)
                        .AddField("Google is down (Incident #12345)",
                            "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>")
                );

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This gives the same result as the Pingdom up example above,
        ///     except it uses the fluent methods for setting things like the
        ///     user, color and fields etc
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Pingbot_Alert_Website_Up_Fluent_Example_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message().SetUserWithIconUrl("Pingbot",
                    "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
                .AddAttachment(
                    new Attachment("Google is up (Incident #12345)")
                        .SetColor(Color.Green)
                        .AddField("Google is up (Incident #12345)",
                            "<https://google.com> • <https://my.pingbot.com/reports/responsetime#check=12345|View details>")
                );

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can add a footer to the message
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Footer_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can add a thumbnail image to the message
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Thumb_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     An example of a rich card showing a link, custom username and icon, author details
        ///     Field containing the title and value and an image to enrich the card.
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Article_Link_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can add short fields side by side
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Short_Fields_Example_Async()
        {
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

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send a @channel notification
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Notification_To_Channel_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("<!channel> hey this is cool");

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send a @group notification
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Notification_To_Group_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("<!group> this is cool");

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send a @here notification
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Notification_To_Here_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("<!here> this is cool");

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send a @everyone notification
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Notification_To_Everyone_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("<!everyone> this is cool");

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send response via in_channel
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Response_In_Channel_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("This is an in_channel response type.");

            message.SetResponseType(ResponseType.in_channel);
            var response = await client.SendAsync(message);
            Assert.AreEqual("ok", response);
        }

        /// <summary>
        ///     This example shows you how you can send response via ephemeral
        ///     using the SendAsync method
        /// </summary>
        [Test]
        public async Task Response_In_Ephemeral_Async()
        {
            var client = new SbmClient(WebHookUrl);

            var message = new Message("This is an ephemeral response type.");

            message.SetResponseType(ResponseType.ephemeral);
            var response = await client.SendAsync(message);
            Assert.AreEqual("ok", response);
        }
        
        /// <summary>
        ///     A simple example of a message which looks like it has been send by an alien using an injected HttpClient
        ///     
        /// </summary>
        [Test]
        public async Task AsyncSendWithNewConstructor()
        {
            var httpClient = new HttpClient();
            ISbmClient client = new SbmClient(httpClient, WebHookUrl);

            var message = new Message
            {
                Username = "Alien",
                Text = "Hello from an Alien",
                IconEmoji = Emoji.Alien
            };

            var response = await client.SendAsync(message).ConfigureAwait(false);
            Assert.AreEqual("ok", response);
        }
    }
}