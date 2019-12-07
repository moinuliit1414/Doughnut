using Doughnut.DataSource;
using Doughnut.Dto;
using Doughnut.Services.Contracts;
using Doughnut.Types.Exceptions;
using System;
using System.Collections.Generic;
using DeepCopy;
using System.Linq;

namespace Doughnut.Services.Implementation
{
    public class DecisionService : IDecisionService
    {
        private IDataSource _dataSource;
        public DecisionService(IDataSource dataSource) {
            _dataSource = dataSource;
        }
        public INode GetClildTree(List<bool> answers)
        {
            return GetTraversedTree(answers.ToList(), _dataSource.DecisionTree);
        }

        public string GetCurrentQuestion(List<bool> answers)
        {
           return GetTraversedTree(answers.ToList(), _dataSource.DecisionTree).Statement;
        }

        public INode GetFirstNode()
        {
            if (_dataSource.DecisionTree == null)
            {
                throw new NodeNotFoundException();
            }

            return _dataSource.DecisionTree;
        }

        public string GetFirstQuestion()
        {            
            return GetFirstNode().Statement;            
        }

        public INode GetFullTree()
        {
            return _dataSource.DecisionTree;
        }

        public INode GetTraversedTree(List<bool> answers)
        {
            //Deep Clone Original Data Source.
            INode node = DeepCopier.Copy(_dataSource.DecisionTree);
            //node = node.DeepClone();
            GetTraversedTree(answers.ToList(), ref node);
            return node;
        }

        public int GetTreeMaxpath()
        {
           return LongestPath(_dataSource.DecisionTree, 0);
        }

        private void GetTraversedTree(List<bool> answers, ref INode noad) {
            noad.IsSelected = true;
            if (answers == null || answers.Count <= 0)
            {
                return;

            }

            bool answer = answers.ElementAt(0);
            answers.RemoveAt(0);
            if (answer && noad.LeafY != null)
            {
                INode leafY = noad.LeafY;
                //ToList() to copy in another ref.
                GetTraversedTree(answers.ToList(), ref leafY);
            }
            else if (!answer && noad.LeafN != null)
            {
                INode leafN = noad.LeafN;
                //ToList() to copy in another ref.
                GetTraversedTree(answers.ToList(), ref leafN);
            }
            else
            {
                throw new NodeNotFoundException();
            }

        }
        private INode GetTraversedTree(List<bool> answers, INode noad) {

            if (answers==null || answers.Count <= 0) {
                return noad;
            }
            
            bool answer = answers.ElementAt(0);
            answers.RemoveAt(0);
            if (answer && noad.LeafY != null) {
                //ToList() to copy in another ref.
                return GetTraversedTree(answers.ToList(), noad.LeafY);
            } else if (!answer && noad.LeafN != null) {
                //ToList() to copy in another ref.
                return GetTraversedTree(answers.ToList(), noad.LeafN);                
            }
            else {
                throw new NodeNotFoundException();
            }
        }

        private int LongestPath(INode node, int value)
        {
            if (node == null) {
                return 0;
            }
            int i = value, j = value;
            if (node.LeafY != null)
            {
                i = LongestPath(node.LeafY, value + 1);
            }
            if (node.LeafN != null)
            {
                j = LongestPath(node.LeafN, value + 1);
            }
            return i >= j ? i : j;
        }
    }
}
