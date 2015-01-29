using System.Collections.Generic;
using System.Linq;
using System.Net;
using Couchbase.Core;
using Couchbase.Data.DAO;
using Couchbase.Data.Tests.Documents;
using Couchbase.Data.Tests.Fakes;
using Couchbase.IO;
using Couchbase.N1QL;
using Couchbase.Views;
using Moq;
using NUnit.Framework;

namespace Couchbase.Data.Tests
{
    [TestFixture]
    public class DataTransferObjectTests
    {
        [Test]
        public void When_Upsert_Called_And_AuthenticationError_Is_Returned_Throw_AuthenticationException()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Upsert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.AuthenticationError,
                    Success = false
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<CouchbaseAuthenticationException>(() => dao.Upsert(beer));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Insert_Called_And_AuthenticationError_Is_Returned_Throw_AuthenticationException()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Insert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.AuthenticationError,
                    Success = false
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<CouchbaseAuthenticationException>(() => dao.Insert(beer));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Insert_Called_And_Document_Exists_Throw_DocumentExistsException()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Insert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.KeyExists,
                    Message = "The Key Exists",
                    Success = false
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<DocumentExistsException>(() => dao.Insert(beer));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Insert_Called_And_Document_Does_Not_Exists_Operation_Completes()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Insert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.Success,
                    Success = true
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            dao.Insert(beer);
            bucket.VerifyAll();
        }

        [Test]
        public void When_Upsert_Called_And_Document_Does_Not_Exists_Operation_Completes()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Upsert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.Success,
                    Success = true
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            dao.Upsert(beer);
            bucket.VerifyAll();
        }

        [Test]
        public void When_Upsert_Called_And_Document_Exists_Operation_Completes()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Upsert(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.Success,
                    Success = true
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            dao.Upsert(beer);
            bucket.VerifyAll();
        }

        [Test]
        public void When_Update_Called_And_Document_Exists_Operation_Completes()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Replace(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.Success,
                    Success = true
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            dao.Update(beer);
            bucket.VerifyAll();
        }

        [Test]
        public void When_Update_Called_And_Document_Does_Not_Exist_DocumentNotFoundException_Is_Thrown()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Replace(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.KeyNotFound,
                    Success = false
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<DocumentNotFoundException>(() => dao.Update(beer));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Update_Called_And_Document_Is_Too_Big_CouchbaseDataException_Is_Thrown()
        {
            var beer = new Beer
            {
                Id = "beer1"
            };

            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Replace(It.IsAny<Document<Beer>>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.ValueTooLarge,
                    Success = false
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<CouchbaseDataException>(() => dao.Update(beer));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Select_Is_Called_And_Document_Exists_It_is_Returned()
        {
            var beer = new Beer
            {
                Id = "beer1",
                Name = "Bud"
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

            var dao = new DataAccessObject<Beer>(bucket.Object);
            var result = dao.Select("the_key");
            Assert.AreEqual(beer.Name, result.Name);
            bucket.VerifyAll();
        }

        [Test]
        public void When_Select_Is_Called_And_Document_Does_Not_Exist_DocumentNotFoundException_Is_Thrown()
        {
            var beer = new Beer
            {
                Id = "beer1",
                Name = "Bud"
            };
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.GetDocument<Beer>(It.IsAny<string>()))
                .Returns(() => new FakeDocumentResult<Beer>
                {
                    Status = ResponseStatus.KeyNotFound,
                    Success = false,
                    Content = beer
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            Assert.Throws<DocumentNotFoundException>(() => dao.Select("the_key"));
            bucket.VerifyAll();
        }

        [Test]
        public void When_Query_Is_Valid_ViewQuery_Succeeds()
        {
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Query<Beer>(It.IsAny<IViewQuery>()))
                .Returns(() => new FakeViewResult<Beer>
                {
                    Success = true,
                    Rows = new List<ViewRow<Beer>>
                    {
                        new ViewRow<Beer> {Id = "beer1", Key = "beer1", Value = new Beer()},
                        new ViewRow<Beer> {Id = "beer1", Key = "beer1", Value = new Beer()}
                    }
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            var query = new ViewQuery()
                .Bucket("beer-sample")
                .DesignDoc("beer")
                .View("brewery_beers");

            var result = dao.Select(query);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void When_Query_Is_Not_Valid_ViewQuery_Throws_ViewRequestException()
        {
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Query<Beer>(It.IsAny<IViewQuery>()))
                .Returns(() => new FakeViewResult<Beer>
                {
                    Success = false,
                    Rows = new List<ViewRow<Beer>>(),
                    StatusCode = HttpStatusCode.InternalServerError,
                    Error = "View was not found",
                    Message = "View was not found"
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            var query = new ViewQuery()
                .Bucket("beer-sample")
                .DesignDoc("beer")
                .View("brewery-beers");

           var exception = Assert.Throws<ViewRequestException>(()=> dao.Select(query));
           Assert.AreEqual(HttpStatusCode.InternalServerError, exception.StatusCode);
           Assert.AreEqual("View was not found", exception.Message);
        }

        [Test]
        public void When_QueryRequest_Is_Valid_N1QL_Query_Succeeds()
        {
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Query<Beer>(It.IsAny<IQueryRequest>()))
                .Returns(() => new FakeQueryResult<Beer>
                {
                    Success = true,
                    Rows = new List<Beer>
                    {
                        new Beer(),
                        new Beer()
                    }
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            var query = new QueryRequest()
                .Statement("SELECT Name from `beer-sample` LIMIT $1")
                .AddPositionalParameter(2);

            var results = dao.Select(query);
            Assert.AreEqual(2, results.Count());
        }

        [Test]
        public void When_QueryRequest_Is_Not_Valid_N1QL_Query_Throws_QueryRequestException()
        {
            var bucket = new Mock<IBucket>();
            bucket.Setup(x => x.Query<Beer>(It.IsAny<IQueryRequest>()))
                .Returns(() => new FakeQueryResult<Beer>
                {
                    Success = false,
                    Rows = new List<Beer>(),
                    Status = QueryStatus.Errors,
                    Message = "'fro' is not a keyword",
                    Errors = new List<Error> { new Error { Code = 1, Message = "'fro' is not a keyword" } }
                });

            var dao = new DataAccessObject<Beer>(bucket.Object);
            var query = new QueryRequest()
                .Statement("SELECT Name fro `beer-sample` LIMIT $1")
                .AddPositionalParameter(2);

            var exception =  Assert.Throws<QueryRequestException>(() => dao.Select(query));
            Assert.AreEqual(QueryStatus.Errors, exception.QueryStatus);
            Assert.IsTrue(exception.Message.Contains("'fro' is not a keyword"));
        }
    }
}
