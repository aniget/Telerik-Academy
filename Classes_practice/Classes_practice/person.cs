using System;

namespace Classes_practice
{
    class Person
    {
        //method
        public void Speak()
        {
            Console.WriteLine("Hello Marto!");
            Console.WriteLine("Do you want to know how old I will be in some years");
            Console.WriteLine("Please, enter the number of years:");
        }

        private const int Age = 15;
        private int years;
        private readonly int AgeAfter = Age;

        //default constructor
        public Person()
        {
        }
        
        //constructor with field years
        public Person(int years)
        {
            this.years = years;
        }

        public int PropertyYears
        {
            get { return years; }
            set
            {
                if (this.years < 5)
                {
                    throw new ArgumentException("The years should be bigger than 5");
                }
                this.years = value;
            }
        }

        //method
        public void GetYears()
        {
            int y = 0;
            y = int.Parse(Console.ReadLine());

        }

        //method
        public void PrintInfo()
        {
            Console.WriteLine($"I'm {Age} years old");
            Console.WriteLine($"After {years} years I will be {AgeAfter + years} years old");
        }

    }

}
