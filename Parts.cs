using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class Casing : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.Casing; }
        }

        public int RequiredPoints
        {
            get { return 300; }
        }

        public int HpModifier
        {
            get { return 5; }
        }

        public double SpeedModifier
        {
            get { return 0; }
        }

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }
    }

    class Cockpit : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.Cockpit; }
        }

        public int RequiredPoints
        {
            get { return 250; }
        }

        public int HpModifier
        {
            get { return 0; }
        }

        public double SpeedModifier
        {
            get { return 0; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }
    }

    class Engine : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.Engine; }
        }

        public int RequiredPoints
        {
            get { return 750; }
        }

        public int HpModifier
        {
            get { return 0; }
        }

        public double SpeedModifier
        {
            get { return 1; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }
    }

    class LifeSupport : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.LifeSupport; }
        }

        public int RequiredPoints
        {
            get { return 250; }
        }

        public int HpModifier
        {
            get { return 0; }
        }

        public double SpeedModifier
        {
            get { return 0; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }
    }

    class StasisChamber : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.StasisChamber; }
        }

        public int RequiredPoints
        {
            get { return 750; }
        }

        public int HpModifier
        {
            get { return 0; }
        }

        public double SpeedModifier
        {
            get { return 0; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }
    }

    class Thruster : IPart
    {
        private bool isDone = false;
        public SpaceShipPartsProduction Type
        {
            get { return SpaceShipPartsProduction.Thruster; }
        }

        public int RequiredPoints
        {
            get { return 400; }
        }

        public int HpModifier
        {
            get { return 0; }
        }

        public double SpeedModifier
        {
            get { return 0.25; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }
    }
}
