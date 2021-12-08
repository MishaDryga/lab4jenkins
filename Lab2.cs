using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Lab2
{
    public class Lab2
    {
        private static string filePath = Directory.GetCurrentDirectory() + @"\TextFile1.txt";
        
        public static void Main(string[] args)
        {
            
            bool Swither = true;
            while (Swither)
            {
                Console.WriteLine("\nChoose the operation :\n 1-Reading \n 2-Search \n 3-Delete \n 4-Add \n 5-Save \n 0-Finish \n");
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '1':
                        {
                            Console.WriteLine("\nReading\n");
                            Reading(filePath);
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine("\nSearch\n");
                            Search();
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("\nDelete\n");
                            Delete(filePath);
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("\nAdd\n");
                            Console.WriteLine("Enter some new data: ");
                            string new_numb = Console.ReadLine();
                            Add(new_numb);
                            break;
                        }
                    case '5':
                        {
                            Console.WriteLine("\nSave\n");
                            Save(filePath);
                            break;
                        }
                    case '0':
                        {
                            Console.WriteLine("Finish");
                            Swither = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Try again\n");
                            return;
                        }
                }
            }


        }
        public static Stack<string> stack = new Stack<string>();

        public static void Reading(string path)
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                string[] str = text.Replace("\r\n", " ").Split();
                for (int i = 0; i < str.Length; ++i)
                {
                    stack.Push(str[i] + " ");
                }
                Console.WriteLine("====Original file===");
                foreach (var item in stack)
                    Console.Write(item);
            }
            else
            {
                Console.WriteLine("File not exists. Please create a new file before reads it");
            }
        }


        public static void Search()
        {
            Console.WriteLine("Enter some numb: ");
            string a = Console.ReadLine();
            
            if (stack.Contains(a + " "))
            {
                Console.WriteLine("Element is found...!!");
            }
            else
            {
                Console.WriteLine("Element is not found...!!");
            }
        }

        public static void Delete(string path)
        {
           stack.Clear();
           Console.WriteLine("\nTotal elements present in stack: {0}\n", stack.Count);
            foreach (string s in stack)
                Console.Write(s);
            File.WriteAllText(path, "");
        }

        public static void Save(string path)
        {
            Console.WriteLine("\n\n===Write to file===");
            string txt = string.Join(" ", stack);
            File.WriteAllText(path, txt);
        }

        public static void Add(string newNumber)
        {
            stack.Push(newNumber + " ");
            Console.WriteLine("====Original file===");
            foreach (var item in stack)
                Console.Write(item + " ");
        }
    }
}
