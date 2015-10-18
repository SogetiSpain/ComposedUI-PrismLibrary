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

        /// <summary>
        /// Defiens the feeds title.
        /// </summary>
        private string feedsTitle;

        /// <summary>
        /// Defines the selected feed item.
        /// </summary>
        private FeedItemViewModel selectedFeedItem;

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
        /// Gets the feeds title.
        /// </summary>
        /// <value>
        /// The feeds title.
        /// </value>
        public string FeedsTitle
        {
            get
            {
                return this.feedsTitle;
            }

            private set
            {
                this.SetProperty(ref this.feedsTitle, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected feed item.
        /// </summary>
        /// <value>
        /// The selected feed item.
        /// </value>
        public FeedItemViewModel SelectedFeedItem
        {
            get
            {
                return this.selectedFeedItem;
            }

            set
            {
                if (this.SetProperty(ref this.selectedFeedItem, value))
                {
                    this.OnSelectedFeedItem(this.selectedFeedItem);
                }
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
            SyndicationFeed navigationFeed = null;
            if (navigationContext.Parameters.ContainsKey("Feed"))
            {
                navigationFeed = navigationContext.Parameters["Feed"] as SyndicationFeed;
            }

            this.SelectedFeedItem = null;

            if (navigationFeed == null)
            {
                this.Feed = null;
                this.FeedItems = new ObservableCollection<FeedItemViewModel>();

                return;
            }

            if ((this.Feed == null) ||
                ((this.Feed != null) && (this.Feed.LastUpdatedTime != navigationFeed.LastUpdatedTime)))
            {
                this.Feed = navigationFeed;
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
                this.FeedsTitle = this.Feed.Title.Text;
            }
        }

        /// <summary>
        /// Called when a feed item is selected.
        /// </summary>
        /// <param name="selectedFeedItem">The selected feed item.</param>
        protected abstract void OnSelectedFeedItem(FeedItemViewModel selectedFeedItem);

        #endregion Methods
    }
}