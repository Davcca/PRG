namespace Classroom
{
    internal class Program
    {
        class Human
        {
            int age;
            int height;
            int weight;
            string hairColor;
            string eyeColor;
            string name;

            public void PrintCharacteristics()
            {
                Console.WriteLine($"{name} is {age} years old, measures {height}cm and weighs {weight}kg.");
            }
            static void Main(string[] args)
            {
                Human karel = new Human();
                karel.age = 32;
                karel.height = 180;
                karel.weight = 90;
                karel.hairColor = "blue";
                karel.eyeColor = "green";
                karel.name = "Karel";
                karel.PrintCharacteristics();
                Console.ReadKey();
            }
        }
    }
}