using System.Collections.Generic;
using Couchbase.Core;
using Couchbase.Data.Example.Controllers;
using Couchbase.Data.Example.Models.DAOs;
using Couchbase.Data.Example.Models.DTOs;
using Couchbase.Data.Example.Tests.Fakes;
using Couchbase.IO;
using Couchbase.N1QL;
using Moq;
using NUnit.Framework;

namespace Couchbase.Data.Example.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void When_Index_Called_10_Items_Are_Returned()
        {
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Query<Beer>(It.IsAny<IQueryRequest>()))
                .Returns(() => new FakeQueryResult<Beer>
                {
                    Success = true,
                    Rows = new List<Beer>
                    {
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer(),
                        new Beer()
                    }
                });
            var beerDao = new BeerDao(bucket.Object);
            var controller = new HomeController(beerDao);
            dynamic viewResult = controller.Index();
            Assert.AreEqual(10, viewResult.Model.Count);
        }

        [Test]
        [Category("Integrated")]
        public void When_Index_Called_10_Items_Are_Returned_Integrated()
        {
            ClusterHelper.Initialize();
            var controller = new HomeController();
            dynamic viewResult = controller.Index();
            Assert.AreEqual(10, viewResult.Model.Count);
        }

        [Test]
        public void When_Edit_GET_Called_Beer_Poco_Is_Returned()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.GetDocument<Beer>(It.IsAny<string>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.Success,
                    Success = true,
                    Content = beer,
                    Document = new Document<Beer>
                    {
                        Content = beer,
                        Id = beer.Id
                    }
                });

            var beerDao = new BeerDao(bucket.Object);
            var controller = new HomeController(beerDao);
            dynamic viewResult = controller.Edit("beer1");
            Assert.AreEqual("beer1", viewResult.Model.Id);
        }

        [Test]
        [Category("Integrated")]
        public void When_Edit_GET_Called_Beer_Poco_Is_Returned_Integrated()
        {
            ClusterHelper.Initialize();
            var controller = new HomeController();
            dynamic viewResult = controller.Index();

            var beer = controller.Edit(viewResult.Model[0].Id);
            Assert.IsNotNull(beer);
        }
    }
}
