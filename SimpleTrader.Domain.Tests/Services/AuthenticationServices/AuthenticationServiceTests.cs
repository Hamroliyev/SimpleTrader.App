using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IAccountService> _mockAccountService;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private AuthenticationService _authenticationServices;
        [SetUp]
        public void SetUp()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationServices = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUsername_ResturnsAccountForCorrectUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            //Act
            Account account = await _authenticationServices.Login(expectedUsername, password);

            //Assert
            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
    }
}
