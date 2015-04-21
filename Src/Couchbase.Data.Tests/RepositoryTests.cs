using Couchbase.Data.DAL;
using Couchbase.Data.RepositoryExample.Models.Repositories;
using Couchbase.Data.Tests.Documents;
using NUnit.Framework;

namespace Couchbase.Data.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void Test_Get()
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("beer-sample"))
                {
                    var breweryRepository = new Repository<Couchbase.Data.RepositoryExample.Models.Brewery>(bucket);
                    var brewery = breweryRepository.Find("21st_amendment_brewery_cafe");
                    var document = brewery.Content;

                    breweryRepository.Save(brewery);

                }
            }
        }

        [Test]
        public void Test_Create()
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("beer-sample"))
                {
                    var repository = new BeerRepository(bucket);
                    var beer = new Couchbase.Data.RepositoryExample.Models.Beer
                    {
                        Id = "bud_light",
                        Name = "Bud Light",
                        Type = "beer"
                    };
                    repository.Save(beer);

                }
            }
        }
    }
}