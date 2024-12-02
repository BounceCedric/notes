using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace notes
{
    public class create_note
    {
        string title { get; set; }
        string creation_date { get; set; }
        //tags
        string text { get; set; }
        string datei_pfad;
        string content;

        public create_note(string text)
        {
            this.title = DateTime.Now.ToString().Replace(":", "");
            title = title.Replace(".", "");
            title = title.Replace(" ", "");
            this.creation_date = DateTime.Now.ToString("dd.MM.yyyy");
            this.text = text;

            save_note();
        }

        public create_note()
        {
            Console.Clear();
            title = DateTime.Now.ToString().Replace(":", "");
            title = title.Replace(".", "");
            title = title.Replace(" ", "");
            
            Console.Write("Write Note: ");
            text = Console.ReadLine();
            creation_date = DateTime.Now.ToString("dd.MM.yyyy");

            save_note();
        }

        void print_note()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Created on: " + creation_date);
            Console.WriteLine("Note: " + text);
            Console.WriteLine();
        }
        void save_note()
        {
            Console.Clear();
            print_note();

            Console.Write("Save Note [y/n]: ");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        if (Directory.Exists("notes"))
                        {
                            datei_pfad = "notes\\" + title + ".note";

                            content = "Title: " + title + "\n" +
                                      "Created on: " + creation_date + "\n" +
                                      "Text:\n" + text;

                            File.WriteAllText(datei_pfad, content);

                            Console.Clear();
                            Console.WriteLine("Note saved");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Directory not found\nRestart to create all Directories");
                        }
                        break;
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Note deleted");
                        break;
                    default:
                        Console.WriteLine("'" + input + "' is not recognized");
                        continue;
                }
                break;
            }
        }
    }
}
