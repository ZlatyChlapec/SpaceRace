using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    public interface IPart
    {
        /// <summary>
        /// Type of module
        /// </summary>
        SpaceShipPartsProduction Type { get; }
        /// <summary>
        /// Points requied for production
        /// </summary>
        int RequiredPoints { get; }
        /// <summary>
        /// hitpoints modifier of module
        /// </summary>
        int HpModifier { get; }
        /// <summary>
        /// speed modifier of module
        /// </summary>
        double SpeedModifier { get; }
        /// <summary>
        /// tells if module is fully produced
        /// </summary>
        bool IsDone { get; set; }
    }

    /// <summary>
    /// Space ship module types
    /// </summary>
    public enum SpaceShipPartsProduction
    {
        None = -1,
        Production,
        Cockpit,
        LifeSupport,
        StasisChamber,
        Engine,
        Thruster,
        Casing
    };
}
