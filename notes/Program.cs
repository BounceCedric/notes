using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string version = "1.0";
            bool running = true;
            string input;

            Console.WriteLine("Welcome to Notes " + version + "\n");
            Console.Title = "Notes " + version;

            while (running)
            {
                print_help();
                input = Console.ReadLine();
                string[] words = Regex.Split(input, @"\s+");

                words[0] = words[0].ToLower();

                switch (words[0])
                {
                    
                    case "help":
                        Console.Clear();
                        break;
                    case "make":
                        make_note(words);
                        break;
                    case "exit":
                        running = false;
                        break;
                    case "e":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("'" + input + "' is not recognized");
                        break;
                }
            }
        }
        static void print_help()
        {
            Console.WriteLine("Use 'make' to make a new note");
            Console.WriteLine("Use 'help' to show this list");
            Console.WriteLine("Use 'exit' to exit the program");
            Console.WriteLine();
        }
        static void make_note(string[] words)
        {
            try
            {
                create_note note = new create_note(words[1], words[2], words[3]);
            }
            catch
            {
                create_note note = new create_note();
            }

        }
    }
}
