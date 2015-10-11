// ----------------------------------------------------------------------------
// <copyright file="LabsChannelView.xaml.cs" company="SOGETI Spain">
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
    /// Interaction logic for the LabsChannel view.
    /// </summary>
    [ViewSortHint("1")]
    internal partial class LabsChannelView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsChannelView"/> class.
        /// </summary>
        public LabsChannelView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsChannelView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public LabsChannelView(LabsChannelViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}