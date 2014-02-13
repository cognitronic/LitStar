using System;
using Xunit;
using LitStar.Core;
using LitStar.Core.Domain.User;


namespace LitStar.Core.Tests
{
    public class Domain_AccountTests
    {
        [Fact]
        public void TestAccountFactory_Should_Create_Learner_Account_Named_Testy()
        {
            Learner learner = new Learner();

            IUser account = UserFactory.CreateConcreteUser(learner);
            account.Username = "danny@ravenartmedia.com";

            Assert.IsType(typeof(Learner), account);
            Assert.Equal("danny@ravenartmedia.com", account.Username);
        }

        [Fact]
        public void TestAccountFactory_Should_Create_Staff_Account_Named_Testy()
        {
            Staff staff = new Staff();

            IUser account = UserFactory.CreateConcreteUser(staff);
            account.Username = "danny@ravenartmedia.com";

            Assert.IsType(typeof(Staff), account);
            Assert.Equal("danny@ravenartmedia.com", account.Username);
        }
    }
}
