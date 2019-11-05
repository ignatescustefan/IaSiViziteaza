using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC.Abstraction
{
    public interface IRepositoryORC
    {
        IList<TEntity> Get<TEntity>()
            where TEntity : BaseEntity;

        TEntity GetEntityById<TEntity>(int id)
            where TEntity : BaseEntity;

        void AddAttractionType(AttractionType attractionType);

        int AddLocation(Location location);

        void AddAttraction(Attraction attraction);

        void AddUser(User user);

        void AddAccesRight(AccessRight accessRight);

        void AddComment(Comment comment);

        IList<AttractionType> GetAttractionTypes();

        TEntity GetUserByEmailAndPassword<TEntity>(string email, string password)
            where TEntity : User;

        bool FindUserByEmail(string email);
        User GetUserByEmail(string email);

        bool FindAttractionByTitle(string title);
        AttractionType GetAttractionTypeByTitle(string title);
        IList<Attraction> GetAttractionsByType(string attractionTitle);

        bool CheckUserPriority(User user, uint priority);
        IList<Comment> GetCommentsByAttractionId(int attractionId);
        IList<Comment> GetCommentsByAttraction(Attraction attraction);
        IList<Attraction> GetAttractions();

        void UpdateCommentById(int id, bool status);
        void UpdateRatingAttractionById(int id, bool status);

        bool Delete<TEntity>(int id)
            where TEntity : BaseEntity;
        void UpdateUserInformation(User user, string currentEmail);
    }
}
