using DeepCopy;
using Doughnut.DataSource;
using Doughnut.Dto;
using Doughnut.Services.Contracts;
using Doughnut.Services.Implementation;
using Doughnut.Types.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Doughnut.Test
{
    public class DecisionServiceTest
    {
        [Fact]
        public void TestFirstQuestion()
        {
            IDataSource dataSource = new DataSource.DataSource(BuildStaticDoughnutTree());
            IDecisionService _service = new DecisionService(dataSource);
            Assert.Equal(dataSource.DecisionTree.Statement, _service.GetFirstQuestion());
            //Assert.(3, _service.GetTreeMaxpath());
        }
        [Fact]
        public void TestNextQuestion()
        {
            IDataSource dataSource = new DataSource.DataSource(BuildStaticDoughnutTree());
            IDecisionService service = new DecisionService(dataSource);
            Assert.Equal(dataSource.DecisionTree.LeafN.Statement, service.GetCurrentQuestion(new List<bool> { false}));
            //Assert.(3, _service.GetTreeMaxpath());
        }
        [Fact]
        public void TestNullDatasourceHandeler()
        {
            IDataSource dataSource = new DataSource.DataSource(null);
            IDecisionService service = new DecisionService(dataSource);
            Assert.Throws<NodeNotFoundException>(() => service.GetFirstQuestion());
            Assert.Throws<NodeNotFoundException>(() => service.GetFirstNode());
            Assert.Null(service.GetFullTree());
            //Assert.(3, _service.GetTreeMaxpath());
        }
        [Fact]
        public void TestInvalidAnswer()
        {
            IDataSource dataSource = new DataSource.DataSource(BuildStaticDoughnutTree());
            IDecisionService service = new DecisionService(dataSource);
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { false,false }));
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { true, true,true,true}));
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { true, true, false, true }));
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { true, true, false, false }));
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { true, false, true, false }));
            Assert.Throws<NodeNotFoundException>(() => service.GetCurrentQuestion(new List<bool> { true, false, false, false }));

            //Assert.(3, _service.GetTreeMaxpath());
        }
        [Fact]
        public void TestValidNoad()
        {
            IDataSource dataSource = new DataSource.DataSource(BuildStaticDoughnutTree());
            INode node = DeepCopier.Copy(dataSource.DecisionTree);
            IDecisionService service = new DecisionService(dataSource);
            Assert.True(JsonConvert.SerializeObject(node.LeafY).Equals(JsonConvert.SerializeObject(service.GetClildTree(new List<bool> { true }))));
            Assert.True(JsonConvert.SerializeObject(node.LeafY.LeafY).Equals(JsonConvert.SerializeObject(service.GetClildTree(new List<bool> { true, true }))));
            Assert.True(JsonConvert.SerializeObject(node.LeafY.LeafY.LeafY).Equals(JsonConvert.SerializeObject(service.GetClildTree(new List<bool> { true, true,true }))));
            Assert.True(JsonConvert.SerializeObject(node.LeafN).Equals(JsonConvert.SerializeObject(service.GetClildTree(new List<bool> { false }))));
        }
        [Fact]
        public void MaxPath()
        {
            IDataSource dataSource = new DataSource.DataSource();
            IDecisionService service = new DecisionService(dataSource);
            Assert.True(service.GetTreeMaxpath() >= 3);

            dataSource = new DataSource.DataSource(null);
            service = new DecisionService(dataSource);
            Assert.True(service.GetTreeMaxpath() == 0);
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
