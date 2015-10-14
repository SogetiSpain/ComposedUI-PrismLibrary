// ----------------------------------------------------------------------------
// <copyright file="BaseFeedReaderViewModel.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.ViewModels
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using Prism.Mvvm;
    using Prism.Regions;
    using Services;

    /// <summary>
    /// Represents an abstract view model for a feed reader view.
    /// </summary>
    public abstract class BaseFeedReaderViewModel : BindableBase, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Defines the navigation source.
        /// </summary>
        private string navigationSource;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFeedReaderViewModel"/> class.
        /// </summary>
        protected BaseFeedReaderViewModel()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the navigation source.
        /// </summary>
        /// <value>
        /// The navigation source.
        /// </value>
        public string NavigationSource
        {
            get
            {
                return this.navigationSource;
            }

            private set
            {
                this.SetProperty(ref this.navigationSource, value);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Called to determine if this instance can handle the navigation request.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>
        ///   <b>true</b> if this instance accepts the navigation request; otherwise, <b>false</b>.
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Called when the implementer is being navigated away from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// Called when the implementer has been navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            FeedItemViewModel navigationSelectedFeedItem = null;
            if (navigationContext.Parameters.ContainsKey("SelectedFeedItem"))
            {
                navigationSelectedFeedItem = navigationContext.Parameters["SelectedFeedItem"] as FeedItemViewModel;
            }

            if ((navigationSelectedFeedItem == null) ||
                (navigationSelectedFeedItem.Link == null))
            {
                this.LoadHtml(null);
            }
            else
            {
                this.LoadHtml(navigationSelectedFeedItem.Link.ToString());
            }
        }

        /// <summary>
        /// Loads the HTML.
        /// </summary>
        /// <param name="inputUri">The input URI.</param>
        private async void LoadHtml(string inputUri)
        {
            this.NavigationSource =
                "<html><head></head><body><h1>Loading...</h1><br/><h3>Wait a moment, please!</h3></body></html>";

            try
            {
                var rssService = ServiceLocator.Current.GetInstance<IRSSService>();
                var rssTask = rssService.LoadHtml(inputUri);
                rssTask.Start();

                this.NavigationSource = await rssTask;
            }
            catch (Exception exception)
            {
                this.NavigationSource = string.Format(
                    "<html><head></head><body><h1>Load error!</h1><br/><h3>{0}</h3></body></html>",
                    exception.Message);
            }
        }

        #endregion Methods
    }
}