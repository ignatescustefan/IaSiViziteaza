using FluentAssertions;
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
    public class AttractionBusinessTest
    {
        private AttractionBusiness _systemUnderTest;
        private Mock<IRepository> _repositoryMock;

        public AttractionBusinessTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            _repositoryMock = mockRepository.Create<IRepository>();
            _systemUnderTest = new AttractionBusiness(_repositoryMock.Object);
        }
        [Fact]

        public void WhenAddAttraction_IsCalled_WithANewAttraction_TrueIsReturned()
        {
            //Arrange
            var attraction = new AttractionDTO()
            {
                Title = " Palat",
                Name = "Palatul Culturii",
                Description = "Descriere",
                PhoneNumber = "07220",
                Address= "str dsa gdfas",
                PostalCode= 31231,
                EmailUser = "Palat@yahoo.com",
                OpenTime = TimeSpan.Parse("08:00:00"),
                CloseTime = TimeSpan.Parse("20:00:00"),

            };
            AttractionType attractionType = new AttractionType();
            User user = new User() ;
            _repositoryMock.Setup(m => m.GetUserByEmail(attraction.EmailUser)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);
            _repositoryMock.Setup(m => m.Add(It.IsAny<Attraction>())).Verifiable();
            _repositoryMock.Setup(m => m.GetAttractionTypeByTitle(attraction.Title)).Returns(attractionType);
            //Act
            var result = _systemUnderTest.AddAttraction(attraction);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void When_Get_IsCalled_AListOfAllattractions_IsReturned()
        {
            //Arrange
            var loc = new Location()
            {
                Address = "Str sdaa",
                PostalCode = 4324

            };
            var user = new User()
            {
                FirstName = "Alex",
                LastName = "Macovei"
            };
            var atrtyp = new AttractionType()
            {
                Title = "Palat"
            };
            var atrList = new List<Attraction>
            {
                new Attraction()
                { 
                    AttractionType=atrtyp,
                    Location=loc,
                    Name = "Palatul Culturii",
                    Description = "descriere",
                    PhoneNumber = "07220",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00"),
                    User=user
                },
                new Attraction()
                {   Location =loc,
                    AttractionType=atrtyp,
                    Name = "Palatul Culturii2",
                    Description = "descriere2",
                    PhoneNumber = "072202",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00"),
                    User=user
                }

            };
            var atrList2 = new List<AttractionReturnDTO>
            {
                new AttractionReturnDTO()
                {
                    Title="Palat",
                    FirstNameUser="Alex",
                    LastNameUser="Macovei",
                    Address="Str sdaa",
                    PostalCode=4324,
                    Name = "Palatul Culturii",
                    Description = "descriere",
                    PhoneNumber = "07220",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00")
                },
                new AttractionReturnDTO()
                {
                    Title ="Palat",
                    FirstNameUser="Alex",
                    LastNameUser="Macovei",
                    Address="Str sdaa",
                    PostalCode=4324,
                    Name = "Palatul Culturii2",
                    Description = "descriere2",
                    PhoneNumber = "072202",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00")
                }

            };
            _repositoryMock.Setup(m => m.GetAttractions()).Returns(atrList);

            //Act
            var result = _systemUnderTest.GetAttraction();

            //Assert
            result.Should().BeEquivalentTo(atrList2);
        }
        //TODO:Need GetAttractionByType
        [Fact]
        public void WhenGetAttractionByType_IsCalled_AllAttractionsOfThatType_AreReturned()
        {
            //Arrange
            var atrTitle = "Muzeu";
            var loc = new Location()
            {
                Address = "Str sdaa",
                PostalCode = 4324
            };
            var user = new User()
            {
                FirstName = "Alexandru",
                LastName = "Macovei"
            };
            var atrtyp = new AttractionType()
            {
                Title = "Muzeu"
            };
            var atrtyp2 = new AttractionType()
            {
                Title = "Gradina"
            };
            var atrList = new List<AttractionReturnDTO>
            {
                new AttractionReturnDTO()
                {

                Title=atrTitle,
                Name = "Palatul Culturii",
                Address= "Str sdaa",
                FirstNameUser="Alexandru",
                LastNameUser="Macovei",
                AttractionId= new Guid(),
                CreateAtractionTime=DateTime.Parse("12:00"),
                PostalCode=4324,
                Description = "Descriere",
                PhoneNumber = "07220",
                OpenTime = TimeSpan.Parse("08:00:00"),
                CloseTime = TimeSpan.Parse("20:00:00")
                },
                new AttractionReturnDTO()
                {
                    Title ="Gradina",
                    Address="Str sdaa",
                    FirstNameUser="Alexandru",
                    LastNameUser="Macovei",
                    AttractionId=new Guid(),
                    CreateAtractionTime=DateTime.Parse("13:00"),
                    PostalCode=4324,
                    Name = "Parcul Copou",
                    Description = "Descriere2",
                    PhoneNumber = "072202",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00")
                }
            };
            var atr = new List<Attraction>

            {
                new Attraction()
                {
                    Location =loc,
                    AttractionType=atrtyp,
                    User=user,
                    Name = "Palatul Culturii",
                    CreateAtractionTime=DateTime.Parse("12:00"),
                    Description = "Descriere",
                    PhoneNumber = "07220",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00")
                },
                new Attraction()
                {
                    Location =loc,
                    AttractionType=atrtyp2,
                    User=user,
                    CreateAtractionTime=DateTime.Parse("13:00"),
                    Name = "Parcul Copou",
                    Description = "Descriere2",
                    PhoneNumber = "072202",
                    OpenTime = TimeSpan.Parse("08:00:00"),
                    CloseTime = TimeSpan.Parse("20:00:00")
                }

            };
            AttractionType attractionType = new AttractionType();
            _repositoryMock.Setup(m => m.GetAttractionTypeByTitle(atrTitle)).Returns(attractionType);
            _repositoryMock.Setup(m => m.GetAttractionsByType(atrTitle)).Returns(atr);
            //Act
            var result = _systemUnderTest.GetAttractionsByType(atrTitle);

            //Assert
            result.Should().BeEquivalentTo(atrList);

        }
        [Fact]
        public void WhenDeleteAttractionById_IsCalled_TrueIsReturned()
        {
            //Arrange
            var user = new User()
            {
                Email ="Email@yahoo.com"
            };
            var attraction = new Attraction()
            {
                Id = new Guid(),
                Name = "Palatul Culturii",
                Description = "Descriere",
                PhoneNumber = "07220",
                OpenTime = TimeSpan.Parse("08:00:00"),
                CloseTime = TimeSpan.Parse("20:00:00"),

            };
            _repositoryMock.Setup(m => m.GetUserByEmail(user.Email)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);
            _repositoryMock.Setup(m => m.Delete<Attraction>(attraction.Id)).Returns(true);

            //Act
            var result = _systemUnderTest.DeleteAttractionById(attraction.Id);

            //Assert
            result.Should().BeTrue();

        }
        [Fact]
        public void WhenUpdateRatingIsCalled_TheRatingOfTheAttraction_IsUpdated()
        {
            //Arrange

            bool status = false;
            var atr = new Attraction()
            {
                Id = new Guid(),
                Rating = 4

            };
            _repositoryMock.Setup(m => m.UpdateRatingAttractionById(atr.Id, status)).Verifiable();

            //Act
            _systemUnderTest.UpdateRatingAttractionById(atr.Id, status);
        }
    }
}
