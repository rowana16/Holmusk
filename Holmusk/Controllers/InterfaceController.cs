using Holmusk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holmusk.Controllers
{
    
    public interface IO
    {
        void WriteLine(string arg);

        string ReadLine();
    }

    // Service implementation
    public struct ConsoleIO : IO
    {
        public void WriteLine(string arg)
        {
            Console.WriteLine(arg);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public sealed class TestIO : IO
    {
        public void WriteLine(string arg)
        {
            Debug.WriteLine(arg);
        }

        public string ReadLine()
        {
            return string.Empty;
        }
    }

    public static class Db
    {
        public static List<Person> people = new List<Person>();
    }
}
