using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class HardWorkingCheaterPlayer : Players
    {
        private int LastMove;

        public HardWorkingCheaterPlayer()
        {
            Name = "HardWorkingCheaterP";
            EnteredNumberLocal = new int[0];
        }

        public override void DoMove()
        {
            int counterPositionOnScreen = 0;

            while (true)
            {
                HardWorkingCheaterPlayerHandler.WaitOne();

                if (EnteredNumberLocal.Length == 0)
                {
                    LastMove = MinValue;
                    while (TestEnterdNumberInArray(LastMove))
                    {
                        LastMove++;
                    }
                    AddEnterdNumberInLocalArray(LastMove);
                    AddEnterdNumberInArray(LastMove);
                }
                else
                {
                    LastMove++;
                    for (var i = 0; i < EnteredNumberLocal.Length; i++)
                    {
                        if (LastMove == EnteredNumberLocal[i])
                        {
                            LastMove++;
                            i = -1;
                        }
                    }
                    while (TestEnterdNumberInArray(LastMove))
                    {
                        LastMove++;
                    }
                    AddEnterdNumberInLocalArray(LastMove);
                    AddEnterdNumberInArray(LastMove);
                }

                if (LastMove == RezultValue)
                {
                    Win = true;
                    EndGame = true;
                }
                Console.SetCursorPosition(75, 9 + counterPositionOnScreen);
                Console.Write("{0,4} {1}", LastMove, Thread.CurrentThread.Name);
                counterPositionOnScreen++;

                if (EndGame)
                    break;

                HardPlayerHandler.Set();
            }
        }
    }
}
