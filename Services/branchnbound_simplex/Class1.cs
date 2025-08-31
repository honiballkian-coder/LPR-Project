using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promting
{
    public class Class1
    {
        
        public double[,] pMatrix()
        {
            try
            {

                Console.WriteLine("Constraints.......");
                Console.WriteLine("Enter the number of rows:");
                int rows = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of columns:");
                int columns = int.Parse(Console.ReadLine());

                double[,] matrix = new double[rows, columns];

                Console.WriteLine("Enter the elements of the matrix:");

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write($"Element [{i},{j}]: ");
                        matrix[i, j] = double.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("The matrix you entered is:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                return matrix;
            }
            catch (Exception)
            {
                throw;
            }
        }

         public double[] righmatrix()
         {
            try
            {


                Console.WriteLine("Right hand side constraints");
                Console.WriteLine("Enter the number of elements:");
                int size = int.Parse(Console.ReadLine());

                double[] array = new double[size];

                Console.WriteLine("Enter the elements of the array:");

                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Element [{i}]: ");
                    array[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("The Right hand side array is:");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(array[i] + "\t");
                }
                Console.WriteLine();

                return array;
            }
            catch(Exception)
            {
                throw;
            }
         }

           
        
        public double[] pObjFunction()
        {
            try
            {

                Console.WriteLine("Objective function......");
                Console.WriteLine("Enter the number of elements:");
                int size = int.Parse(Console.ReadLine());

                double[] array = new double[size];

                Console.WriteLine("Enter the elements of the array:");

                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Element [{i}]: ");
                    array[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("This is the objective function array:");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(array[i] + "\t");
                }
                Console.WriteLine();

                return array;
            }
            catch (Exception)
            {
                throw;
            }
        }
        



    }
}
