using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace CS3230RentalSystemProject.Enums
{
    /// <summary>
    /// Enum Country
    /// </summary>
    public enum Country
    {
        /// <summary>
        ///     If there is no country
        /// </summary>
        /// <summary>
        ///     The none
        /// </summary>
        [Description("None")] None,

        /// <summary>
        ///     The United State
        /// </summary>
        /// <summary>
        ///     The USA
        /// </summary>
        [Description("The United State")] USA
    }
}
