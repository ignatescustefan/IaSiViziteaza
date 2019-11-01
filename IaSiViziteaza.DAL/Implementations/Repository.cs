using IaSiViziteaza.DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IaSiViziteaza.DAL.Implementations
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext databaseContext;

        public Repository()
        {
            databaseContext = new DatabaseContext();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
           //if(databaseContext.Users.Contains)

           
           databaseContext.Add(entity);
           databaseContext.SaveChanges();
        }

        public bool CheckUserPriority(User user,uint priority)
        {
            //var x = databaseContext.UserAccessRights
            //    .Include(userAccesRight => userAccesRight.UserId.Equals(user.Id))
            //    .Include(userAccesRight => userAccesRight.AccessRight.Priority.Equals(priority))                
            //    .Count();

            if (null == user)
                return false;
            var x = databaseContext.UserAccessRights.Where(userAccesRight => userAccesRight.UserId.Equals(user.Id))
                .Where(userAccesRight => userAccesRight.AccessRight.Priority.Equals(priority))
                .Count();


            if (x == 0)
                return false;
            return true; ;
        }

        public bool FindAttractionByTitle(string title)
        {
            var x = databaseContext.AttractionTypes.Where(attraction => attraction.Title.Equals(title))
                .Count();
            if (x == 0)
                return false;
            return true;
        }

        public bool FindUserByEmail(string email)
        {
            var x = databaseContext.Users.Where(user => user.Email.Equals(email))
                .Count();
            if (x == 0)
                return false;
            return true;
        }

        public IList<TEntity> Get<TEntity>() 
            where TEntity : BaseEntity
        {
          
            return databaseContext.Set<TEntity>()
                .ToList();
        }

        public IList<Attraction> GetAttractionsByType(string attractionTitle)
        {
            var x = databaseContext.Attractions
                .Include(attr => attr.AttractionType)
                .Where(attr => attr.AttractionType.Title.Equals(attractionTitle))
                .Include(attr => attr.User)
                .Include(attr => attr.Location)
                .ToList();
            return x;
        }
        public IList<Attraction> GetAttractions()
        {
            var x = databaseContext.Attractions
                .Include(attr => attr.AttractionType)
                .Include(attr => attr.User)
                .Include(attr => attr.Location)
                .ToList();
            return x;
        }

        public AttractionType GetAttractionTypeByTitle(string title)
        {
            return databaseContext.AttractionTypes.Where(attraction => attraction.Title.Equals(title)).ToList().FirstOrDefault();
        }

        public IList<Comment> GetCommentsByAttraction(Attraction attraction)
        {
            return databaseContext.Comments.Include(comm => comm.Attraction.Equals(attraction)).ToList();
        }

        public IList<Comment> GetCommentsByAttractionId(Guid attractionId)
        {
            return databaseContext.Attractions
                .Include(a => a.Comments)
                    .ThenInclude(c => c.User)
                .FirstOrDefault(a => a.Id == attractionId)
                .Comments
                .ToList();
        }

        public TEntity GetEntityById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return databaseContext.Set<TEntity>()
                .Where(entity => entity.Id.Equals(id)).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            var x = databaseContext.Users.Where(user => user.Email.Equals(email)).ToList().FirstOrDefault();
            return x;
        }

        public TEntity GetUserByEmailAndPassword<TEntity>(string email, string password) where TEntity : User
        {
            return databaseContext.Set<TEntity>()
                .Where(user => user.Email.Equals(email) && user.Password.Equals(password))
                .FirstOrDefault();
        }

        public void UpdateCommentById(Guid id, bool status)
        {
            if (status)
            {
                databaseContext.Comments.Where(comm => comm.Id == id)
                   .FirstOrDefault().Rating++;
            }
            else
            {
                databaseContext.Comments.Where(comm => comm.Id == id)
                   .FirstOrDefault().Rating--;
            }
            databaseContext.SaveChanges();
        }

        public bool Delete<TEntity>(Guid id) 
            where TEntity : BaseEntity
        {
            TEntity entity = GetEntityById<TEntity>(id);
            if(null!=entity && databaseContext.Set<TEntity>().Contains(entity))
            {
                databaseContext.Remove(entity);
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateRatingAttractionById(Guid id, bool status)
        {

            if (status)
            {
                databaseContext.Attractions.Where(attr => attr.Id == id)
                   .FirstOrDefault().Rating++;
            }
            else
            {
                databaseContext.Attractions.Where(attr => attr.Id == id)
                   .FirstOrDefault().Rating--;
            }
            databaseContext.SaveChanges();
        }

        public void UpdateUserInformation(User user,string currentEmail )
        {
            var x = databaseContext.Users.Where(usr => usr.Email.Contains(currentEmail))
                .FirstOrDefault();
            x.Email = user.Email;
            x.Password = user.Password;
            x.PhoneNumber = user.PhoneNumber;
            databaseContext.Users.Update(x);
            databaseContext.SaveChanges();
        }
    }
}
