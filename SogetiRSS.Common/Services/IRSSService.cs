// ----------------------------------------------------------------------------
// <copyright file="IRSSService.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Services
{
    using System.ServiceModel.Syndication;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the contract for the RSS service.
    /// </summary>
    public interface IRSSService
    {
        #region Methods

        /// <summary>
        /// Loads the HTML.
        /// </summary>
        /// <param name="inputUri">The input URI.</param>
        /// <returns>
        /// The loaded HTML from the specified input URI.
        /// </returns>
        Task<string> LoadHtml(string inputUri);

        /// <summary>
        /// Loads the syndication feed.
        /// </summary>
        /// <param name="inputUri">The input URI.</param>
        /// <returns>
        /// The loaded syndication feed.
        /// </returns>
        Task<SyndicationFeed> LoadSyndicationFeed(string inputUri);

        #endregion Methods
    }
}