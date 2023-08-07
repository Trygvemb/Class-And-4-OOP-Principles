using System;

namespace Class_And_4_OOP_Principles
{
    // Hovedklasse Program
    class Program
    {
        static void Main(string[] args)
        {
            // Opret en instans af klassen Car og Motorcycle
            Car honda = new Car("Honda Motor Company, Ltd.", 2012);
            Motorcycle motorcycle = new Motorcycle();


            // Udskriv information om bilen
            Console.WriteLine(honda.Manufacturer);

            // Start bilen ved hjælp af polymorfi (Start-metoden er en polymorfisk metode)
            honda.Start();

            // Tank 10 liters brændstof på bilen
            honda.Refuel(10);

            // Start bilen igen
            honda.Start();

            Console.WriteLine("\nMotorcycle");
            // Kalder MakeSound metoden fra Automobile klassen gennem Motorcycle klassen (Polymorfi)
            motorcycle.MakeSound();

            // Vent på brugerens input før programmet afsluttes
            Console.ReadLine();
        }
    }

    // Abstrakt klasse Automobile illustrerer abstraktion
    abstract class Automobile
    {
        // Egenskaber for producent (indkapsling) og årstal (indkapsling)
        public string Manufacturer { get; set; }
        public int Year { get; set; }

        // Virtuel metode der KAN overskrives i afledte klasser (polymorfi)
        public virtual void MakeSound()
        {
            Console.WriteLine("Automobile makes a sound");
        }

        // Abstrakt metode for at starte køretøjet, skal implementeres i afledte klasser (abstraktion)
        public abstract void Start();
    }

    // Klassen Car nedarver fra Automobile (nedarvning)
    class Car : Automobile
    {
        private int fuelLevel; // Privat felt til at gemme brændstofniveauet (indkapsling)

        // Konstruktør for Car-klassen, der initialiserer producent, årstal og brændstofniveau
        public Car(string manufacturer, int year)
        {
            Manufacturer = manufacturer;
            Year = year;
            fuelLevel = 0; // Bilen starter uden brændstof
        }

        // Metode til at tanke brændstof til bilen
        public void Refuel(int amount)
        {
            fuelLevel += amount;
            Console.WriteLine("Refueling... \nFuel level is: " + fuelLevel);
        }

        // Overskrivning af MakeSound-metoden til at angive, at bilen laver en lyd (polymorfi)
        public override void MakeSound()
        {
            Console.WriteLine("Car makes a sound");
        }

        // Implementering af Start-metoden for at starte bilen
        public override void Start()
        {
            if (fuelLevel > 0) // Hvis der er brændstof i bilen
            {
                Console.WriteLine("Car started");
                MakeSound(); // Kør MakeSound-metoden for at lave en lyd (polymorfi)
            }
            else
            {
                Console.WriteLine("Out of fuel. Cannot start the car"); // Hvis der ikke er brændstof, kan bilen ikke starte
            }
        }
    }

    // Klassen Motorcycle nedarver også fra Automobile (nedarvning)
    class Motorcycle : Automobile
    {
        //// Overskrivning af MakeSound-metoden for at angive, at motorcyklen laver en lyd (polymorfi)
        //public override void MakeSound()
        //{
        //    Console.WriteLine("Motorcycle makes a sound");
        //}

        // Implementering af Start-metoden for at starte motorcyklen
        public override void Start()
        {
            Console.WriteLine("Motorcycle started");
            MakeSound(); // Kør MakeSound-metoden for at lave en lyd (polymorfi)
        }
    }
}
