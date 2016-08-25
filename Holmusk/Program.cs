using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;


namespace Holmusk
{
    using System.Linq;
    using System.Collections;
    using Controllers;
    using Models;


    // Interface for DI


    public class Solution
    {




        public static void Main(string[] args)
        {
            var io = new ConsoleIO();
            var p = new Solution();
            Helpers helper = new Helpers();
            int maxCount = 1;

            for (int i = 0; i < maxCount; i++)
            {
               
                io.WriteLine("");
                io.WriteLine("-------------------------------------------------------------------");
                io.WriteLine("");
                io.WriteLine("Hello, Please Help Us Out by Providing the Following Information");
                io.WriteLine("");
                Db.people.Add(p.ReadPerson(io));

                if (i <= maxCount-1)
                {
                    i = helper.addAnother(i);
                }



            }

            for (int i = 0; i < Db.people.Count; i++)
            {
                p.WritePerson(io, Db.people[i]);
            }

            Console.Read();
        }

        public Person ReadPerson(ConsoleIO io)
        {
            Person p = new Person();
            Helpers helper = new Helpers();
            
            while (p.FirstName == null)
            {
                p.FirstName = helper.GetTextInput("First Name", "Name");
            }
            io.WriteLine("");

            while (p.LastName == null)
            {
                p.LastName = helper.GetTextInput("Last Name", "Name");
            }
            io.WriteLine("");

            while (p.Age == null)
            {
                p.Age = helper.GetNumericInput("Age", "Age",0,140);
            }
            io.WriteLine("");

            while (p.Gender == null)
            {
                List<char> acceptableInput = new List<char>();
                acceptableInput.Add('M');
                acceptableInput.Add('F');
                p.Gender = helper.GetCharInput("Gender Initial (M/F)", "Gender Value",acceptableInput).ToUpper();
            }
            io.WriteLine("");

            while (p.DadFirstName == null)
            {
                p.DadFirstName = helper.GetTextInput("Dad's First Name", "Name");
            }
            io.WriteLine("");

            while (p.DadLastName == null)
            {
                p.DadLastName = helper.GetTextInput("Dad's Last Name", "Name");
            }
            io.WriteLine("");

            while (p.MomFirstName == null)
            {
                p.MomFirstName = helper.GetTextInput("Mom's First Name", "Name");
            }
            io.WriteLine("");

            while (p.MomLastName == null)
            {
                p.MomLastName = helper.GetTextInput("Mom's Last Name", "Name");
            }
            io.WriteLine("");

            p.Name = p.FirstName.ToUpper() + " " + p.LastName.ToUpper(); 
            p.DadName = p.DadFirstName.ToUpper() + " " + p.DadLastName.ToUpper(); 
            p.MomName = p.MomFirstName.ToUpper() + " " + p.MomLastName.ToUpper(); 

            
            return p;
        }

        public void WritePerson(ConsoleIO io, Person p)
        {
           
            Console.WriteLine("Your first name is: {0}", p.FirstName);
            Console.WriteLine("Your last name is: {0}", p.LastName);
            Console.WriteLine("Your age is: {0}", p.Age);
            switch (p.Gender)
            {
                case "M":
                    Console.WriteLine("You are a: Man");
                    break;
                case "F":
                    Console.WriteLine("You are a: Woman");
                    break;
                default:
                    Console.WriteLine("You do not Fit Traditional Definitions of Gender");
                    break;
            }

            var dad = Db.people.Where(o => o.Name == p.DadName);
            if (dad.Count() >= 1)
            {
                Console.WriteLine("Your dad's age is {0}", dad.First().Age);
            }

            var mom = from x in Db.people where x.Name == p.MomName select x;

            if (mom.Count() >= 1)
            {
                Console.WriteLine("Your mom's age is {0}", mom.First().Age);
            }

            io.WriteLine("");
            io.WriteLine("-------------------------------------------------------------------");
            io.WriteLine("");
        }

        
    }
}