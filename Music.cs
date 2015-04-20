using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class Music
    {
        public void Play()
        {
            while (true)
            {
                Beep(440,500);
                Beep(440,500);
                Beep(440,500);
                Beep(349,350);
                Beep(523,150);

                Beep(440,500);
                Beep(349,350);
                Beep(523,150);
                Beep(440,1000);

                Beep(659,500);
                Beep(659,500);
                Beep(659,500);
                Beep(698,350);
                Beep(523,150);

                Beep(415,500);
                Beep(349,350);
                Beep(523,150);
                Beep(440,1000);

                Beep(880,500);
                Beep(440,350);
                Beep(440,150);
                Beep(880,500);
                Beep(830,250);
                Beep(784,250);

                Beep(740,125);
                Beep(698,125);
                Beep(740,250);

                Beep(455,250);
                Beep(622,500);
                Beep(587,250);
                Beep(554,250);

                Beep(523,125);
                Beep(466,125);
                Beep(523,250);

                Beep(349,125);
                Beep(415,500);
                Beep(349,375);
                Beep(440,125);

                Beep(523,500);
                Beep(440,375);
                Beep(523,125);
                Beep(659,1000);

                Beep(880,500);
                Beep(440,350);
                Beep(440,150);
                Beep(880,500);
                Beep(830,250);
                Beep(784,250);

                Beep(740,125);
                Beep(698,125);
                Beep(740,250);

                Beep(455,250);
                Beep(622,500);
                Beep(587,250);
                Beep(554,250);

                Beep(523,125);
                Beep(466,125);
                Beep(523,250);

                Beep(349, 250);
                Beep(415,500);
                Beep(349,375);
                Beep(523,125);

                Beep(440,500);
                Beep(349,375);
                Beep(261,125);
                Beep(440,1000);
            }
        }

        private static void Beep(double p1, int p2)
        {
            Console.Beep((int)p1, (int)p2);
        }
    }
}
