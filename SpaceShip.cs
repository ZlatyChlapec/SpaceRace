using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class SpaceShip : ISpaceShip
    {
        private int hp = 0;
        private double speed = 0;
        private double basicSpeed = 0;
        private List<IPart> parts = new List<IPart>();

        public int HP
        {
            get { return hp; }
            set { this.hp = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { this.speed = value; }
        }

        public double BasicSpeed
        {
            get { return basicSpeed; }
            set { this.basicSpeed = value; }
        }

        public List<IPart> Parts
        {
            get { return parts; }
            set { this.parts = value; }
        }
    }
}
