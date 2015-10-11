// ----------------------------------------------------------------------------
// <copyright file="LabsFeedsView.xaml.cs" company="SOGETI Spain">
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
    /// Interaction logic for the LabsFeeds view.
    /// </summary>
    internal partial class LabsFeedsView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsFeedsView"/> class.
        /// </summary>
        public LabsFeedsView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsFeedsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public LabsFeedsView(LabsFeedsViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}