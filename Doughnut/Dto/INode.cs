using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Dto
{
    public interface INode 
    {
        INode LeafY { get; }
        INode LeafN { get; }
        string Statement { get; }
        bool IsSelected { get; set; }
        void PrintStatement();
    }
}
