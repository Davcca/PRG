﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace SortingPlayground
{
    internal class Program
    {
        //Pokud si nejsi jistý/á, co dělat, podívej se do prezentace, na videa na YT, co jsem doporučoval, googluj a nebo mě zavolej a já ti poradím.

        static int[] BubbleSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            /*
             * TODO: Naimplementuj bubble sort.
             */
            {

                for (int i = 0; i < sortedArray.Length - 1; i++) 
                {
                    for (int n = 0; n < sortedArray.Length - i - 1; n++) 
                    {
                        if (sortedArray[n] > sortedArray[n + 1])
                        {
                            int lmao = sortedArray[n];
                            sortedArray[n] = sortedArray[n + 1];
                            sortedArray[n + 1] = lmao;
                        }
                    }
                }
            }
            return sortedArray;
        }

        static int[] SelectionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();

            for (int n = 0; n < sortedArray.Length - 1; n++)
            {
                int minIndex = n;

                for (int i = n + 1; i < sortedArray.Length; i++)
                {
                    if (sortedArray[i] < sortedArray[minIndex])
                    {
                        minIndex = i;
                    }
                }

                int temp = sortedArray[minIndex];
                sortedArray[minIndex] = sortedArray[n];
                sortedArray[n] = temp;
            }

            return sortedArray;
        }

        static int[] InsertionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            /*
             * TODO: Naimplementuj insertion sort.
             */
            for(int n = sortedArray.Length; n>0 ; n--)
            {
                for (int i = sortedArray.Length - 1; i > 0; i--)
                {
                    if (sortedArray[i] < sortedArray[i - 1])
                    {
                        int lmao = sortedArray[i];
                        sortedArray[i] = sortedArray[i - 1];
                        sortedArray[i - 1] = lmao;
                    }
                }

            }


            return sortedArray;
        }

        //Naplní pole náhodnými čísly mezi 1 a velikostí pole.
        static void FillArray(int[] array)
        {
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, array.Length + 1);
            }
        }

        //Vypíše pole do konzole.
        static void WriteArrayToConsole(int[] array, string arrayName)
        {
            Console.Write(arrayName + " = [");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        //Zavolá postupně Bubble sort, Selection sort a Insertion sort pro zadané pole (a vypíše jeho jméno pro přehlednost)
        static void SortArray(int[] array, string arrayName)
        {
            Console.WriteLine($"Řadím {arrayName}:");
            int[] sortedArray;

            sortedArray = BubbleSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Bubble sortem");

            sortedArray = SelectionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Selection sortem");

            sortedArray = InsertionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Insertion sortem");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] smallArray = new int[10];
            FillArray(smallArray);

            int[] mediumArray = new int[100];
            FillArray(mediumArray);

            int[] largeArray = new int[1000];
            FillArray(largeArray);

            WriteArrayToConsole(smallArray, "Malé pole");
            SortArray(smallArray, "Malé pole");

            WriteArrayToConsole(mediumArray, "Střední pole");
            SortArray(mediumArray, "Střední pole");

            //WriteArrayToConsole(largeArray, "Velké pole");
            //SortArray(largeArray, "Velké pole");

            Console.ReadKey();
        }
    }
}