using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Doughnut.Dto
{
    public class Node : INode
    {
        public INode LeafY { get; set; }
        public INode LeafN { get; set;}
        public string Statement { get; set; }
        public bool IsSelected { get; set; }

        public Node(string statement, INode yes, INode no)
        {
            this.Statement = statement;
            this.LeafY = yes;
            this.LeafN = no;
        }
        public Node(string statement){
            this.Statement = statement;
        }
        
        public void PrintStatement() {
            //base.PrintStatement();
            if (LeafY != null && LeafY.IsSelected) {
                LeafY.PrintStatement();
            } else if (LeafN != null && LeafN.IsSelected) {
                LeafN.PrintStatement();
            }
        }
    }
}
