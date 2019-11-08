using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC.Abstraction
{
    public interface IRepositoryORC
    {
        TEntity GetEntityById<TEntity>(int id)
            where TEntity : BaseEntity;

        void AddAttractionType(AttractionType attractionType);

        int AddLocation(Location location);

        void AddAttraction(Attraction attraction);

        void AddUser(User user);

        void AddAccesRight(AccessRight accessRight);

        void AddComment(Comment comment);

        void AddUserToRight(int user_id, int rigth_id);

        IList<User> GetUsers();

        IList<AttractionType> GetAttractionTypes();

        User GetUserByEmailAndPassword(string email, string password);
        
        bool FindUserByEmail(string email);
        User GetUserByEmail(string email);

        bool FindAttractionTypeByTitle(string title);
        AttractionType GetAttractionTypeByTitle(string title);
        IList<Attraction> GetAttractionsByType(string attractionTitle);

        bool CheckUserPriority(User user, uint priority);
        IList<Comment> GetCommentsByAttractionId(int attractionId);

        IList<Attraction> GetAttractionById(int attractionId);

        IList<Comment> GetCommentsByAttraction(Attraction attraction);
        IList<Attraction> GetAttractions();

        void UpdateCommentById(int id, bool status);
        void UpdateRatingAttractionById(int id, bool status);

        bool Delete<TEntity>(int id)
            where TEntity : BaseEntity;
        void UpdateUserInformation(User user, string currentEmail);
    }
}
