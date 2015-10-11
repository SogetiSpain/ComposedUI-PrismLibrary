// ----------------------------------------------------------------------------
// <copyright file="QANewsModule.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Utility;
    using Prism.Modularity;
    using Prism.Regions;
    using Views;

    /// <summary>
    /// Represents the Prism module.
    /// </summary>
    public class QANewsModule : IModule
    {
        #region Filds

        /// <summary>
        /// Defines the container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// Defines the region manager.
        /// </summary>
        private readonly IRegionManager regionManager;

        #endregion Filds

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsModule" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public QANewsModule(IUnityContainer container, IRegionManager regionManager)
        {
            Guard.ArgumentNotNull(container, "container");
            Guard.ArgumentNotNull(regionManager, "regionManager");

            this.container = container;
            this.regionManager = regionManager;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.RSSChannels, typeof(QANewsChannelView));

            this.container.RegisterType<object, QANewsFeedReaderView>("QANewsFeedReaderView");
            this.container.RegisterType<object, QANewsFeedsView>("QANewsFeedsView");
        }

        #endregion Methods
    }
}