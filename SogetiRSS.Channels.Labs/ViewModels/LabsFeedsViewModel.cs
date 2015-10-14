// ----------------------------------------------------------------------------
// <copyright file="LabsFeedsViewModel.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.ViewModels
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using Prism.Regions;
    using Views;

    /// <summary>
    /// Represents the view model for the LabsFeeds view.
    /// </summary>
    internal class LabsFeedsViewModel : BaseFeedViewModel
    {
        #region Methods

        /// <summary>
        /// Called when a feed item is selected.
        /// </summary>
        /// <param name="selectedFeedItem">The selected feed item.</param>
        protected override void OnSelectedFeedItem(FeedItemViewModel selectedFeedItem)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("SelectedFeedItem", selectedFeedItem);

            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RequestNavigate(
                RegionNames.RSSFeedReader,
                new Uri(typeof(LabsFeedReaderView).Name, UriKind.Relative),
                navigationParameters);
        }

        #endregion Methods
    }
}