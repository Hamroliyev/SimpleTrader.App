using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
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

        [Test]
        public async Task Login_WithInCorrectPasswordForExistingUsername_ThrowsInvalidPaswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationServices.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.UserName;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Login_WithNonExistingUsername_ThrowsInvalidPaswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationServices.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.UserName;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Register_WithPasswordNotMatching_ReturnsPasswordDoNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmPassword";
            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            RegistrationResult actual = await _authenticationServices.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExcistingEmail_ReturnsEmailAlraedyExists()
        {
            string email = "test@gmail.com";
            _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = await _authenticationServices.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExcistingUserName_ReturnsUserNameAlraedyExists()
        {
            string userName = "testuser";
            _mockAccountService.Setup(s => s.GetByUsername(userName)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.UserNameAlreadyExists;

            RegistrationResult actual = await _authenticationServices.Register(It.IsAny<string>(), userName, It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistingUserAndMatchidPassword_ReturnsSuccess()
        {
            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = await _authenticationServices.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
    }
}
