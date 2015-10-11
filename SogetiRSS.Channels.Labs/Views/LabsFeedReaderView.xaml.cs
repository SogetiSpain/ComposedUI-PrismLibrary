// ----------------------------------------------------------------------------
// <copyright file="LabsFeedReaderView.xaml.cs" company="SOGETI Spain">
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
    /// Interaction logic for the LabsFeedReader view.
    /// </summary>
    internal partial class LabsFeedReaderView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsFeedReaderView"/> class.
        /// </summary>
        public LabsFeedReaderView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabsFeedReaderView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public LabsFeedReaderView(LabsFeedReaderViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}