using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace promting
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Class1 class1= new Class1();
            double[,] A=class1.pMatrix();
            double []b=class1.righmatrix();
            double [] c= class1.pObjFunction();


            BranchAndBoundSimplex(A, b, c);


        }

        static void BranchAndBoundSimplex(double[,] A, double[] b, double[] c)
        {
            double[] x = Simplex(A, b, c);

            Queue<double[]> queue = new Queue<double[]>();
            queue.Enqueue(x);

            double bestValue = double.MinValue;

            double[] bestsolution = null;

            while (queue.Count>0)
            {
                double[] currentSolution = queue.Dequeue();
                double currentValue = ObjectiveFunction(currentSolution, c);

                if (currentValue>=bestValue)
                {
                    bestValue=currentValue;
                    bestsolution = currentSolution;
                }

                //branching logic
                
                for (int i = 0; i<currentSolution.Length; i++)
                {
                    if (currentSolution[i]!= Math.Floor(currentSolution[i]))
                    {
                        double[] leftBranch = (double[])currentSolution.Clone();
                        double[] rightBranch = (double[])currentSolution.Clone();

                        leftBranch[i]=Math.Floor(currentSolution[i]);
                        rightBranch[i]=Math.Ceiling(currentSolution[i]);

                        queue.Enqueue(leftBranch);
                        queue.Enqueue(rightBranch);
                    }
                }
                
                

            }

            Console.WriteLine("Best solution found:");

            foreach (var value in bestsolution)
            {
                Console.WriteLine(value + "");
            }
            for (int i = 0; i<bestsolution.Length; i++)
            {
                Console.WriteLine($"x{i+1}={bestsolution[i]}");
            }

            Console.WriteLine($"Objective value:{bestValue}");
        }

        static double[] Simplex(double[,] A, double[] b, double[] c)
        {
            int m = A.GetLength(0); // number of constraints
            int n = A.GetLength(1); // number of variables

            // Initialize basic and non-basic variables
            List<int> basic = new List<int>();
            List<int> nonBasic = new List<int>();
            for (int i = 0; i < n; i++) nonBasic.Add(i);
            for (int i = 0; i < m; i++) basic.Add(n + i);

            // Initialize tableau
            double[,] tableau = new double[m + 1, n + m + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tableau[i, j] = A[i, j];
                }
                tableau[i, n + i] = 1;
                tableau[i, n + m] = b[i];
            }
            for (int j = 0; j < n; j++)
            {
                tableau[m, j] = -c[j];
            }

            // Simplex algorithm
            while (true)
            {
                // Find entering variable (most negative coefficient in objective row)
                int entering = -1;
                for (int j = 0; j < n + m; j++)
                {
                    if (tableau[m, j] < 0)
                    {
                        entering = j;
                        break;
                    }
                }
                if (entering == -1) break; // Optimal solution found

                // Find leaving variable (minimum ratio test)
                int leaving = -1;
                double minRatio = double.MaxValue;
                for (int i = 0; i < m; i++)
                {
                    if (tableau[i, entering] > 0)
                    {
                        double ratio = tableau[i, n + m] / tableau[i, entering];
                        if (ratio < minRatio)
                        {
                            minRatio = ratio;
                            leaving = i;
                        }
                    }
                }
                if (leaving == -1) throw new Exception("Unbounded solution");

                // Pivot
                double pivot = tableau[leaving, entering];
                for (int j = 0; j <= n + m; j++)
                {
                    tableau[leaving, j] /= pivot;
                }
                for (int i = 0; i <= m; i++)
                {
                    if (i != leaving)
                    {
                        double factor = tableau[i, entering];
                        for (int j = 0; j <= n + m; j++)
                        {
                            tableau[i, j] -= factor * tableau[leaving, j];
                        }
                    }
                }

                // Update basic and non-basic variables
                basic[leaving] = entering;
            }

            // Extract solution
            double[] solution = new double[n];
            for (int i = 0; i < m; i++)
            {
                if (basic[i] < n)
                {
                    solution[basic[i]] = tableau[i, n + m];
                }
            }
            return solution;

        }

        static double ObjectiveFunction(double[] x, double[] c)
        {
            double value = 0;

            for (int i = 0; i<x.Length; i++)
            {
                value += x[i]*c[i];
            }

            return value;
        }



    }
}
