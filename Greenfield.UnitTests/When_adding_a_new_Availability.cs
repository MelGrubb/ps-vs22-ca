using Greenfield.Web.Model.Context;
using Greenfield.Web.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NUnit.Framework;

namespace Greenfield.UnitTests
{
    [TestFixture]
    public class When_adding_a_new_Availability
    {
        private EntityEntry<Availability> _result = null!;

        [SetUp]
        public void Setup()
        {
            var availability = new Availability();
            var context = new GreenfieldContext(new Microsoft.EntityFrameworkCore.DbContextOptions<GreenfieldContext>());
            _result = context.Availabilities.Add(availability);

        }

        [Test]
        public void Then_the_new_Availability_is_marked_Added()
        {
            Assert.AreEqual(Microsoft.EntityFrameworkCore.EntityState.Added, _result.State);
        }
    }
}