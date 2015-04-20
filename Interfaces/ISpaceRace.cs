using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    public interface ISpaceRace
    {
        /// <summary>
        /// Function processing "next turn" command
        /// </summary>
        void Turn();
        /// <summary>
        /// Function processing any "launch" command
        /// </summary>
        void Launch();
        /// <summary>
        /// Function processing any production command
        /// </summary>
        /// <param name="type">Module to produce</param>
        void Production(SpaceShipPartsProduction type);
    }
}
