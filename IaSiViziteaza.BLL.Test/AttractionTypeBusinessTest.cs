using FluentAssertions;
using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.BLL.Implementations;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IaSiViziteaza.BLL.Test
{
    public class AttractionTypeBusinessTest
    {
        private AttractionTypeBussines _systemUnderTest;
        private Mock<IRepository> _repositoryMock;

        public AttractionTypeBusinessTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            _repositoryMock = mockRepository.Create<IRepository>();
            _systemUnderTest = new AttractionTypeBussines(_repositoryMock.Object);
        }
        [Fact]
        public void WhenAddAttractionType_IsCalled_WithANewAttraction_TrueIsReturned()
        {
            //Arrange
            var attractionType = new AttractionType()
            {
                Title = "Muzeu",
                Description = "Descriere"
                
                
            };
            _repositoryMock.Setup(m => m.Add(It.IsAny<AttractionType>())).Verifiable();
            _repositoryMock.Setup(m => m.FindAttractionByTitle(attractionType.Title)).Returns(false);

            //Act
            var result = _systemUnderTest.AddAttractionType(attractionType);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void When_Get_IsCalled_AListOfAllAttractionTypes_IsReturned()
        {
            //Arrange
            var atrTypeList = new List<AttractionType>
            {
                new AttractionType
                {
                     Description="Descriere",
                     Title="Titlu"


                },
                new AttractionType
                {
                     Title="Titlu2",
                     Description="Descriere2",

                }
                };

            _repositoryMock.Setup(m => m.Get<AttractionType>()).Returns(atrTypeList);

            //Act
            var result = _systemUnderTest.GetAttractionTypes();


            //Assert
            result.Should().BeEquivalentTo(atrTypeList);

            
        }
        [Fact]
        public void WhenDeleteAttractionTypeById_IsCalled_TrueIsReturned()
        {
            //Arrange
            var user = new User()
            {
                Email = "Email@yahoo.com"
            };
            var atrtype = new AttractionType()
            {
                Id = new Guid(),
                Title="Muzeu"
                 
            };
            _repositoryMock.Setup(m => m.GetUserByEmail(user.Email)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);
            _repositoryMock.Setup(m => m.Delete<AttractionType>(atrtype.Id)).Returns(true);

            //Act
            var result = _systemUnderTest.DeleteAttractionTypeById(atrtype.Id);

            //Assert
            result.Should().BeTrue();

        }
    }
}
