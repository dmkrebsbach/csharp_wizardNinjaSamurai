using System;

namespace wizardNinjaSamurai
{
    public class Human
    {
        // Fields for Human
        public string Name {get;set;}
        public int Strength {get;set;} = 3;
        public int Intelligence {get;set;} = 3;
        public int Dexterity {get;set;} = 3;
        private int health {get;set;} = 100;

        public int Health  
        {
            set { health = value;}  // this is required when the property is private (to modify as a default in children classes)
                                    // otherwise, defaults can be modified as with the other properties (Strength, Intel, Dexterity)
            get { return health;}   // add a public "getter" property to access health

        }

        public Human(string name)  // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        {
            Name = name;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)  // Add a constructor to assign custom values to all fields
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            this.health = health;
        }

        
        public virtual void Attack(Human victim) // Build Attack method
        {
            var Victim = (Human) victim;
            Victim.health -= 2 * Strength;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ATTACK! {Victim.Name} loses {2 * Strength} pts from their Health!");
            Console.WriteLine("Current Victim Stats: " + Victim.ToString() );
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}";
        }
    }

    public class Wizard : Human
    {
        public Wizard(string name) :base(name)
        {
            Health = 50;
            Intelligence = 25;
        }
        public void Heal(Human victim)
        {
            victim.Health += 10*victim.Intelligence;
        }
    }

    public class Ninja : Human
    {
        public Ninja(string name) :base(name)
        {
            Dexterity = 175;
        }
        public void Steal(Human victim)
        {
            victim.Health -= 10;
            Health += 10;
        }
        public override void Attack(Human victim) // Build Override Attack method for Ninja
        {
            var Victim = (Human) victim;
            Victim.Health -= 5 * Dexterity;
            Random rand = new Random();
            int idx = rand.Next(1,11);
            if (idx < 3)
            {
                Victim.Health -= 10;
                Console.ForegroundColor = ConsoleColor.Red;  
                Console.WriteLine("Bonus Attack Successful!");  
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ATTACK! {Victim.Name} loses {2 * Dexterity} pts from their Health!");
            Console.WriteLine("Current Victim Stats: " + Victim.ToString() );
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }

    public class Samurai : Human
    {
        public Samurai(string name) :base(name)
        {
            Health = 200; // from public int Health in Human Class
        }

        public void Meditate()
        {
            Health = 200;
        }
        public override void Attack(Human victim) // Build Override Attack method for Samurai
        {
            var Victim = (Human) victim;
            if (Victim.Health < 50)
            {
                Victim.Health = 0;  
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bonus Attack Successful!; Health Reduced to Zero!");  
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ATTACK! {Victim.Name} loses {2 * Dexterity} pts from their Health!");
            Console.WriteLine("Current Victim Stats: " + Victim.ToString() );
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Human("Damian");
            var player2 = new Samurai("Lee");
            var player3 = new Ninja("Cody");
            var player4 = new Wizard("Ryan");
            Console.WriteLine(player1);
            Console.WriteLine(player2);
            Console.WriteLine(player3);
            Console.WriteLine(player4);
            player1.Attack(player2);
            player1.Attack(player2);
            player1.Attack(player2);
            player1.Attack(player2);
            Console.WriteLine(player2);
            player1.Attack(player3);
            player1.Attack(player3);
            player1.Attack(player3);
            Console.WriteLine(player3);
            player1.Attack(player4);
            player1.Attack(player4);
            player1.Attack(player4);
            player1.Attack(player4);
            player1.Attack(player4);
            Console.WriteLine(player4);
            player4.Heal(player4);
            Console.WriteLine(player4);
            Console.WriteLine(player2);
            player2.Meditate();
            Console.WriteLine(player2);
        }
    }
}