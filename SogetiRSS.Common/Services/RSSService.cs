// ----------------------------------------------------------------------------
// <copyright file="RSSService.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using HtmlAgilityPack;

    /// <summary>
    /// Represents the RSS service.
    /// </summary>
    public class RSSService : IRSSService
    {
        #region Methods

        /// <summary>
        /// Loads the HTML.
        /// </summary>
        /// <param name="inputUri">The input URI.</param>
        /// <returns>
        /// The loaded HTML from the specified input URI.
        /// </returns>
        public Task<string> LoadHtml(string inputUri)
        {
            return new Task<string>(
                () =>
                {
                    if (string.IsNullOrWhiteSpace(inputUri))
                    {
                        return "<html><head></head><body></body></html>";
                    }

                    var htmlDocument = new HtmlDocument();
                    var request = (HttpWebRequest)WebRequest.Create(inputUri);
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (var receiveStream = response.GetResponseStream())
                            {
                                StreamReader readStream = null;

                                if (response.CharacterSet == null)
                                {
                                    readStream = new StreamReader(receiveStream);
                                }
                                else
                                {
                                    readStream = new StreamReader(
                                        receiveStream, Encoding.GetEncoding(response.CharacterSet));
                                }

                                htmlDocument.Load(readStream.BaseStream, false);
                                readStream.Close();
                            }
                        }
                    }

                    if ((htmlDocument.DocumentNode == null) ||
                        string.IsNullOrWhiteSpace(htmlDocument.DocumentNode.InnerHtml))
                    {
                        return "<html><head></head><body><h1>Load error!</h1><br/><h3>Error without description or unknown.</h3></body></html>";
                    }

                    var noErrorScriptHtml =
                        "<script type=\"text/javascript\">function noError(){return true;} window.onerror=noError;</script>";

                    var headNode = htmlDocument.DocumentNode.SelectSingleNode("//head");

                    headNode.InsertBefore(
                        htmlDocument.CreateTextNode(noErrorScriptHtml),
                        headNode.FirstChild);

                    var bodyNode = htmlDocument.DocumentNode.SelectSingleNode("//body");

                    bodyNode.InsertBefore(
                        htmlDocument.CreateTextNode(noErrorScriptHtml),
                        bodyNode.FirstChild);

                    var htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"content\"]");

                    var nodesToRemove = new List<HtmlNode>();

                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"jp-post-flair\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"sidebar-after-singular\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"comments-template\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"footer\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"sidebar-primary\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"bit\"]"));
                    nodesToRemove.Add(htmlDocument.DocumentNode.SelectSingleNode("//div[@class=\"wpcnt\"]"));

                    foreach (var nodeToRemove in nodesToRemove.Where(node => (node != null)))
                    {
                        nodeToRemove.Remove();
                    }

                    var linkNodes = htmlDocument.DocumentNode.SelectNodes("//a");

                    foreach (var linkNode in linkNodes)
                    {
                        linkNode.SetAttributeValue("target", "_blank");
                    }

                    if (htmlNode != null)
                    {
                        htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class=\"entry-content\"]");

                        bodyNode.RemoveAllChildren();
                        bodyNode.AppendChild(htmlNode);
                    }

                    return htmlDocument.DocumentNode.InnerHtml;
                });
        }

        /// <summary>
        /// Loads the syndication feed.
        /// </summary>
        /// <param name="inputUri">The input URI.</param>
        /// <returns>
        /// The loaded syndication feed.
        /// </returns>
        public Task<SyndicationFeed> LoadSyndicationFeed(string inputUri)
        {
            return new Task<SyndicationFeed>(
                () =>
                {
                    using (XmlReader reader = XmlReader.Create(inputUri))
                    {
                        return SyndicationFeed.Load(reader);
                    }
                });
        }

        #endregion Methods
    }
}