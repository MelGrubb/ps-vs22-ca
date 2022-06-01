using Greenfield.Web.Model.Context;
using Greenfield.Web.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NUnit.Framework;

namespace Greenfield.UnitTests
{
    [TestFixture]
    public class When_adding_a_new_ApplicationUser
    {
        private EntityEntry<ApplicationUser> _result = null!;

        [SetUp]
        public void Setup()
        {
            var user = new ApplicationUser();
            var context = new GreenfieldContext(new Microsoft.EntityFrameworkCore.DbContextOptions<GreenfieldContext>());
            _result = context.Users.Add(user);

        }

        [Test]
        public void Then_the_new_ApplicationUser_is_marked_Added()
        {
            Assert.AreEqual(Microsoft.EntityFrameworkCore.EntityState.Added, _result.State);
        }
    }
}