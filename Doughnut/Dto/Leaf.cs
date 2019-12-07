using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Doughnut.Dto
{
    public class Leaf : ILeaf
    {
        public string Statement { get; set; }
        public bool IsSelected { get; set; }

        public Leaf(string statement) {
            this.Statement = statement;
        }

        public virtual void PrintStatement()
        {
            Console.WriteLine(Statement);
        }
    }
}
