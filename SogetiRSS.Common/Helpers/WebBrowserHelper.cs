// ----------------------------------------------------------------------------
// <copyright file="WebBrowserHelper.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS.Helpers
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Represents the helper for the web browser control.
    /// </summary>
    public static class WebBrowserHelper
    {
        #region Fields

        /// <summary>
        /// Defines the navigation source property.
        /// </summary>
        public static readonly DependencyProperty NavigationSourceProperty =
            DependencyProperty.RegisterAttached(
                "NavigationSource",
                typeof(string),
                typeof(WebBrowserHelper),
                new UIPropertyMetadata(null, WebBrowserHelper.OnNavigationSourcePropertyChanged));

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the navigation source.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>
        /// The navigation source.
        /// </returns>
        public static string GetNavigationSource(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(WebBrowserHelper.NavigationSourceProperty);
        }

        /// <summary>
        /// Sets the navigation source.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value.</param>
        public static void SetNavigationSource(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(WebBrowserHelper.NavigationSourceProperty, value);
        }

        /// <summary>
        /// Called when the navigation source property changed.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnNavigationSourcePropertyChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString((string)e.NewValue);
            }
        }

        #endregion Methods
    }
}