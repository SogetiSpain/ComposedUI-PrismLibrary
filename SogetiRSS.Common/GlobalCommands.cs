// ----------------------------------------------------------------------------
// <copyright file="GlobalCommands.cs" company="SOGETI Spain">
//     Copyright © 2015 SOGETI Spain. All rights reserved.
//     Build user interfaces with Prism by Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiRSS
{
    using Prism.Commands;

    /// <summary>
    /// Represents the global commands.
    /// </summary>
    public class GlobalCommands
    {
        #region Fields

        /// <summary>
        /// Defines the channel selected command.
        /// </summary>
        private static CompositeCommand channelSelectedCommand = new CompositeCommand();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the channel selected command.
        /// </summary>
        /// <value>
        /// The channel selected command.
        /// </value>
        public static CompositeCommand ChannelSelectedCommand
        {
            get
            {
                return GlobalCommands.channelSelectedCommand;
            }
        }

        #endregion Properties
    }
}