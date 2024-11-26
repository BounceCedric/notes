using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    public class create_note
    {
        string title { get; set; }
        string creation_date { get; set; }
        string expiration_date { get; set; }
        //tags
        string text { get; set; }

        public create_note(string title, string expiration_date, string text)
        {
            this.title = title;
            this.creation_date = DateTime.Now.ToString("dd.MM.yyyy");
            this.expiration_date = expiration_date;
            this.text = text;

            save_note();
        }

        public create_note()
        {
            Console.Clear();
            Console.Write("Title: ");
            title = Console.ReadLine();
            
            while (true)
            {
                bool valid_input = true;
                Console.Write("Expiration Date? Leave empty if there is none!\nInput as DD.MM.YYYY: ");
                expiration_date = Console.ReadLine();
                if (expiration_date == "")
                {
                    expiration_date = "Never";
                    break;
                }
                string[] temp = expiration_date.Split('.');
                if (temp.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine("falsche eingabe\n");
                    continue;
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    try
                    {
                        Convert.ToInt32(temp[i]);
                    }
                    catch
                    {
                        Console.WriteLine("falsche eingabe");

                        break;//funktioniert nicht
                    }
                }
                if (!valid_input)
                {
                    break;
                }
            }
            
            
            
            Console.Write("Write Note: ");
            text = Console.ReadLine();
            creation_date = DateTime.Now.ToString("dd.MM.yyyy");

            save_note();
        }

        void print_note()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Date: " + creation_date);
            Console.WriteLine("Expires: " + expiration_date);
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
                        Console.Clear();
                        Console.WriteLine("Note saved\n");
                        break;
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Note deleted\n");
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
