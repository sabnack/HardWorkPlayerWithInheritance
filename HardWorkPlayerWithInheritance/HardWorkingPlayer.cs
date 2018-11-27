using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class HardWorkingPlayer : Players
    {
        private int LastMove;


        public HardWorkingPlayer()
        {
            Name = "HardWorkingP";
        }

        public override void DoMove()
        {
            int counterPositionOnScreen = 0;

            while (true)
            {
                HardPlayerHandler.WaitOne();

                if (LastMove == 0)
                {
                    LastMove = MinValue;
                    AddEnterdNumberInArray(LastMove);
                }
                else
                {
                    LastMove++;
                    AddEnterdNumberInArray(LastMove);
                }

                if (LastMove == RezultValue)
                {
                    Win = true;
                    EndGame = true;
                }

                Console.SetCursorPosition(0, 9 + counterPositionOnScreen);
                Console.Write("{0,4} {1}", LastMove, Thread.CurrentThread.Name);
                counterPositionOnScreen++;

                RandomPlayerHandler.Set();
            }
        }
    }
}
