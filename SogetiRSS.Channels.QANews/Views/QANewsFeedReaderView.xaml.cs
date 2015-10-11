// ----------------------------------------------------------------------------
// <copyright file="QANewsFeedReaderView.xaml.cs" company="SOGETI Spain">
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
    /// Interaction logic for the QANewsFeedReader view.
    /// </summary>
    internal partial class QANewsFeedReaderView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsFeedReaderView"/> class.
        /// </summary>
        public QANewsFeedReaderView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsFeedReaderView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public QANewsFeedReaderView(QANewsFeedReaderViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}