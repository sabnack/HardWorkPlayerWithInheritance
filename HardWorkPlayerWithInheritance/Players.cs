using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    abstract class Players
    {
        public static Random RandomNumber = new Random();
        protected static int[] EnteredNumber { get; private set; }
        protected static int MinValue { get; private set; }
        protected static int MaxValue { get; private set; }
        public string Name { get; set; }
        protected static int RezultValue { get; private set; }
        public bool Win { get; set; }
        protected static bool EndGame { get; set; }
        protected int[] EnteredNumberLocal { get; set; }

        protected static EventWaitHandle HardPlayerHandler = new AutoResetEvent(true);
        protected static EventWaitHandle RandomPlayerHandler = new AutoResetEvent(false);
        protected static EventWaitHandle RandomCleverPlayerHandler = new AutoResetEvent(false);
        protected static EventWaitHandle RandomCheaterPlayerHandler = new AutoResetEvent(false);
        protected static EventWaitHandle HardWorkingCheaterPlayerHandler = new AutoResetEvent(false);

        public abstract void DoMove();

        public static void SetMinMaxRandValue(int min, int max, int rnd)
        {
            MinValue = min;
            MaxValue = max;
            RezultValue = rnd;
            EnteredNumber = new int[0];
        }

        protected void AddEnterdNumberInArray(int number)
        {
            if (!TestEnterdNumberInArray(number))
            {
                int[] tmpArray = new int[EnteredNumber.Length + 1];
                for (var i = 0; i < EnteredNumber.Length; i++)
                {
                    tmpArray[i] = EnteredNumber[i];
                }
                tmpArray[EnteredNumber.Length] = number;
                EnteredNumber = tmpArray;
            }
        }

        protected bool TestEnterdNumberInArray(int number)
        {
            for (var i = 0; i < EnteredNumber.Length; i++)
            {
                if (number == EnteredNumber[i])
                {
                    return true;
                }
            }
            return false;
        }

        protected void AddEnterdNumberInLocalArray(int number)
        {
            int[] tmpArray = new int[EnteredNumberLocal.Length + 1];

            for (var i = 0; i < EnteredNumberLocal.Length; i++)
            {
                tmpArray[i] = EnteredNumberLocal[i];
            }

            tmpArray[EnteredNumberLocal.Length] = number;
            EnteredNumberLocal = tmpArray;
        }
    }
}
