using System;
using System.Collections.Generic;
using System.Threading;

namespace Coroutine
{
    class Program
    {
        //public LinkedList<string> MainList = new LinkedList<string>();
        public String[] cloth_list = { "안입음", "vertical", "horizontal" };
        public bool retry = false;
        

        public static void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {

                dateTimeNow = DateTime.Now;
            }
            return;
        }


        static void Main(string[] args)
        {

            Program pg = new Program();
            Random ran1 = new Random();
            int RandomNum = ran1.Next(1, 3);


            while (true)
            {
                Console.WriteLine("");

                if (pg.retry == false)
                {
                    Delay(1000);
                    Console.WriteLine("[TS] 아침에~ 옷입을땐~!");
                }
                else
                {
                    Delay(1000);
                    Console.WriteLine("[TS] 또다시~ 옷입을땐~!");
                }
               

                IEnumerator<String> test = GetString();
                test.MoveNext();
                string task1 = test.Current;
  

                Console.WriteLine(task1);

                Delay(3000);
                Console.WriteLine("[TS]나 옷 다입었다!!!");

                //Thread Min = new Thread(Min_Task);
                //Min.Start();

                test.MoveNext();
                string task2 = test.Current;
                Console.WriteLine(task2);

                Delay(1000);
                Console.WriteLine($"[TS] 나 옷 {pg.cloth_list[RandomNum]}입었어...");

                test.MoveNext();
                string task3 = test.Current;
                test.MoveNext();
                string task4 = test.Current;

                if (pg.cloth_list[RandomNum] == task3)
                {
                    Console.WriteLine($"[MIN]나도 {task3} 입었어!! 자 이제 안들키게 따로 출근하자!!");
                    break;
                }
                else
                {
                    Console.WriteLine(task4);
                    pg.retry = true;
                }

            }

        }


        static IEnumerator<string> GetString()
        {
            Program pg = new Program();
            Random ran2 = new Random();
            int RandomNum2 = ran2.Next(1, 3);

            Delay(1000);
            string task1 = "[MIN]니.생.각.이.나~♪";
            yield return task1;

            Delay(5000);
            string task2 = "[MIN]나도 방금 옷 다입음!!!";
            yield return task2;

            Delay(1000);
            string task3 = $"{pg.cloth_list[RandomNum2]}";
            yield return task3;

            Delay(1000);
            string task4 = $"[MIN]난 {pg.cloth_list[RandomNum2]} 입었는데.... 다시 입자...";
            yield return task4;

        }
    }
}