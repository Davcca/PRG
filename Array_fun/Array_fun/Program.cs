using System;

namespace Array_fun
{
    internal class Program
    {
        static int[,] ArrayCreation(int type, int x, int y)
        {
            int[,] Array = new int[x, y];

            if (type == 1) //sequential filling
            {
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        Array[i, j] = i * y + j + 1;
                    }
                }
            }
            else
            {
                Random rd = new Random(); 
                for (int i = 0; i < Array.GetLength(0); i++) //random filling
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        Array[i, j] = rd.Next(100);
                    }
                }
            }

            return Array;
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] TransposeArray(int[,] array)
        {
            int[,] Array = new int[array.GetLength(1), array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Array[j, i] = array[i, j];
                }
            }
            return Array;
        }

        static int[,] SumArray(int[,] array1, int[,] array2)
        {
            int[,] Array = new int[array1.GetLength(0), array1.GetLength(1)]; //create new array with known dimensions
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    Array[i, j] = array1[i, j] + array2[i, j];
                }
            }
            return Array;
        }
        static int[,] SubArray(int[,] array1, int[,] array2)
        {
            int[,] Array = new int[array1.GetLength(0), array1.GetLength(1)];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    Array[i, j] = array1[i, j] - array2[i, j];
                }
            }
            return Array;
        }
        static int[,] DivArray(int[,] array1, int[,] array2)
        {
            int[,] Array = new int[array1.GetLength(0), array1.GetLength(1)];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    Array[i, j] = array1[i, j] / array2[i, j];
                }
            }
            return Array;
        }
        static int[,] MulArray(int[,] array1, int[,] array2)
        {
            int[,] Array = new int[array1.GetLength(0), array1.GetLength(1)];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    Array[i, j] = array1[i, j] * array2[i, j];
                }
            }
            return Array;
        }
        static int[,] ReverseMainDiag(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int minDimension = Math.Min(rows, cols); //this approach sugested by ChatGPT

            for (int i = 0; i < minDimension / 2; i++)
            {
                int temp = array[i, i]; //create temporary var to hold value
                int reversedIndex = minDimension - i - 1; //calculation reversed possition 
                array[i, i] = array[reversedIndex, reversedIndex]; //writing value to the reversed possition
                array[reversedIndex, reversedIndex] = temp; //using temporary value to rewrite former possition
            }

            PrintArray(array);
            return array;
        }
        static int[,] ReverseSecDiag(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int minDimension = Math.Min(rows, cols);

            for (int i = 0; i < minDimension / 2; i++)
            {
                int temp = array[i, cols - i - 1]; //create temporary var to hold value
                int reversedIndex = minDimension - i - 1;//calculation reversed possition 
                array[i, cols - i - 1] = array[reversedIndex, cols - reversedIndex - 1];//writing value to the reversed possition
                array[reversedIndex, cols - reversedIndex - 1] = temp;//using temporary value to rewrite former possition
            }

            PrintArray(array);
            return array;
        }
        static (int[,], int[,]) SwapDiagArray(int[,] array1, int[,] array2)
        {
            int rows = array1.GetLength(0);
            int cols = array1.GetLength(1);
            int minDimension = Math.Min(rows, cols);

            for (int i = 0; i < minDimension; i++)
            {
                int temp = array1[i, i]; //create temporary var to hold value
                array1[i, i] = array2[i, i];
                array2[i, i] = temp;
            }

            for (int i = 0; i < minDimension; i++)
            {
                int temp = array1[i, cols - i - 1]; //create temporary var to hold value
                array1[i, cols - i - 1] = array2[i, cols - i - 1];
                array2[i, cols - i - 1] = temp;
            }

            return (array1, array2);
        }
        static void TransposeIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(1) && array1.GetLength(1) == array2.GetLength(0))
            {
                Console.WriteLine("Arrays can be transposed. Transposing...");
                int[,] transposedArray1 = TransposeArray(array1);
                int[,] transposedArray2 = TransposeArray(array2);

                Console.WriteLine("Transposed Array 1:");
                PrintArray(transposedArray1);
                Console.WriteLine("Transposed Array 2:");
                PrintArray(transposedArray2);
            }
            else
            {
                Console.WriteLine("Arrays cannot be transposed.");
            }
        }

        static void SumIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1)) //check that the dimesions are matching
            {
                Console.WriteLine("Arrays can be summed. Summing...");
                int[,] Array = SumArray(array1, array2);

                Console.WriteLine("Summed Array:");
                PrintArray(Array);
            }
            else
            {
                Console.WriteLine("Arrays cannot be summed.");
            }
        }
        static void SubIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1))//check that the dimesions are matching
            {
                Console.WriteLine("Arrays can be subtracted. Subtracting...");
                int[,] Array = SubArray(array1, array2);

                Console.WriteLine("Subtracted Array:");
                PrintArray(Array);
            }
            else
            {
                Console.WriteLine("Arrays cannot be subtracted.");
            }
        }
        static void DivIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1))//check that the dimesions are matching
            {
                Console.WriteLine("Arrays can be divided. Dividing...");
                int[,] Array = DivArray(array1, array2);

                Console.WriteLine("Divided Array:");
                PrintArray(Array);
            }
            else
            {
                Console.WriteLine("Arrays cannot be Divided.");
            }
        }
        static void MulIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1))//check that the dimesions are matching
            {
                Console.WriteLine("Arrays can be multiplied. Multipliing...");
                int[,] Array = MulArray(array1, array2);

                Console.WriteLine("Divided Array:");
                PrintArray(Array);
            }
            else
            {
                Console.WriteLine("Arrays cannot be muliplied.");
            }
        }
        static void SwapDiagIfPossible(int[,] array1, int[,] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1))//check that the dimesions are matching
            {
                Console.WriteLine("Arrays can be have diagonal swapped. Swapping...");
                (int[,] Array1, int[,] Array2) = SwapDiagArray(array1, array2);

                Console.WriteLine("Arrays with swapped diagonals:");
                PrintArray(Array1);
                Console.WriteLine("\n");
                PrintArray(Array2);
            }
            else
            {
                Console.WriteLine("Arrays diagonals cannot be swapped.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's start by creating an array, enter the first dimension of the array:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second dimension of the array:");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 for numbers from 1 to x*y and any other number for random filling.");
            int type = Convert.ToInt32(Console.ReadLine());

            int[,] Array1 = ArrayCreation(type, x, y); //type will determine if array is randomly or sequentially filled
            PrintArray(Array1);

            Console.WriteLine("Press 1 to create another array, any other key to skip.");
            int[,] Array2 = null;
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Creating the second array, enter the first dimension of the array:");
                int x2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the second dimension of the array:");
                int y2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter 1 for numbers from 1 to x*y and any other number for random filling.");
                int type2 = Convert.ToInt32(Console.ReadLine());

                Array2 = ArrayCreation(type2, x2, y2);
                PrintArray(Array2);
            }

            while (true)
            {
                Console.WriteLine("Press a number for the desired operation:\n1 - Transpose\n2 - Sum\n3 - Subtract\n4 - Divide\n5 - Multiply\n6 - Swap Diagonal\n7 - Reverse Main Diagonal\n8 - Reverse Second Diagonal\nType 'end' to finish.");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "end") // condition to end the programm 
                {
                    Console.WriteLine("Program ended.");
                    break;
                }

                if (Array2 == null && !"7".Equals(choice) && !"8".Equals(choice)) //error msg if second array is not created
                {
                    Console.WriteLine("Second array not created. Only '7 - Reverse Main Diagonal' and '8 - Reverse Second Diagonal' are available.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        TransposeIfPossible(Array1, Array2);
                        break;
                    case "2":
                        SumIfPossible(Array1, Array2);
                        break;
                    case "3":
                        SubIfPossible(Array1, Array2);
                        break;
                    case "4":
                        DivIfPossible(Array1, Array2);
                        break;
                    case "5":
                        MulIfPossible(Array1, Array2);
                        break;
                    case "6":
                        SwapDiagIfPossible(Array1, Array2);
                        break;
                    case "7":
                        Console.WriteLine("Reversing main diagonal of the first array:");
                        ReverseMainDiag(Array1);
                        if (Array2 != null)
                        {
                            Console.WriteLine("\nReversing main diagonal of the second array:");
                            ReverseMainDiag(Array2);
                        }
                        break;
                    case "8":
                        Console.WriteLine("Reversing secondary diagonal of the first array:");
                        ReverseSecDiag(Array1);
                        if (Array2 != null)
                        {
                            Console.WriteLine("\nReversing secondary diagonal of the second array:");
                            ReverseSecDiag(Array2);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice."); //if out of range/invalid input
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}