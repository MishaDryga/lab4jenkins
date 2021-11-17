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
        public static void Main(string[] args)
        {
            
            bool Swither = true;
            while (Swither == true)
            {
                Console.WriteLine("\nChoose the operation :\n 1-Reading \n 2-Search \n 3-Delete \n 4-Add \n 5-Save \n 0-Finish \n");
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '1':
                        {
                            Console.WriteLine("\nReading\n");
                            Reading(@"C:\Users\Mkarlos\source\repos\Lab2\TextFile1.txt");
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
                            Delete();
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
                            Save();
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


        public static void Search()
        {
            Console.WriteLine("Enter some numb: ");
            string a = Console.ReadLine();
            if (stack.Contains(a+" "))
            {
                Console.WriteLine("Element is found...!!");
            }

            else
            {
                Console.WriteLine("Element is not found...!!");
            }
            return;
        }

        public static void Delete()
        {
           stack.Clear();
           Console.WriteLine("\nTotal elements present in " + 
               "stack: {0}\n", stack.Count);
            foreach (string s in stack)
                Console.Write(s);
            File.WriteAllText(@"C:\Users\Mkarlos\source\repos\Lab2\TextFile1.txt", "");
        }

        public static void Save()
        {
            Console.WriteLine("\n\n===Write to file===");
            string txt = string.Join(" ", stack);
            File.WriteAllText(@"C:\Users\Mkarlos\source\repos\Lab2\TextFile1.txt", txt);
        }

        public static void Add(string new_numb)
        {
            stack.Push(new_numb + " ");
            Console.WriteLine("====Original file===");
            foreach (var item in stack)
                Console.Write(item + " ");

        }
    }
}
