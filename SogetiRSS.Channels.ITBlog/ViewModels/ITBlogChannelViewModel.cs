// ----------------------------------------------------------------------------
// <copyright file="ITBlogChannelViewModel.cs" company="SOGETI Spain">
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
    /// Represents the view model for the ITBlogChannel view.
    /// </summary>
    internal class ITBlogChannelViewModel : BaseChannelViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ITBlogChannelViewModel"/> class.
        /// </summary>
        public ITBlogChannelViewModel()
            : base("http://itblogsogeti.com/feed")
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Executes the selected channel command.
        /// </summary>
        protected override void ExecuteSelectedChannelCommand()
        {
            GlobalCommands.ChannelSelectedCommand.Execute(ChannelNames.ITBlog);
        }

        /// <summary>
        /// Called when a channel is selected.
        /// </summary>
        /// <param name="selectedChannelName">The name of the selected channel.</param>
        protected override void OnSelectedChannel(string selectedChannelName)
        {
            if (selectedChannelName != ChannelNames.ITBlog)
            {
                this.IsChecked = false;
                return;
            }

            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("Feed", this.Feed);
            regionManager.RequestNavigate(
                RegionNames.RSSFeeds,
                new Uri(typeof(ITBlogFeedsView).Name, UriKind.Relative),
                navigationParameters);
        }

        #endregion Methods
    }
}