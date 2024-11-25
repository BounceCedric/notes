using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string version = "1.0";
            bool running = true;
            string input;

            Console.WriteLine("Welcome to Notes " + version);
            print_help();

            while (running)
            {
                input = Console.ReadLine();
                input = input.Replace(" ", "");
                input = input.ToLower();
                switch (input)
                {
                    case "exit":
                        running = false;
                        break;
                    case "e":
                        running = false;
                        break;
                    case "help":
                        print_help();
                        break;
                    case "make":
                        make_note();
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
        static void make_note()
        {
            string name, note, expiration = "";
            bool expires;
            string date = DateTime.Now.ToString();

            Console.Write("Enter Note name: ");
            name = Console.ReadLine().ToLower();

            Console.WriteLine("Set expiration date as DD.MM.YYYY\n(leave empty if there is none): ");
            expiration = Console.ReadLine();
            if (expiration.Length < 0)

            Console.WriteLine("Write Note:");
            note = Console.ReadLine();

            Console.WriteLine("New Note createt");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Date: " + date);
            Console.WriteLine("Note:\n" + note);
        }
    }
}
