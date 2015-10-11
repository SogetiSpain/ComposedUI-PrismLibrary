// ----------------------------------------------------------------------------
// <copyright file="QANewsFeedsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Views
{
    using System.Windows.Controls;
    using Microsoft.Practices.Unity.Utility;
    using ViewModels;

    /// <summary>
    /// Interaction logic for the QANewsFeeds view.
    /// </summary>
    internal partial class QANewsFeedsView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsFeedsView"/> class.
        /// </summary>
        public QANewsFeedsView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsFeedsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public QANewsFeedsView(QANewsFeedsViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}