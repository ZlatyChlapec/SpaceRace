using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class EmptySpace : ISpace
    {
        public SpaceType Type
        {
            get { return SpaceType.Empty; }
        }

        public int HPDamage
        {
            get { return 0; }
        }

        public double SpeedDamage
        {
            get { return 0; }
        }
    }

    class DangerousSpace : ISpace
    {
        public SpaceType Type
        {
            get { return SpaceType.Dangerous; }
        }

        public int HPDamage
        {
            get { return 1; }
        }

        public double SpeedDamage
        {
            get { return 0; }
        }
    }

    class ExtremlyDangerousSpace : ISpace
    {
        public SpaceType Type
        {
            get { return SpaceType.ExtremlyDangerous; }
        }

        public int HPDamage
        {
            get { return 2; }
        }

        public double SpeedDamage
        {
            get { return 0.25; }
        }
    }

    class AnomalySpace : ISpace
    {
        public SpaceType Type
        {
            get { return SpaceType.Anomaly; }
        }

        public int HPDamage
        {
            get { return 0; }
        }

        public double SpeedDamage
        {
            get { return 10; }
        }
    }
}
