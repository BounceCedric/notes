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

                if (words[0] == "make" || words[0] == "m")
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
                    case "s":
                        show_notes();
                        break;
                    case "delete":
                        delete_note(words);
                        break;
                    case "":
                        Console.Clear();
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
            Console.WriteLine("Use 'delete' to delete notes");
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
        static void delete_note(string[] words)
        {
            int sector;
            Console.Clear();
            try
            {
                sector = Convert.ToInt32(words[1]);
                string[,] data = check_files();
                while (true)
                {
                    Console.Write("Are you sure you want to delete '" + data[sector - 1, 0] + "'? [y/n]: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "y":
                            Console.Clear();
                            File.Delete(data[sector - 1, 0]);
                            Console.WriteLine("File deletet");
                            break;
                        case "n":
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("'" + input + "' is not recognized");
                            continue;
                    }
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input: " + words[1]);
                return;
            }
        }
        static void show_notes()
        {
            string[,] data = check_files();
            Console.Clear();
            for (int i = 0; i < data.Length / 2; i++)
            {
                Console.WriteLine((i + 1) + ": " + data[i, 1]);
            }
        }
        static string[,] check_files()
        {
            if (Directory.Exists("notes"))
            {
                string[] files = Directory.GetFiles("notes");
                string[,] data = new string[files.Length, 2];
                string tempText = "";
                StreamReader sr;

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        sr = new StreamReader(files[i]);
                        data[i, 0] = files[i];
                        while (sr.EndOfStream == false)
                        {
                            tempText = sr.ReadLine();
                        }
                        data[i, 1] = tempText;
                        sr.Close();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine("ERROR: Unable to find file: '" + files[i] + "'");
                        return null;
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: An error occurred while trying to open '" + files[i] + "'");
                        return null;
                    }
                }
                return data;
            }
            else
            {
                Console.WriteLine("Directory not found\nRestart to create all Directories");
                return null;
            }
        }
    }
}
