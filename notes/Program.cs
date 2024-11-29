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

            Console.WriteLine("Welcome to Ultra lightweight Notes " + version);
            Console.Title = "ULN " + version;
            Directory.CreateDirectory("notes");

            while (running)
            {
                print_help();
                input = Console.ReadLine();
                string[] words = Regex.Split(input, @"\s+");

                if (words[0] == "make")
                {
                    for (int i = 2; i < words.Length; i++)
                    {
                        words[1] = words[1] + " " + words[i];
                    }
                }

                words[0] = words[0].ToLower();

                switch (words[0])
                {
                    
                    case "help":
                        Console.Clear();
                        break;
                    case "make":
                        make_note(words);
                        break;
                    case "m":
                        make_note(words);
                        break;
                    case "show":
                        show_notes();
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
            Console.WriteLine();
            Console.WriteLine("Use 'make' to make a new note");
            Console.WriteLine("Use 'show' to show all notes");
            Console.WriteLine("Use 'help' to show this list");
            Console.WriteLine("Use 'exit' to exit the program");
            Console.WriteLine();
        }
        static void make_note(string[] words)
        {
            try
            {
                create_note note = new create_note(words[1]);
            }
            catch
            {
                create_note note = new create_note();
            }
        }
        static void show_notes()
        {
            if (Directory.Exists("notes"))
            {
                string[] files = Directory.GetFiles("notes");
                Console.Clear();
                int index = 0;

                foreach (string file in files)
                {
                    Console.WriteLine(index + ": " + Path.GetFileName(file));
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Directory not found\nRestart to create all Directories");
            }
        }
    }
}
