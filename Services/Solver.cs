using SolverLP_IP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverLP_IP.Services
{
    public abstract class Solver
    {
        public abstract void Solve(LinearModel model);
    }
}
