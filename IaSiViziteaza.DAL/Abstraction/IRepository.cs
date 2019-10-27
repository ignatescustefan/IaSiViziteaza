using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL.Abstraction
{
    public interface IRepository
    {
        IList<TEntity> Get<TEntity>()
            where TEntity : BaseEntity;

        TEntity GetEntityById<TEntity>(Guid id)
            where TEntity : BaseEntity;

        void Add<TEntity>(TEntity entity)
            where TEntity : class;

        TEntity GetUserByEmailAndPassword<TEntity>(string email, string password)
            where TEntity : User;

        bool FindUserByEmail(string email);
        User GetUserByEmail (string email);

        bool FindAttractionByTitle(string title);
        AttractionType GetAttractionTypeByTitle(string title);
        IList<Attraction> GetAttractionsByType(string attractionTitle);

        bool CheckUserPriority(User user, uint priority);
        IList<Comment> GetCommentsByAttractionId(Guid attractionId);
        IList<Comment> GetCommentsByAttraction(Attraction attraction);
        IList<Attraction> GetAttractions();

        void UpdateCommentById(Guid id, bool status);
        void UpdateRatingAttractionById(Guid id, bool status);

        bool Delete<TEntity>(Guid id)
            where TEntity : BaseEntity;
        void UpdateUserInformation(User user,string currentEmail);
    }
}
