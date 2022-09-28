using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stream_and_directory
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("What u want\n1.Write text and save him\n2.Read text\n3.Top 5 extenions\n4.Exit");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Specify the path, the last will be the name,D:\\.....");
                    SaveText(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Specify the path, the last will be the name,D:\\.....");
                    ReadText(Console.ReadLine());
                    break;
                case 3:
                    Top_5_Extensions(Console.ReadLine());
                    break;
                case 4:
                    break;
                default:
                    Main();
                    break;
            }
        }
        public static void SaveText(string name)
        {
            Console.WriteLine("Write text:");
            string text = Console.ReadLine();
            Console.WriteLine("Coding\n1.UTF8\n2.Win1251\n3. CP 866 DOS");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    StreamWriter sw = new StreamWriter("D:\\" + name + ".txt", true, Encoding.UTF8);
                    sw.WriteLine(text);
                    sw.Close();
                    Console.WriteLine("Save complite UTF8");
                    break;
                case 2:
                    StreamWriter sw2 = new StreamWriter("D:\\" + name + ".txt", true, Encoding.GetEncoding(1251));//20127	US-ASCII	ASCII (США)
                    sw2.WriteLine(text);
                    sw2.Close();
                    Console.WriteLine("Save complite Win1251");
                    break;
                case 3:
                    StreamWriter sw3 = new StreamWriter("D:\\" + name + ".txt", true, Encoding.GetEncoding(866));
                    sw3.WriteLine(text);
                    sw3.Close();
                    Console.WriteLine("Save complite DOS 866");
                    break;
                default:
                    Console.WriteLine("Save dont complite");
                    break;
            }
            Main();
        }
        public static void ReadText(string name)
        {
            try
            {
                Console.WriteLine("Выберите кодировку\n1.UTF8\n2.Win1251\n3. CP 866 DOS");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        StreamReader sr = new StreamReader("D:\\" + name + ".txt", Encoding.UTF8, false);
                        string line;
                        Console.WriteLine("Ваш текст");
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        sr.Close();
                        break;
                    case 2:
                        StreamReader sr2 = new StreamReader("D:\\" + name + ".txt", Encoding.GetEncoding(1251), false);
                        Console.WriteLine("Ваш текст");
                        while ((line = sr2.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        sr2.Close();
                        break;
                    case 3:
                        StreamReader sr3 = new StreamReader("D:\\" + name + ".txt", Encoding.GetEncoding(866), false);
                        Console.WriteLine("Ваш текст");
                        while ((line = sr3.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        sr3.Close();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Main();
            }
        }
        public static void Top_5_Extensions(string n)
        {
            try
            {
                string[] files = (Directory.GetFiles("D:\\" + n, "*.*", SearchOption.TopDirectoryOnly));// get an array of files without subdirectives
                var Files = new string[files.Length];//we create an array 2 in which we put only the end of the files
                for (int i = 0; i < files.Length; i++)// truncate the entire path to permissions
                {
                    Files[i] = files[i].Substring(files[i].Length - 4);
                }
                var dict = new Dictionary<string, int>();//create a collection key value
                foreach (var elem in Files)//we start the cycle of counting the same and count
                {
                    dict.TryGetValue(elem, out int count);
                    dict[elem] = count + 1;
                }
                foreach (var v in dict.Take(5))//search top 5 permissions
                {
                    Console.WriteLine("Extension {0} value {1}", v.Key, v.Value);
                }
            }
            catch//Вопрос почему сжирает 4 мб и как от этого избавиться(из за иключения и работы в нем?)//use if incorrectly write 
            {
                Console.WriteLine("Handled exception");
            }
            finally { Main(); }//used as correct spelling
        }
    }
}


