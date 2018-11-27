using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class RandomCleverPlayer : Players
    {
        public RandomCleverPlayer()
        {
            Name = "RandomCleverP";
            EnteredNumberLocal = new int[0];
        }

        public override void DoMove()
        {
            int counterPositionOnScreen = 0;

            while (true)
            {
                RandomCleverPlayerHandler.WaitOne();

                int Rand = RandomNumber.Next(MinValue, MaxValue);

                for (var i = 0; i < EnteredNumberLocal.Length; i++)
                {
                    if (Rand == EnteredNumberLocal[i])
                    {
                        Rand = RandomNumber.Next(MinValue, MaxValue);
                        i = -1;
                    }
                }

                AddEnterdNumberInLocalArray(Rand);
                AddEnterdNumberInArray(Rand);

                if (Rand == RezultValue)
                {
                    Win = true;
                    EndGame = true;
                }

                Console.SetCursorPosition(35, 9 + counterPositionOnScreen);
                Console.Write("{0,4} {1}", Rand, Thread.CurrentThread.Name);
                counterPositionOnScreen++;

                RandomCheaterPlayerHandler.Set();
            }
        }
    }
}
