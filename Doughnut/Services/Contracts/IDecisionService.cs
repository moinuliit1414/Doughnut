using Doughnut.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Services.Contracts
{
    public interface IDecisionService
    {
        /// <summary>
        ///     Return Nullable tree.
        /// </summary>
        /// <returns>
        ///     Return full tree from decision tree source. can be null if source is null. 
        /// </returns>
        INode GetFullTree();
        /// <summary>
        ///     Traverse through the noad and marked as selected by given answer.
        /// </summary>
        /// <param name="answers">
        ///     A List of boolean value which represent user answers in a sequential order. 
        /// </param>
        /// <returns>
        ///     Return full tree with selected mark of node as per given answer.
        /// </returns>
        INode GetTraversedTree(List<bool> answers);
        /// <summary>
        ///     Return only child tree of last answered node.
        /// </summary>
        /// <param name="answers">
        ///     A List of boolean value which represent user answers in a sequential order. 
        /// </param>
        /// <returns>
        ///     Returns INode type object node. 
        /// </returns>
        INode GetClildTree(List<bool> answers);
        /// <summary>
        ///     Return First statement of decision tree..
        /// </summary>
        /// <returns>
        ///     Return question of String type. 
        /// </returns>
        String GetFirstQuestion();
        /// <summary>
        ///     Return Not Nullable tree.
        /// </summary>
        /// <returns>
        ///     Return full tree from decision tree source.Throw NodeNotFoundException if source is null. 
        /// </returns>
        INode GetFirstNode();
        /// <summary>
        ///     Return next question depending on last questions answer.
        /// </summary>
        /// <param name="answers">
        ///     A List of boolean value which represent user answers in a sequential order. 
        /// </param>
        /// <returns>
        ///     Return nest question of String type.
        /// </returns>
        String GetCurrentQuestion(List<bool> answers);
        /// <summary>
        ///     Return longest path count.
        /// </summary>
        /// <returns>
        ///     Return int type value of longest path count. 
        /// </returns>
        int GetTreeMaxpath();


    }
}
