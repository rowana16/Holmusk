using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holmusk.Controllers
{
    using System.Linq;
    using System.Collections;
    using Controllers;
    using Models;

    class Helpers
    {
        public int addAnother(int i)
        {
            var io = new ConsoleIO();
            string next = "";

            io.WriteLine("");
            io.WriteLine("-------------Add Another? Y/N ----------------------------");
            io.WriteLine("");
            next = io.ReadLine();
            if (next.ToUpper() == "Y") { i--; }
            return i;
        }

        public string GetTextInput(string inputPhrase1, string invPhrase2)
        {
            var io = new ConsoleIO();

            io.WriteLine("What is your " + inputPhrase1 + " ?");
            var f = Console.ReadLine();
            if (IsCharactersOnly(f) && f.Length > 0) { return f; }
            else { io.WriteLine("Invalid " + invPhrase2 + ".  Please Reenter"); }
            return null;
        }

        public string GetCharInput(string inputPhrase1, string invPhrase2, List<char>acceptableChar)
        {
            var io = new ConsoleIO();

            io.WriteLine("What is your " + inputPhrase1 + " ?");
            var f = Console.ReadLine();
            if (IsCharactersOnly(f) && f.Length ==1) { if (CheckChar(acceptableChar, f)){ return f; } }
            else { io.WriteLine("Invalid " + invPhrase2 + ".  Please Reenter"); }
            return null;
        }

        public string GetNumericInput(string inputPhrase1, string invPhrase2, int min, int max)
        {
            var io = new ConsoleIO();

            io.WriteLine("What is your " + inputPhrase1 + " ?");
            string f = Console.ReadLine();

            if (IsDigitsOnly(f) && f.Length > 0)
            {
                if (Convert.ToInt32(f) > min && Convert.ToInt32(f) < max) { return f; }
                else { io.WriteLine("Invalid " + invPhrase2 + ".  Please Reenter"); return null; }
            }
            else { io.WriteLine("Invalid " + invPhrase2 + ".  Please Reenter"); }
            return null;
        }

        bool IsCharactersOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < 'A' ||( c > 'Z' && c < 'a' )|| c > 'z')
                    return false;
            }

            return true;
        }

        bool CheckChar(List<char> acceptableChar, string f)
        {
            char fcheck = f.ToUpper().ToCharArray()[0];
            foreach (char c in acceptableChar)
            {
                if (fcheck == c) { return true; }
            }
            return false;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        
    }
}
