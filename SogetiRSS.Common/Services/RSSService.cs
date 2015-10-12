// ----------------------------------------------------------------------------
// <copyright file="RSSService.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Services
{
    using System.ServiceModel.Syndication;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Represents the RSS service.
    /// </summary>
    public class RSSService : IRSSService
    {
        #region Methods

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