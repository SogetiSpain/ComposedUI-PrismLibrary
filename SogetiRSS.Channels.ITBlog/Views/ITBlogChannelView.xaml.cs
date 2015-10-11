// ----------------------------------------------------------------------------
// <copyright file="ITBlogChannelView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Views
{
    using System.Windows.Controls;
    using Microsoft.Practices.Unity.Utility;
    using Prism.Regions;
    using ViewModels;

    /// <summary>
    /// Interaction logic for the ITBlogChannel view.
    /// </summary>
    [ViewSortHint("0")]
    internal partial class ITBlogChannelView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ITBlogChannelView"/> class.
        /// </summary>
        public ITBlogChannelView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ITBlogChannelView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ITBlogChannelView(ITBlogChannelViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}