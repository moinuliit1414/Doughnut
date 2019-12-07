using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Dto
{
    public interface ILeaf
    {
        string Statement { get; }
        bool IsSelected { get; }
        void PrintStatement();
    }
}
