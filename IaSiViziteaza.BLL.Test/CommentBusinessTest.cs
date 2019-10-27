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
    public class CommentBusinessTest
    {
        private CommentBusiness _systemUnderTest;
        private Mock<IRepository> _repositoryMock;

        public CommentBusinessTest()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            _repositoryMock = mockRepository.Create<IRepository>();
            _systemUnderTest = new CommentBusiness(_repositoryMock.Object);
        }
        [Fact]
        public void WhenAddCommentIsCalled_WithANewComment_TrueShouldBeReturned()
        {
            //Arrange
            var comm = new CommentDTO()
            {
                 CommentContent="Comment",
                 AttractionId=new Guid(),
                 UserEmail="String@yahoo.com"
            };
            User user = new User();
            Attraction atr = new Attraction();
            _repositoryMock.Setup(m => m.GetUserByEmail(comm.UserEmail)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 10)).Returns(true);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);
            _repositoryMock.Setup(m=> m.GetEntityById<Attraction>(comm.AttractionId)).Returns(atr);
            _repositoryMock.Setup(m => m.Add(It.IsAny<Comment>())).Verifiable();

            //Act
            var result = _systemUnderTest.AddComment(comm);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void WhenGetCommentByAttractionsId_IsCalled_ItShouldReturn_AListOfComments_ForThatAttraction()
        {
            //Arrange
            var atrId = new Guid();
            var comm = new List<CommentReturnDTO>()
            {
                new CommentReturnDTO
                {
                     FirstNameUser="nush",
                     LastNameUser="nush",
                     PostingDate=DateTime.Parse("12:00"),
                     Rating=0,
                     CommentContent="Comment1",

                },
                new CommentReturnDTO
                {
                    FirstNameUser="nush",
                     LastNameUser="nush",
                     PostingDate=DateTime.Parse("13:00"),
                     Rating=3,
                     CommentContent="Comment2",
                }
            };
            var user = new User()
            {
                FirstName="nush",
                LastName="nush"
               
            };
            var comm2 = new List<Comment>()
            {
                new Comment
                {   
                     User=user,                                                       
                     PostingDate=DateTime.Parse("12:00"),
                     Rating=0,
                     CommentContent="Comment1",

                },
                new Comment
                {
                     User=user,
                     PostingDate =DateTime.Parse("13:00"),
                     Rating=3,
                     CommentContent="Comment2",
                }
            };
            _repositoryMock.Setup(m => m.GetCommentsByAttractionId(atrId)).Returns(comm2);

            //Act
            var result = _systemUnderTest.GetCommentsByAttractionId(atrId);

            //Assert
            result.Should().BeEquivalentTo(comm);
        }
        [Fact]
        public void WhenDeleteCommentById_IsCalled_TrueIsReturned()
        {
            //Arrange
            var user = new User()
            {
                Email = "Email@yahoo.com"
            };
            var comm = new Comment()
            {
                Id = new Guid(),
                CommentContent = "Comment"
            };
            _repositoryMock.Setup(m => m.GetUserByEmail(user.Email)).Returns(user);
            _repositoryMock.Setup(m => m.CheckUserPriority(user, 20)).Returns(true);
            _repositoryMock.Setup(m => m.Delete<Comment>(comm.Id)).Returns(true);

            //Act
            var result = _systemUnderTest.DeleteCommentById(comm.Id);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void WhenUpdateComment_IsCalled_CommentIsUpdated()
        {
            bool status = false;
            var comm = new Comment()
            {
                Id = new Guid(),
                CommentContent="Comment",
                Rating = 4

            };
            _repositoryMock.Setup(m => m.UpdateCommentById(comm.Id, status)).Verifiable();

            //Act
            _systemUnderTest.UpdateCommentById(comm.Id, status);

        }
    }
}
