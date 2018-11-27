using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HardWorkPlayerWithInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData(out int Min, out int Max, out int Rand);
            Players.SetMinMaxRandValue(Min, Max, Rand);
            Players[] PlayersArray = new Players[5];
            SetPlayers(PlayersArray);

            Console.WriteLine("Загаданное число");
            Console.WriteLine(Rand + "\n");

       //     PrintNames(PlayersArray);
            GameWithThread(PlayersArray);
            Console.WriteLine("\n");
            PrintWinner(PlayersArray);
        }

        static void GameWithThread(Players[] playersArray)
        {
            Thread[] PlayersThreadArray = new Thread[5];

            for (var i = 0; i < playersArray.Length; i++)
            {
                PlayersThreadArray[i] = new Thread(playersArray[i].DoMove)
                {
                    Name = playersArray[i].Name
                };

                PlayersThreadArray[i].Start();
            }

            PlayersThreadArray[4].Join();

            for (var i = 0; i < playersArray.Length; i++)
            {
                PlayersThreadArray[i].Abort();
            }
            //Thread HardWorkingThread = new Thread(playersArray[0].DoMove)
            //{
            //    Name = playersArray[0].Name
            //};
            //HardWorkingThread.Start();

            //Thread RandomThread = new Thread(playersArray[1].DoMove)
            //{
            //    Name = playersArray[1].Name
            //};
            //RandomThread.Start();

            //Thread RandomCleverThread = new Thread(playersArray[2].DoMove)
            //{
            //    Name = playersArray[2].Name
            //};
            //RandomCleverThread.Start();

            //Thread RandomCheaterThread = new Thread(playersArray[3].DoMove)
            //{
            //    Name = playersArray[3].Name
            //};
            //RandomCheaterThread.Start();

            //Thread HardWorkingCheaterThread = new Thread(playersArray[4].DoMove)
            //{
            //    Name = playersArray[4].Name
            //};
            //HardWorkingCheaterThread.Start();
            //HardWorkingCheaterThread.Join();

            //Console.WriteLine();
            //Console.WriteLine(HardWorkingThread.Name + " " + HardWorkingThread.ThreadState);
            //Console.WriteLine(RandomThread.Name + " " + RandomThread.ThreadState);
            //Console.WriteLine(RandomCleverThread.Name + " " + RandomCleverThread.ThreadState);
            //Console.WriteLine(RandomCheaterThread.Name + " " + RandomCheaterThread.ThreadState);
            //Console.WriteLine(HardWorkingCheaterThread.Name + " " + HardWorkingCheaterThread.ThreadState);

            //HardWorkingThread.Abort();
            //RandomThread.Abort();
            //RandomCleverThread.Abort();
            //RandomCheaterThread.Abort();
        }

        static void Game(Players[] playersArray)
        {
            do
            {
                for (var i = 0; i < playersArray.Length; i++)
                {
                    playersArray[i].DoMove();
                    //Console.Write("     " + playersArray[i].DoMove() + "       ");
                }
                Console.WriteLine();
            } while (!playersArray[0].Win && !playersArray[1].Win && !playersArray[2].Win && !playersArray[3].Win && !playersArray[4].Win);
        }

        static void PrintNames(Players[] playersArray)
        {
            for (var i = 0; i < playersArray.Length; i++)
            {
                Console.Write(playersArray[i].Name + "  ");
            }
            Console.WriteLine();
        }

        static void PrintWinner(Players[] playersArray)
        {
            for (var i = 0; i < playersArray.Length; i++)
            {
                if (playersArray[i].Win)
                    Console.WriteLine("Выиграл " + playersArray[i].Name);
            }
        }

        static void SetPlayers(Players[] playersArray)
        {
            playersArray[0] = new HardWorkingPlayer();
            playersArray[1] = new RandomPlayer();
            playersArray[2] = new RandomCleverPlayer();
            playersArray[3] = new RandomCheaterPlayer();
            playersArray[4] = new HardWorkingCheaterPlayer();
        }

        static void InputData(out int Min, out int Max, out int Rand)
        {
            do
            {
                do
                {
                    Console.WriteLine("Введите минимальное число больше 0");
                }
                while (!int.TryParse(Console.ReadLine(), out Min));
            } while (Min < 1);

            do
            {
                do
                {
                    Console.WriteLine("Введите максимальное число в диапазоне от 5 до 1000");
                }
                while (!int.TryParse(Console.ReadLine(), out Max));
            } while (Max < 5 || Max > 1000);

            Rand = Players.RandomNumber.Next(Min, Max);
        }
    }
}
