using System;
using System.Collections.Generic;
using NUnit.Framework;
using SlackBotMessages.Models;

namespace SlackBotMessages.Tests
{
    public class BasicTests
    {
        private string WebHookUrl => "https://hooks.slack.com/services/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";
        
        [Test]
        public void Send_Rich_Message_Success()
        {
            var client = new SbmClient(WebHookUrl);
            var msg = new Message
            {
                Text = "You are using Slack Bot Messages by Paul Seal from codeshare.co.uk",
                Channel = "general",
                Username = "SlackBotMessages",
                IconUrl = "https://ca.slack-edge.com/T0ZLAHWL9-U0ZKYQZRC-9c463942a1b6-48",
                UnfurlLinks = true,
                UnfurlMedia = true,
                Attachments = new List<Attachment> {
                new Attachment
                {
                    Fallback = "Package installedY successfully",
                    Text = "You can say something about this attachment here",
                    Pretext = "This line of text appears inside the attachment",
                    Color = "good",
                    Fields = new List<Field> { new Field
                    {
                        Short = false,
                        Title = Emoji.HeavyCheckMark + "Success",
                        Value = "You can add multiple lines to an attachement\n\nLike this\n\nAnd this."
                    }}
                },
                new Attachment
                {
                    Fallback = "Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.",
                    Text = "Optional text that should appear within the attachment",
                    Pretext = "Optional text that should appear above the formatted data",
                    Color = "warning",
                    Fields = new List<Field> { new Field
                    {
                        Short = false,
                        Title = "Warning",
                        Value = Emoji.Warning + " This is a warning."
                    }}
                },
                new Attachment
                {
                    Fallback = "Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.",
                    Text = new SlackLink("https://codeshare.co.uk", "Test out Slack message attachments").ToString(),
                    Pretext = "Optional text that should appear above the formatted data",
                    Color = "danger",
                    Fields = new List<Field> { new Field
                    {
                        Short = false,
                        Title = "Error",
                        Value = Emoji.NegativeSquaredCrossMark + " Text value of the field.\n\nMay contain standard message markup and must be escaped as normal. May be multi-line. https://codeshare.co.uk"
                    }}
                }
            }
            };

            var response = client.Send(msg);
            Assert.AreEqual("ok", response.Result);
        }

        [Test]
        public void Pingdom_Alert_Website_Down_Example()
        {
            var client = new SbmClient(WebHookUrl);
            var message = new Message()
            {
                Username = "Pingdom",
                IconUrl = "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png",
                Attachments = new List<Attachment>()
                {
                    new Attachment()
                    {
                        Color = "danger",
                        Fallback = "codeshare.co.uk is down",
                        Fields = new List<Field>()
                        {
                            new Field()
                            {
                                Title = "Website is down (Incident #123456)",
                                Value = "<https://codeshare.co.uk> • <https://my.pingdom.com/reports/responsetime#check=123456|View details>",
                                Short = false
                            }
                        }
                    }
                }
            };
            var response = client.Send(message);
            Assert.AreEqual("ok", response.Result);
        }

        [Test]
        public void Pingdom_Alert_Website_Up_Example()
        {
            var client = new SbmClient(WebHookUrl);
            var message = new Message()
            {
                Username = "Pingdom",
                IconUrl = "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png",
                Attachments = new List<Attachment>()
                {
                    new Attachment()
                    {
                        Color = "good",
                        Fallback = "codeshare.co.uk is up",
                        Fields = new List<Field>()
                        {
                            new Field()
                            {
                                Title = "Website is up (Incident #123456)",
                                Value = "<https://codeshare.co.uk|https://codeshare.co.uk> • <https://my.pingdom.com/reports/responsetime#check=123456|View details>",
                                Short = false
                            }
                        }
                    }
                }
            };
            var response = client.Send(message);
            Assert.AreEqual("ok", response.Result);
        }

        [Test]
        public void Custom_Icon()
        {
            var client = new SbmClient(WebHookUrl);
            var message = new Message()
            {
                Username = "Paul Seal",
                Text = "Hello from Paul",
                IconUrl = "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-17/669285832007_48.png"
            };
            client.Send(message);
        }

        [Test]
        public void Emoji_Icon()
        {
            var client = new SbmClient(WebHookUrl);
            var message = new Message()
            {
                Username = "Alien",
                Text = "Hello from an Alien",
                IconEmoji = Emoji.Alien
            };
            client.Send(message);
        }

        [Test]
        public void Footer_Example()
        {
            var client = new SbmClient(WebHookUrl);
            var message = new Message(username: "Pingdom", iconUrl: "https://a.slack-edge.com/7f1a0/plugins/pingdom/assets/service_36.png")
                .AddAttachment(
                    new Attachment("good", "codeshare.co.uk is up")
                        .AddField("Website is up (Incident #123456)",
                            "<https://codeshare.co.uk|https://codeshare.co.uk> • <https://my.pingdom.com/reports/responsetime#check=123456|View details>",
                            false)
                        .WithFooter("Paul Seal",
                            "https://s3-us-west-2.amazonaws.com/slack-files2/bot_icons/2019-06-18/656803539986_48.png",
                            DateTime.UtcNow)
            );
            var response = client.Send(message);
            Assert.AreEqual("ok", response.Result);
        }
    }
}