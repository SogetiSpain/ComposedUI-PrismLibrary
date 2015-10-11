// ----------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS
{
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using Prism.Modularity;
    using Prism.Unity;
    using Views;

    /// <summary>
    /// Represents the application bootstrapping sequence.
    /// </summary>
    internal sealed class Bootstrapper : UnityBootstrapper
    {
        #region Methods

        /// <summary>
        /// Creates the module catalog.
        /// </summary>
        /// <returns>
        /// The created module catalog.
        /// </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = "."
            };
        }

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns>
        /// The created shell.
        /// </returns>
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<ShellView>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = this.Shell as Window;
            Application.Current.MainWindow.Show();
        }

        #endregion Methods
    }
}