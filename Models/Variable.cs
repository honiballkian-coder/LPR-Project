using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP.Models
{
   
        public enum VariableType { Continuous, Integer, Binary, Unrestricted }

        public class Variable
        {
            public string Name { get; set; }
            public double Coefficient { get; set; }
            public VariableType Type { get; set; }
        }
    
}
