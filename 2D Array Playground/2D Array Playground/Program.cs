using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] my2DArray = new int[5, 5];
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    my2DArray[i, j] = i * 5 + j + 1;
                    Console.WriteLine(my2DArray[i, j]);
                }
                Console.WriteLine("\n");
            }

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            for (int j = 0; j < my2DArray.GetLength(1); j++)
            {
                Console.WriteLine(my2DArray[nRow, j]);
            }
            Console.WriteLine("\n");

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                Console.Write(my2DArray[i, nColumn] + " ");
            }
            Console.WriteLine("\n");

            //Hlavní diagonála
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                Console.WriteLine(my2DArray[i, i]);
            }
            Console.WriteLine("\n");

            //Vedlejší diagonála
            Console.WriteLine("vedlejší");
            for (int i = 4; i > -1; i--)
            {
                Console.WriteLine(my2DArray[i, 4 - i]);
            }
            Console.WriteLine("\n");

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst = 0;
            int yFirst = 4;
            int xSecond = 1;
            int ySecond = 1;
            int first = my2DArray[xFirst, yFirst];
            int second = my2DArray[xSecond, ySecond];
            int temp = first;
            my2DArray[xFirst, yFirst] = second;
            my2DArray[xSecond, ySecond] = temp;
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.WriteLine(my2DArray[i, j]);
                }
            }
            Console.WriteLine("\n");
            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            int[] tempArray = new int[5];

            for (int j = 0; j < my2DArray.GetLength(1); j++)
            {
                tempArray[j] = my2DArray[nRowSwap, j];
            }

            for (int j = 0; j < my2DArray.GetLength(1); j++)
            {
                my2DArray[nRowSwap, j] = my2DArray[mRowSwap, j];
            }
            for (int j = 0; j < my2DArray.GetLength(1); j++)
            {
                my2DArray[mRowSwap, j] = tempArray[j];
            }
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.WriteLine(my2DArray[i, j]);
                }
            }
            Console.WriteLine("\n");

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 3;
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                tempArray[i] = my2DArray[i, nColSwap];
            }
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                my2DArray[i, nColSwap] = my2DArray[i, mColSwap];
            }
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                my2DArray[i, nColSwap] = tempArray[i];
            }
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.WriteLine(my2DArray[i, j]);
                }
            }


            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0; i <= my2DArray.GetLength(0) / 2; i++)
            {
                int temp1 = my2DArray[i, i];
                int reversedIndex = my2DArray.GetLength(0) - i - 1;
                my2DArray[i, i] = my2DArray[reversedIndex, reversedIndex];
                my2DArray[reversedIndex, reversedIndex] = temp1;

            }

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.

            for (int i = 4; i <= my2DArray.GetLength(0) / 2; i--)
            {
                int temp1 = my2DArray[i, my2DArray.GetLength(0 - i - 1)];
                int reversedIndex = my2DArray.GetLength(0) - i - 1;
                my2DArray[i, i] = my2DArray[reversedIndex, reversedIndex];
                my2DArray[reversedIndex, reversedIndex] = temp1;
                Console.ReadKey();
            }
        }
    }
}
