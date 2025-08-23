using SolverLP_IP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP.Services
{
   
    public static class FileParser
    {
        public static LinearModel ParseModel(string path)
        {
            var lines = File.ReadAllLines(path);
            var model = new LinearModel();

            // Parse objective function
            var firstLine = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            model.IsMaximization = firstLine[0].ToLower() == "max";

            for (int i = 1; i < firstLine.Length; i++)
            {
                double coeff = double.Parse(firstLine[i]);
                model.Variables.Add(new Variable
                {
                    Name = "x" + i,
                    Coefficient = coeff,
                    Type = VariableType.Continuous
                });
            }

            // Parse constraints
            for (int i = 1; i < lines.Length - 1; i++)
            {
                var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var coeffs = parts.Take(parts.Length - 2).Select(double.Parse).ToArray();
                var relation = parts[parts.Length - 2];
                double rhs = double.Parse(parts.Last());

                ConstraintType rel = relation switch
                {
                    "<=" => ConstraintType.LessThanOrEqual,
                    ">=" => ConstraintType.GreaterThanOrEqual,
                    "=" => ConstraintType.Equal,
                    _ => throw new Exception("Invalid constraint operator")
                };

                model.Constraints.Add(new Constraint
                {
                    Coefficients = coeffs,
                    Relation = rel,
                    RHS = rhs
                });
            }

            // Parse variable restrictions (last line)
            var restrictions = lines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < restrictions.Length; i++)
            {
                model.Variables[i].Type = restrictions[i].ToLower() switch
                {
                    "int" => VariableType.Integer,
                    "bin" => VariableType.Binary,
                    "urs" => VariableType.Unrestricted,
                    _ => VariableType.Continuous
                };
            }

            return model;
        }
    }
}
