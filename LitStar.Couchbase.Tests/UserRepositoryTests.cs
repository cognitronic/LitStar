using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LitStar.Core;
using LitStar.Core.Domain.User;
using LitStar.Infrastructure.UnitOfWork;
using LitStar.Couchbase.Repositories;
using Couchbase.Operations;
using Couchbase.Configuration;
using Enyim.Caching.Memcached;
using Moq;

namespace LitStar.Couchbase.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Succeed_When_Bootstrapping_To_GetCurrentSession()
        {
            var client = LitStar.Couchbase.SessionFactory.GetCurrentSession();

            string key = Guid.NewGuid().ToString(), value = Guid.NewGuid().ToString();
            var storeResult = client.ExecuteStore(StoreMode.Add, key, value);
            Assert.NotNull(storeResult);
            var getResult = client.ExecuteGet(key);
            Assert.NotNull(getResult);
            
            client.Remove(key);
            getResult = client.ExecuteGet(key);
            Assert.Equal(getResult.Success, false);
        }

        [Fact]
        public void TestUserRepository_Should_Insert_Document()
        {
            LitStar.Couchbase.SessionFactory.GetCurrentSession();

            Staff accountToBeAmended = new Staff();
            Staff accountToBeRemoved = new Staff();
            Staff accountToBeAdded = new Staff();
            accountToBeAdded.ID = Guid.NewGuid().ToString();
            accountToBeAdded.FirstName = "Danny";
            accountToBeAdded.LastName = "Schreiber";
            accountToBeAdded.Address1 = "2920 Tanbark Ln";
            accountToBeAdded.Birthdate = DateTime.Parse("08/15/1976");
            accountToBeAdded.City = "Turlock";
            accountToBeAdded.DateCreated = DateTime.Now;
            accountToBeAdded.Email = "briana@ravenartmedia.com";
            accountToBeAdded.ChangedBy = Guid.NewGuid();
            accountToBeAdded.IsActive = true;
            accountToBeAdded.LastLoggedIn = DateTime.Now;
            accountToBeAdded.LastUpdated = DateTime.Now;
            accountToBeAdded.ManagerID = Guid.NewGuid();
            accountToBeAdded.AccountID = 2;
            accountToBeAdded.Password = "password";
            accountToBeAdded.PayFrequency = "1";
            accountToBeAdded.PayRate = 50;
            accountToBeAdded.Phone = "2095598896";
            accountToBeAdded.SecurityAnswer = "password";
            accountToBeAdded.SecurityQuestion = "password";
            accountToBeAdded.State = "CA";
            accountToBeAdded.SystemID = Guid.NewGuid();
            accountToBeAdded.Title = "Director";
            accountToBeAdded.Zip = "95355";
            accountToBeAdded.EnteredBy = Guid.NewGuid();


           

            var unitOfWorkMockery = new Mock<IUnitOfWork>();

            UserRepository _repository = new UserRepository(unitOfWorkMockery.Object);

            unitOfWorkMockery.Setup(uow => uow.RegisterAmended(accountToBeAmended, _repository));

            unitOfWorkMockery.Setup(uow => uow.RegisterNew(accountToBeAdded, _repository));

            unitOfWorkMockery.Setup(uow => uow.RegisterRemoved(accountToBeRemoved, _repository));

            var accountAddedResult = _repository.Add(accountToBeAdded);

            Assert.NotNull(accountAddedResult);
            Assert.IsType<int>(accountAddedResult);

            //accountToBeRemoved = accountToBeAdded;
            //var removeResult = _repository.Remove(accountToBeRemoved);
            //Assert.NotNull(removeResult);
            //Assert.IsType<int>(removeResult);
        }
    }
}
