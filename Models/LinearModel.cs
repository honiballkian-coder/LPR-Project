using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP.Models
{
    
    
        public class LinearModel
        {
            public bool IsMaximization { get; set; }
            public List<Variable> Variables { get; set; } = new List<Variable>();
            public List<Constraint> Constraints { get; set; } = new List<Constraint>();
        }
    
}
