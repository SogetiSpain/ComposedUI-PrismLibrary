// ----------------------------------------------------------------------------
// <copyright file="FeedItemViewModel.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.ViewModels
{
    using System;
    using Prism.Mvvm;

    /// <summary>
    /// Represents the view model for a feed item.
    /// </summary>
    public class FeedItemViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Defines the link.
        /// </summary>
        private Uri link;

        /// <summary>
        /// Define the publish date.
        /// </summary>
        private DateTime publishDate;

        /// <summary>
        /// Defines the summary.
        /// </summary>
        private string summary;

        /// <summary>
        /// Defines the title.
        /// </summary>
        private string title;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public Uri Link
        {
            get
            {
                return this.link;
            }

            set
            {
                this.SetProperty(ref this.link, value);
            }
        }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>
        /// The publish date.
        /// </value>
        public DateTime PublishDate
        {
            get
            {
                return this.publishDate;
            }

            set
            {
                this.SetProperty(ref this.publishDate, value);
            }
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        public string Summary
        {
            get
            {
                return this.summary;
            }

            set
            {
                this.SetProperty(ref this.summary, value);
            }
        }

        /// <summary>
        /// Gets or sets the title.
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

            set
            {
                this.SetProperty(ref this.title, value);
            }
        }

        #endregion Properties
    }
}