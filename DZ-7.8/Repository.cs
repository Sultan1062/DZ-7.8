using DZ_7._8;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    public class Repository
    {
        static void Main(string filePath)
        //static public Worker[] GetAllWorkers(string filePath)
        {
            Console.WriteLine("Работники");

            string choiseResult = Console.ReadLine();

            if (choiseResult == "A")
            {
                Worker[] workers = GetAllWorkers(filePath);
                Console.ReadKey();
            }
            else if (choiseResult == "B")
            {
                GetWorkerById(filePath);
                Console.ReadKey();
            }
            else if (choiseResult == "C")
            {
                DeleteWorker(filePath);
            }
            else if (choiseResult == "D")
            {
                AddWorker(filePath);
            }
            if (choiseResult == "E")
            {
                Console.Write("Введите для сортировку данных");
                DateTime dateFrom = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите дату чтобы закончить сортировку данных");
                DateTime dateTo = DateTime.Parse(Console.ReadLine());

                GetWorkersBetweenTwoDates(filePath, dateFrom, dateTo);
                Console.ReadKey();
            }
            static Worker[] GetAllWorkers(string filePath)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    Worker[] workers = new Worker[lines.Length];
                    int i = 0;
                    for (i = 0; i < lines.Length; i++)
                    {
                        string[] items = lines[i].Split('\t', '#', ' ');
                        workers[i] = BuildWorker(items);
                        Console.WriteLine(workers[i].InfoWorker());
                    }
                    return workers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oшибka :" + ex.Message);
                }
                return null;
            }
        }
            static Worker GetWorkerById(string filePath)
            {
                try
                {
                    Console.WriteLine("Введите нужный Id: ");
                    int targetId = Int32.Parse(Console.ReadLine());

                    string[] lines = File.ReadAllLines(filePath);
                    Worker[] workers = new Worker[lines.Length];
                    int i = 0;

                    for (i = 0; i < lines.Length; i++)
                    {
                        string[] items = lines[i].Split('\t', '#', ' ');

                        workers[i] = BuildWorker(items);
                    }
                    Worker wrk = (Worker)workers.First(w => w.Id == targetId);
                    Console.WriteLine(wrk.InfoWorker());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oшибka :" + ex.Message);
                }
            }

            static void DeleteWorker(string filePath)
            {
                try
                {
                    Console.WriteLine("Bведите Id для удаления: ");
                    int idDel = Int32.Parse(Console.ReadLine());

                    string[] lines = File.ReadAllLines(filePath);
                    Worker[] workers = new Worker[lines.Length];
                    int i = 0;

                    for (i = 0; i < lines.Length; i++)
                    {
                        string[] items = lines[i].Split('\t', '#', ' ');

                        workers[i] = BuildWorker(items);
                    }
                    Worker wrk = (Worker)workers.First(w => w.Id == idDel);
                    var cleared = workers.Except(wrk);
                    foreach (var v in cleared)
                    {
                        Console.WriteLine(v.InfoWorker());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oшибka :" + ex.Message);
                }
            }
        static Worker BuildWorker(string[] items)
        {
            Worker newWorker = new Worker();
            try
            {
                newWorker.Id = Int32.Parse(items[0].Split(':')[1]);
                newWorker.FullName = items[1].Split(':')[1];
                newWorker.Age = Int32.Parse(items[2].Split(':')[1]);
                newWorker.Height = Int32.Parse(items[3].Split(':')[1]);
                newWorker.BirthDate = DateTime.Parse(items[4].Split(':')[1]);
                newWorker.BirthPlace = items[5].Split(':')[1];
                newWorker.BirthDate = DateTime.Parse(items[6].Split(':')[1]);
                return newWorker;
            }
            catch (Exception ex)
            {
            }
            return newWorker;
        }
            static void AddWorker(string filePath)
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    try
                    {
                        Worker newWorker = new Worker();

                        Console.Write("Bведите ID: ");
                        int Id = Int32.Parse(Console.ReadLine());
                        newWorker.Id = Id;

                        Console.Write("Введите Ф.И.O.: ");
                        string FullName = Console.ReadLine();
                        newWorker.FullName = FullName;

                        Console.Write("Введите возраст: ");
                        int Age = Int32.Parse(Console.ReadLine());
                        newWorker.Age = Age;

                        Console.Write("Bведите рост: ");
                        int Height = Int32.Parse(Console.ReadLine());
                        newWorker.Height = Height;

                        Console.Write("Введите дату рождения: ");
                        DateTime BirthDate = DateTime.Parse(Console.ReadLine());
                        newWorker.BirthDate = BirthDate;

                        Console.Write("Введите место рождения: ");
                        string Birthplace = Console.ReadLine();
                        newWorker.BirthPlace = Birthplace;

                        DateTime RecordDate = DateTime.Now;
                        newWorker.RecordDate = RecordDate;

                        string s = newWorker.InfoWorker();
                        string workerData = s;

                        writer.WriteLine(workerData);
                        writer.Flush();

                        Console.ReadKey();
                    }
                }
            }

                static Worker[] GetWorkersBetweenTwoDates(string filePath, DateTime, dateFrom, DateTime dateTo)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        Worker[] workers = new Worker[lines.Length];
                        int i = 0;

                        for (i = 0; i < lines.Length; i++)
                        {
                            string[] items = lines[i].Split('\t', '#', ' ');
                            workers[i] = BuildWorker(items);
                        }
                        var filtered = workers.Where(w => ((w.RecordDate > dateFrom) & (w.RecordDate < dateTo)));
                        foreach (var fil in filtered)
                        {
                            Console.WriteLine(fil.InfoWorker());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ошибка :" + ex.Message);
                    }
                }
           
     
    }
}
        
    
                

