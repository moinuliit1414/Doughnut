using Doughnut.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.DataSource
{
    public interface IDataSource
    {
        INode DecisionTree { get; }
    }
}
