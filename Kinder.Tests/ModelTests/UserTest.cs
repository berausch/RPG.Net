using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder.Models;
using Xunit;

namespace Kinder.Tests
{
    public class UserTest
    {
        [Fact]
        public void GetUserNameTest()
        {
            //Arrange
            var user = new ApplicationUser();
            user.UserName = "Fred";

            //Act
            var result = user.UserName;

            //Assert
            Assert.Equal("Fred", result);
        }
    }
}
