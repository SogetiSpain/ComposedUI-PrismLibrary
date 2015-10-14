// ----------------------------------------------------------------------------
// <copyright file="QANewsFeedsViewModel.cs" company="SOGETI Spain">
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
    /// Represents the view model for the QANewsFeeds view.
    /// </summary>
    internal class QANewsFeedsViewModel : BaseFeedViewModel
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
                new Uri(typeof(QANewsFeedReaderView).Name, UriKind.Relative),
                navigationParameters);
        }

        #endregion Methods
    }
}