using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LitStar.Core;
using LitStar.Core.Domain.User;
using LitStar.Services.Implementations;

namespace LitStar.Services.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public void GetUserAccountByEmailTest()
        {
            var repository = new LitStar.Couchbase.Repositories.UserRepository( new Couchbase.CouchbaseUnitOfWork());
            var cache = new LitStar.Services.Cache.CacheStorage.CouchbaseCacheAdapter();
            var uow = new LitStar.Couchbase.CouchbaseUnitOfWork();
            var service = new UserService(repository, cache, uow);
            var response = service.GetUserByEmail("danny@ravenartmedia.com");
            Assert.NotNull(response);
            Assert.Equal("danny@ravenartmedia.com", response.SelectedUser.Username);
        }
    }
}
