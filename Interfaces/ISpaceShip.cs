using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    interface ISpaceShip
    {
        /// <summary>
        /// Ship hitpoints
        /// </summary>
        int HP { get; set; }
        /// <summary>
        /// Ship speed
        /// </summary>
        double Speed { get; set; }
        /// <summary>
        /// Starting ship speed
        /// </summary>
        double BasicSpeed { get; set; }
        /// <summary>
        /// List of ship modules
        /// </summary>
        List<IPart> Parts { get; set; }
    }
}
