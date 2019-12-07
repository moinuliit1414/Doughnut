using Doughnut.Dto;

namespace Doughnut.DataSource
{
    public class DataSource : IDataSource
    {
        public INode DecisionTree { get; }
        public DataSource() {
            this.DecisionTree = BuildStaticDoughnutTree();
        }
        public DataSource(INode node)
        {
            this.DecisionTree = node;
        }
        private INode BuildStaticDoughnutTree()
        {
            INode getIt = new Node("Get It.");
            INode doJumping = new Node("Do jumping Jacks first.");
            INode grabIt = new Node("What are you waiting for? Grab it now.");
            INode wait = new Node("Wait till you find a sinful.Unforgettable doughnut.");
            INode apple = new Node("May be you want an apple?");

            INode sure = new Node("Are you sure?", getIt, doJumping);
            INode good = new Node("Is it good doughnut?", grabIt, wait);
            INode deserve = new Node("Do I deserve It?", sure, good);
            INode want = new Node("Do I want a doughnut?", deserve, apple);

            return want;
        }
    }
}
