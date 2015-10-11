// ----------------------------------------------------------------------------
// <copyright file="QANewsChannelView.xaml.cs" company="SOGETI Spain">
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
    /// Interaction logic for the QANewsChannel view.
    /// </summary>
    [ViewSortHint("2")]
    internal partial class QANewsChannelView : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsChannelView"/> class.
        /// </summary>
        public QANewsChannelView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QANewsChannelView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public QANewsChannelView(QANewsChannelViewModel viewModel)
            : this()
        {
            Guard.ArgumentNotNull(viewModel, "viewModel");
            this.DataContext = viewModel;
        }

        #endregion Constructors
    }
}