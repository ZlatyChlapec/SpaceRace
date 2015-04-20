using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    public interface ISpace
    {
        /// <summary>
        /// Type of space enviroment
        /// </summary>
        SpaceType Type { get; }
        /// <summary>
        /// Damage delt to ship by enviroment
        /// </summary>
        int HPDamage { get; }
        /// <summary>
        /// Speed reduction of enviroment
        /// </summary>
        double SpeedDamage { get; }
    }

    /// <summary>
    /// Space enviroment types
    /// </summary>
    public enum SpaceType
    {
        Empty,
        Dangerous,
        ExtremlyDangerous,
        Anomaly
    };
}
