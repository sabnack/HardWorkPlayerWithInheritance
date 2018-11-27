using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class RandomPlayer : Players
    {
        public RandomPlayer()
        {
            Name = "RandomP";
        }

        public override void DoMove()
        {
            int counterPositionOnScreen = 0;

            while (true)
            {
                RandomPlayerHandler.WaitOne();
                
                int Rand = RandomNumber.Next(MinValue, MaxValue);

                AddEnterdNumberInArray(Rand);
                if (Rand == RezultValue)
                {
                    Win = true;
                    EndGame = true;
                }

                Console.SetCursorPosition(20, 9 + counterPositionOnScreen);
                Console.Write("{0,4} {1}", Rand, Thread.CurrentThread.Name);
                counterPositionOnScreen++;

                RandomCleverPlayerHandler.Set();
            }
        }
    }
}
