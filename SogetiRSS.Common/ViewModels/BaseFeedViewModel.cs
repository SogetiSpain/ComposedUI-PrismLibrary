// ----------------------------------------------------------------------------
// <copyright file="BaseFeedViewModel.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using HtmlAgilityPack;
    using Prism.Mvvm;
    using Prism.Regions;

    /// <summary>
    /// Represents an abstract view model for a feed view.
    /// </summary>
    public abstract class BaseFeedViewModel : BindableBase, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Define the feed items.
        /// </summary>
        private ObservableCollection<FeedItemViewModel> feedItems;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFeedViewModel"/> class.
        /// </summary>
        protected BaseFeedViewModel()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the feed items.
        /// </summary>
        /// <value>
        /// The feed items.
        /// </value>
        public ObservableCollection<FeedItemViewModel> FeedItems
        {
            get
            {
                return this.feedItems;
            }

            set
            {
                this.SetProperty(ref this.feedItems, value);
            }
        }

        /// <summary>
        /// Gets the feed.
        /// </summary>
        /// <value>
        /// The feed.
        /// </value>
        protected SyndicationFeed Feed
        {
            get;
            private set;
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
            if (navigationContext.Parameters.ContainsKey("Feed"))
            {
                this.Feed = navigationContext.Parameters["Feed"] as SyndicationFeed;
            }

            if (this.Feed == null)
            {
                this.FeedItems = new ObservableCollection<FeedItemViewModel>();
                return;
            }

            this.FeedItems = new ObservableCollection<FeedItemViewModel>(
                this.Feed.Items.Select(
                    item =>
                    {
                        var htmlSummary = new HtmlDocument();
                        htmlSummary.LoadHtml(item.Summary.Text);

                        return new FeedItemViewModel()
                        {
                            Link = item.Links.Any() ? item.Links.First().Uri : null,
                            PublishDate = item.PublishDate.ToLocalTime().DateTime,
                            Summary = htmlSummary.DocumentNode.InnerText.Replace("[&#8230;]", "[...]"),
                            Title = item.Title.Text
                        };
                    }));
        }

        #endregion Methods
    }
}