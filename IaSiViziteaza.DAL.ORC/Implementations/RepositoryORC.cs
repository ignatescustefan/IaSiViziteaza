using IaSiViziteaza.DAL.ORC.Abstraction;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC.Implementations
{
    public class RepositoryORC : IRepositoryORC
    {

        public RepositoryORC()
        {
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            //databaseContext.GetDBConnection();
            throw new NotImplementedException();
        }

        public void AddAttractionType(AttractionType attractionType)
        {
            OracleCommand cmd = new OracleCommand("insert_attraction_type", DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("v_TITLE", OracleDbType.Varchar2).Value = attractionType.Title;
            cmd.Parameters.Add("v_DESCRIPTION", OracleDbType.Varchar2).Value = attractionType.Description;
            cmd.Parameters.Add("v_IMAGE", OracleDbType.Varchar2).Value = attractionType.ImagePath;

            cmd.ExecuteNonQuery();

            DataBaseConnection.getDbInstance().closeDBConnection();
        }

        public IList<Attraction> GetAttractions()
        {
            //OracleCommand cmd = new OracleCommand("get_attraction", DataBaseConnection.getDbInstance().GetDBConnection());

            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Add(new OracleParameter("l_rc", OracleDbType.RefCursor, ParameterDirection.Output));
            //cmd.Parameters["l_rc"].Direction = System.Data.ParameterDirection.ReturnValue;

            //OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            //cmd.ExecuteNonQuery();

            //OracleRefCursor t = (OracleRefCursor)cmd.Parameters[0].Value;

            //OracleDataReader rdr = t.GetDataReader();
            //var dataTable = rdr.GetSchemaTable();
            //var list = new List<AttractionType>();
            //while (rdr.Read())
            //{
            //    System.Diagnostics.Debug.WriteLine(rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(3));
            //    list.Add(new AttractionType()
            //    {
            //        Title = rdr.GetString(1),
            //        Description = rdr.GetString(2),
            //        ImagePath = rdr.GetString(3)
            //    });
            //}
            //return list;
            throw new NotImplementedException();
        }

        public bool CheckUserPriority(User user, uint priority)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(Guid id) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public bool FindAttractionByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Get<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        

        public IList<Attraction> GetAttractionsByType(string attractionTitle)
        {
            throw new NotImplementedException();
        }

        public AttractionType GetAttractionTypeByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetCommentsByAttraction(Attraction attraction)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetCommentsByAttractionId(Guid attractionId)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public TEntity GetUserByEmailAndPassword<TEntity>(string email, string password) where TEntity : User
        {
            throw new NotImplementedException();
        }

        public void UpdateCommentById(Guid id, bool status)
        {
            throw new NotImplementedException();
        }

        public void UpdateRatingAttractionById(Guid id, bool status)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserInformation(User user, string currentEmail)
        {
            throw new NotImplementedException();
        }
    }
}
