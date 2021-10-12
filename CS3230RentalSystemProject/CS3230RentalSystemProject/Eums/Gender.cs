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
    public enum Gender
    {
        /// <summary>
        ///     Male
        /// </summary>
        /// <summary>
        ///     The Male
        /// </summary>
        [Description("Male")] Male,

        /// <summary>
        ///     Female
        /// </summary>
        /// <summary>
        ///     The Female
        /// </summary>
        [Description("Female")] Female
    }
}
