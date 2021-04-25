using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Workers
{
    class Repository
    {
            private Worker[] workers;

            private string path;

            int index; 

            string[] titles; 

            public Repository(string Path)
            {
                this.path = Path;
                this.index = 0;
                this.titles = new string[0]; 
                this.workers = new Worker[1];

                this.Load(); 
            }

          
            private void Resize(bool Flag)
            {
                if (Flag)
                {
                    Array.Resize(ref this.workers, this.workers.Length * 2);
                }
            }

            
            public void Add(Worker ConcreteWorker)
            {
                this.Resize(index >= this.workers.Length);
                this.workers[index] = ConcreteWorker;
                this.index++;
            }

            private void Load()
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    titles = sr.ReadLine().Split(',');


                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');

                        Add(new Worker(args[0], args[1], args[2], Convert.ToUInt32(args[3]), args[4]));
                    }
                }
            }

           
            public void Save(string Path)
            {
                string temp = String.Format("{0},{1},{2},{3},{4}",
                                                this.titles[0],
                                                this.titles[1],
                                                this.titles[2],
                                                this.titles[3],
                                                this.titles[4]);

                File.AppendAllText(Path, $"{temp}\n");

                for (int i = 0; i < this.index; i++)
                {
                    temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.workers[i].FirstName,
                                            this.workers[i].LastName,
                                            this.workers[i].Position,
                                            this.workers[i].Salary,
                                            this.workers[i].Department);
                    File.AppendAllText(Path, $"{temp}\n");
                }
            }

            public void PrintDbToConsole()
            {
                Console.WriteLine($"{this.titles[0],15} {this.titles[1],15} {this.titles[4],15} {this.titles[2],15} {this.titles[3],10}");

                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine(this.workers[i].Print());
                }
            }

       
            public int Count { get { return this.index; } }


    }
}
