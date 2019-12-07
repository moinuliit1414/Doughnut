using Doughnut.DataSource;
using Doughnut.Services.Contracts;
using Doughnut.Services.Implementation;
using Doughnut.Types.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Doughnut.NTest
{
    public class Services
    {
        IDataSource _dataSource;
        IDecisionService _service;
        [SetUp]
        public void Setup()
        {
            _dataSource = new DataSource.DataSource();
            _service = new DecisionService(_dataSource);
        }
        [Test]
        public void Test2() {
            Assert.GreaterOrEqual(3, _service.GetTreeMaxpath());
        }
        [Test]
        //[ExpectedException(typeof(NodeNotFoundException))]
        public void Test1()
        {
            List<bool> answers = new List<bool>();
            answers.Add(false);
            answers.Add(false);
            //_service.GetCurrentQuestion(answers);
            //ActualValueDelegate<object> testDelegate = () => _service.GetCurrentQuestion(answers);
            //Assert.That(testDelegate, Throws.TypeOf<NodeNotFoundException>());
            //Assert.That(() => _service.GetCurrentQuestion(answers),Throws.TypeOf<NodeNotFoundException>());
            //Assert.Throws<NodeNotFoundException>(() => _service.GetCurrentQuestion(answers));
            var ex = Assert.Throws<NodeNotFoundException>(() => _service.GetCurrentQuestion(answers));
            Assert.That(ex.Code == "DOEX404");
        }
    }
}