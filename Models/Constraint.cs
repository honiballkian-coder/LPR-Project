using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP.Models
{
    public enum ConstraintType { LessThanOrEqual, GreaterThanOrEqual, Equal }

    public class Constraint
    {
        public double[] Coefficients { get; set; }
        public ConstraintType Relation { get; set; }
        public double RHS { get; set; }
    }
}
