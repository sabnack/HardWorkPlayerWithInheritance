using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class RandomCheaterPlayer:Players
    {
        public RandomCheaterPlayer()
        {
            Name = "RandomCheaterP";
        }

        public override void DoMove()
        {
            int counterPositionOnScreen = 0;

            while (true)
            {
                RandomCheaterPlayerHandler.WaitOne();

                int Rand = RandomNumber.Next(MinValue, MaxValue);

                while (TestEnterdNumberInArray(Rand))
                {
                    Rand = RandomNumber.Next(MinValue, MaxValue);
                }

                AddEnterdNumberInArray(Rand);

                if (Rand == RezultValue)
                {
                    Win = true;
                    EndGame = true;
                }

                Console.SetCursorPosition(55, 9 + counterPositionOnScreen);
                Console.Write("{0,4} {1}", Rand, Thread.CurrentThread.Name);
                counterPositionOnScreen++;

                HardWorkingCheaterPlayerHandler.Set();
            }
        }

    }
}
