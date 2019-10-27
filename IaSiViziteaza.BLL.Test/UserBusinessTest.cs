using IaSiViziteaza.BLL.Implementations;
using IaSiViziteaza.DAL.Abstraction;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using IaSiViziteaza.DAL;
using FluentAssertions;
using IaSiViziteaza.BLL.DTO;

namespace IaSiViziteaza.BLL.Test
{
    public class UserBusinessTest
    {
        private UserBusiness _systemUnderTest;
        private Mock<IRepository> _repositoryMock;

        public UserBusinessTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            _repositoryMock = mockRepository.Create<IRepository>();
            _systemUnderTest = new UserBusiness(_repositoryMock.Object);
        }
        [Fact]
        public void When_CheckUserCredential_IsCalled_WithRightCredential_TrueIsReturned()
        {
            // Arange
            var expectedResult = true;
            var userPassword = "marius123";
            var userEmail = "marius@mail.com";
            var userDTO = new UserLoginDTO()
            {
                Email = userEmail,
                Password = userPassword
            };
            var user = new User
            {
                Id = new Guid(),
                FirstName = "Marcus",
                LastName = "Lean",
                Password = userPassword,
                Email = userEmail,
                PhoneNumber = "03123123",
            };
            _repositoryMock.Setup(m => m.GetUserByEmailAndPassword<User>(userEmail, userPassword))
                .Returns(user);
            // Act

            var result = _systemUnderTest.CheckUserCredentials(userDTO);

            // Assert
            result.Should().Be(expectedResult);
        }
        [Fact]
        public void When_CheckUserCredential_IsCalled_WithWrongCredential_FalseIsReturned()
        {
            // Arange
            var expectedResult = false;
            var userPassword = "marius123";
            var userEmail = "marius@mail.com";
            var userDTO = new UserLoginDTO()
            {
                Email = userEmail,
                Password = userPassword
            };
            User user = null;
            
            _repositoryMock.Setup(m => m.GetUserByEmailAndPassword<User>(userEmail, userPassword))
                .Returns(user);
            // Act

            var result = _systemUnderTest.CheckUserCredentials(userDTO);

            // Assert
            result.Should().Be(expectedResult);
        }
        [Fact]
        public void When_Get_IsCalled_AListOfAllUser_IsReturned()
        {
            var userList = new List<User>
            {
                new User
                {
                    Id=new Guid(),
                    FirstName="Marcus",
                    LastName="Lean",
                    Password="marius123",
                    Email="marius@mail.com",
                    PhoneNumber="03123123",
               },
                new User
                {
                    Id=new Guid(),
                    FirstName="Dan",
                    LastName="Victor",
                    Password="dan12312",
                    Email="dan@mail.com",
                    PhoneNumber="031213123",
               }
            };
            _repositoryMock.Setup(m => m.Get<User>())
                .Returns(userList);
            // Act
            var result = _systemUnderTest.Get();

            // Assert
            result.Should().BeEquivalentTo(userList);
        }
        [Fact]
        public void When_AddNormalUser_IsCalled_WithANewUser_TrueIsReturned()
        {
            // Arange
            //bool expectedResult = true;
            var user = new UserRegisterDTO()
            {
                Email = "Iionel@mail.com",
                FirstName = "Lion",
                LastName = "Noine",
                Password = "102321",
                PhoneNumber = "0832131"
            };
            //QA

            _repositoryMock.Setup(m => m.FindUserByEmail(user.Email)).Returns(false);
            _repositoryMock.Setup(m => m.Add(It.IsAny<User>())).Verifiable();
            _repositoryMock.Setup(m => m.Add(It.IsAny<UserAccessRight>())).Verifiable();

            // Act
            var result = _systemUnderTest.AddNormalUser(user);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void WhenCheckUserPriorityIsCalled_TrueIsReturned()
        {
            //Arrange
            AccessRight accessRight = new AccessRight()
            {
                Priority = 20,
            };
            var user = new User()
            {
                UserAccessRights=accessRight.UserAccessRights,
                Email="Email@yahoo.com"
            };
            _repositoryMock.Setup(m => m.GetUserByEmail(user.Email)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);

            //Act
            var result = _systemUnderTest.CheckUserPriority(user.Email);

            //Asser
            result.Should().BeTrue();

        }
        [Fact]
        public void WhenUpdateUserById_IsCalled_UserCredentials_AreUpdated()
        {
            //Arrange
            var user2 = new UserUpdateDTO()
            {
                
                CurrentEmail = "nustiu@mail.com",
                NewEmail = "EmailNou@mail.com",
                NewPassword = "parola2",
                PhoneNumber = "0712345678"
                
            };
            User user = new User();
            
            _repositoryMock.Setup(m => m.GetUserByEmail(user2.CurrentEmail)).Returns(user);
            _repositoryMock.Setup(m => m.FindUserByEmail(user2.NewEmail)).Returns(false);
            _repositoryMock.Setup(m => m.UpdateUserInformation(user,user2.CurrentEmail)).Verifiable();
            //Act
           var result = _systemUnderTest.UpdateUserInformation(user2);

            //Assert
            result.Should().BeTrue();
        }

    }
}
