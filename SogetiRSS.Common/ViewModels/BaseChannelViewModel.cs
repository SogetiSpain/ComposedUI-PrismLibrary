// ----------------------------------------------------------------------------
// <copyright file="BaseChannelViewModel.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.ViewModels
{
    using System;
    using System.ServiceModel.Syndication;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity.Utility;
    using Prism.Commands;
    using Prism.Mvvm;
    using Services;

    /// <summary>
    /// Represents an abstract view model for a channel view.
    /// </summary>
    public abstract class BaseChannelViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Defines the channel selected command.
        /// </summary>
        private DelegateCommand<string> channelSelectedCommand;

        /// <summary>
        /// Defines the description;
        /// </summary>
        private string description;

        /// <summary>
        /// Defines the value indicating whether this instance is checked.
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Defines the value indicating whether this instance is enabled.
        /// </summary>
        private bool isEnabled;

        /// <summary>
        /// Defines the last updated.
        /// </summary>
        private string lastUpdated;

        /// <summary>
        /// Defines the title.
        /// </summary>
        private string title;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChannelViewModel" /> class.
        /// </summary>
        /// <param name="rssUri">The RSS URI.</param>
        protected BaseChannelViewModel(string rssUri)
        {
            this.Title = "Loading...";
            this.LastUpdated = "Wait a moment, please!";
            this.LoadSyndicationFeed(rssUri);

            this.channelSelectedCommand = new DelegateCommand<string>(
                selectedChannelName => this.OnSelectedChannel(selectedChannelName));

            GlobalCommands.ChannelSelectedCommand.RegisterCommand(
                this.channelSelectedCommand);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                this.SetProperty(ref this.description, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value>
        ///   <b>true</b> if this instance is checked; otherwise, <b>false</b>.
        /// </value>
        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }

            set
            {
                if (this.SetProperty(ref this.isChecked, value) && this.isChecked)
                {
                    this.ExecuteSelectedChannelCommand();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <b>true</b> if this instance is enabled; otherwise, <b>false</b>.
        /// </value>
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.SetProperty(ref this.isEnabled, value);
            }
        }

        /// <summary>
        /// Gets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public string LastUpdated
        {
            get
            {
                return this.lastUpdated;
            }

            private set
            {
                this.SetProperty(ref this.lastUpdated, value);
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.SetProperty(ref this.title, value);
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
        /// Executes the selected channel command.
        /// </summary>
        protected abstract void ExecuteSelectedChannelCommand();

        /// <summary>
        /// Called when a channel is selected.
        /// </summary>
        /// <param name="selectedChannelName">The name of the selected channel.</param>
        protected abstract void OnSelectedChannel(string selectedChannelName);

        /// <summary>
        /// Loads the syndication feed.
        /// </summary>
        /// <param name="rssUri">The RSS URI.</param>
        private async void LoadSyndicationFeed(string rssUri)
        {
            Guard.ArgumentNotNullOrEmpty(rssUri, "rssUri");

            try
            {
                var rssService = ServiceLocator.Current.GetInstance<IRSSService>();
                var rssTask = rssService.LoadSyndicationFeed(rssUri);
                rssTask.Start();

                this.Feed = await rssTask;
                this.IsEnabled = true;
            }
            catch (Exception exception)
            {
                this.IsEnabled = false;
                this.Feed = new SyndicationFeed(
                    rssUri, exception.Message, null)
                {
                    LastUpdatedTime = DateTime.UtcNow
                };
            }

            this.Title = this.Feed.Title.Text;
            this.Description = this.Feed.Description.Text;

            var feedLastUpdated = this.Feed.LastUpdatedTime.ToLocalTime().DateTime;
            this.LastUpdated = $"Last updated {feedLastUpdated:MMMM d, yyyy}";
        }

        #endregion Methods
    }
}