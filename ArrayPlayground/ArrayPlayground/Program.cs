using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.
            int[] array = {10, 20, 30, 40, 50};

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            for(int n = 0; n<array.Length; n++)
            {
            Console.WriteLine(array[n]);
        }
        //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            for (int n = 0; n < array.Length; n++)
            {
                sum += array[n];
            }
            Console.WriteLine(sum);
            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = 0;
            sum = 0;
            for (int n = 0; n < array.Length; n++)
            {
                sum += array[n];
            }
            average = sum / array.Length;
            Console.WriteLine("Avg is");
            Console.WriteLine(average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = 0;
            sum = 0;
            for (int n = 0; n < array.Length; n++)
            {
                sum = array[n];
                if (sum > max) 
                {
                    max = sum;
                }
            }
            Console.WriteLine("Max is");
            Console.WriteLine(max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = array.Min();
            Console.WriteLine("Min is");
            Console.WriteLine(min);
            int x = 0;
            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            int index = Convert.ToInt32(Console.ReadLine());
            for (int n = 0; n < array.Length; n++)
            {
              x++;
                if (array[n] == index)
                {
                    Console.WriteLine("Index is");
                    Console.WriteLine(x);
                    break;
                }
                else
                {
                    Console.WriteLine(index +" není v poli");
                    break;
                }
            }
           
            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random rng = new Random();
            array = new int[100];
            for (int n = 0; (n < array.Length); n++) 
            {
                array[n] = rng.Next(0,10);
                Console.WriteLine(array[n]); 
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int n in array) 
            {
                counts[n]++;
            }
            for (int n = 0; ( n < counts.Length); n++) 
            {
                Console.WriteLine($"Číslo {n} se vyskytuje " + counts[n] + " krát.");
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] mySecondArray = new int[100];
            for (int n = 0; n < mySecondArray.Length; n++)
                    {
                mySecondArray[mySecondArray.Length - 1 - n] = array[n];
                    }
            Console.WriteLine("prvni pole");
            foreach (int n in array)
            {
                Console.WriteLine(array[n]);
            }
            Console.WriteLine("druhe pole");
            foreach (int n in mySecondArray)
            {
                Console.WriteLine(mySecondArray[n]);
            }

            Console.ReadKey();
        }
    }
}
