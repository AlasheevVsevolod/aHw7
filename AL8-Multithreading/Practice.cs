using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Lesson_6_Multithreading
{
    class Practice
    {      
        /// <summary>
        /// LA8.P1/X. Написать консольные часы, которые можно останавливать и запускать с 
        /// консоли без перезапуска приложения.
        /// </summary>
        public static void LA8_P1_5()
        {
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(DateTime.Now);
                    Thread.Sleep(1000);
                }

            });
            t.Start();

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        t.Resume();
                        break;

                    case "2":
                        t.Suspend();
                        break;

                    default:
                        break;
                }

            }
        }


        /// <summary>
        /// LA8.P2/X. Написать консольное приложение, которое “делает массовую рассылку”. 
        /// </summary>
        public static void LA8_P2_5()
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                string file = $@"d:\_hw8\{i}.txt";
                /*File.AppendAllText(file, file);
                Thread.Sleep(rand.Next(1000));*/

                ThreadPool.QueueUserWorkItem((object obj) =>
                {
                    File.AppendAllText(file, file);
                    Thread.Sleep(rand.Next(1000));
                });
            }
        }

        /// <summary>
        /// Написать код, который в цикле (10 итераций) эмулирует посещение 
        /// сайта увеличивая на единицу количество посещений для каждой из страниц.  
        /// </summary>
        public static void LA8_P3_5()
        {            
        }

        /// <summary>
        /// LA8.P4/X. Отредактировать приложение по “рассылке” “писем”. 
        /// Сохранять все “тела” “писем” в один файл. Использовать блокировку потоков, чтобы избежать проблем синхронизации.  
        /// </summary>
        /// 
        public static void LA8_P4_5()
        {
            var obj = new object();
            Random rand = new Random();
            string file = $@"d:\_hw8\0.txt";

            File.Delete(file);

            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() =>
                {
                    lock (obj)
                    {
                        File.AppendAllText(file, $@"d:\_hw8\{i}.txt" + "\n");
                    }
                });

                t.Start();
            }
        }

        /// <summary>
        /// LA8.P5/5. Асинхронная “отсылка” “письма” с блокировкой вызывающего потока 
        /// и информировании об окончании рассылки (вывод на консоль информации 
        /// удачно ли завершилась отсылка). 
        /// </summary>
        public async static void LA8_P5_5()
        {           
        }
    }    
}
