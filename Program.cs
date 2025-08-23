using SolverLP_IP.Models;
using SolverLP_IP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinearModel model = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Linear & Integer Programming Solver ===");
                Console.WriteLine("1. Load Model from File");
                Console.WriteLine("2. Solve using Primal Simplex");
                Console.WriteLine("3. Solve using Revised Simplex");
                Console.WriteLine("4. Solve using Branch & Bound");
                Console.WriteLine("5. Solve using Cutting Plane");
                Console.WriteLine("6. Sensitivity Analysis");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter input file path: ");
                        string path = Console.ReadLine();
                        model = FileParser.ParseModel(path);
                        Console.WriteLine("Model loaded successfully!");
                        Console.ReadKey();
                        break;

                    case "2":
                        if (model == null) { Console.WriteLine("Load a model first!"); Console.ReadKey(); break; }
                        new SimplexSolver().Solve(model);
                        Console.ReadKey();
                        break;

                    case "3":
                        if (model == null) { Console.WriteLine("Load a model first!"); Console.ReadKey(); break; }
                        new RevisedSimplexSolver().Solve(model);
                        Console.ReadKey();
                        break;

                    case "4":
                        if (model == null) { Console.WriteLine("Load a model first!"); Console.ReadKey(); break; }
                        new BranchBoundSolver().Solve(model);
                        Console.ReadKey();
                        break;

                    case "5":
                        if (model == null) { Console.WriteLine("Load a model first!"); Console.ReadKey(); break; }
                        new CuttingPlaneSolver().Solve(model);
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Sensitivity analysis module coming soon...");
                        Console.ReadKey();
                        break;

                    case "7":
                        return;
                }
            }
        }
    }
    }

