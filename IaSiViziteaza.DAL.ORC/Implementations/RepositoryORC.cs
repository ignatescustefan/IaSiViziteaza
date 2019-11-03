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

        public void AddAttractionType(AttractionType attractionType)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_attraction_type",
                DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_TITLE", OracleDbType.Varchar2).Value = attractionType.Title;
            cmd.Parameters.Add("v_DESCRIPTION", OracleDbType.Varchar2).Value = attractionType.Description;
            cmd.Parameters.Add("v_IMAGE", OracleDbType.Varchar2).Value = attractionType.ImagePath;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }


        public int AddLocation(Location location)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_location",
                DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("v_address", OracleDbType.Varchar2).Value = location.Address;
            cmd.Parameters.Add("v_postal_code", OracleDbType.Varchar2).Value = location.PostalCode;
            cmd.Parameters.Add("v_attraction_id", OracleDbType.Int32).Direction = ParameterDirection.Output;


            try
            {
                cmd.ExecuteNonQuery();
                var x = cmd.Parameters["v_attraction_id"].Value;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
            return 0;
        }

        public void AddAttraction(Attraction attraction)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_attraction_type",
                DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_name", OracleDbType.Varchar2).Value = attraction.Name;
            cmd.Parameters.Add("v_desc", OracleDbType.Varchar2).Value = attraction.Description;
            cmd.Parameters.Add("v_open_time", OracleDbType.Date).Value = attraction.OpenTime;
            cmd.Parameters.Add("v_close_time", OracleDbType.Date).Value = attraction.CloseTime;
            cmd.Parameters.Add("v_image", OracleDbType.Varchar2).Value = attraction.ImagePath;
            cmd.Parameters.Add("v_attraction_type_id", OracleDbType.Int32).Value = attraction.AttractionType.Id;
            cmd.Parameters.Add("v_location_id", OracleDbType.Int32).Value = AddLocation(attraction.Location);
            cmd.Parameters.Add("v_user_id", OracleDbType.Int32).Value = attraction.User.Id;


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }
    //    PROCEDURE insert_user(
    //    v_first_name IN             VARCHAR2,
    //    v_last_name IN             VARCHAR2,
    //    v_email IN             VARCHAR2,
    //    v_password IN             VARCHAR2
    //);
        public void AddUser(User user)
        {
            OracleCommand cmd = new OracleCommand("", DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_first_name", OracleDbType.Varchar2).Value = user.FirstName;
            cmd.Parameters.Add("v_last_name", OracleDbType.Varchar2).Value = user.LastName;
            cmd.Parameters.Add("v_email", OracleDbType.Varchar2).Value = user.Email;
            cmd.Parameters.Add("v_password", OracleDbType.Varchar2).Value = user.Password;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        public void AddAccesRight(AccessRight accessRight)
        {
            throw new NotImplementedException();
        }

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }
        public IList<AttractionType> GetAttractionTypes()
        {
            OracleCommand cmd = new OracleCommand("get_function.get_attractiontype", DataBaseConnection.getDbInstance().GetDBConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("l_rc", OracleDbType.RefCursor, ParameterDirection.Output));
            cmd.Parameters["l_rc"].Direction = ParameterDirection.ReturnValue;

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            cmd.ExecuteNonQuery();

            OracleRefCursor t = (OracleRefCursor)cmd.Parameters[0].Value;

            OracleDataReader rdr = t.GetDataReader();
            var dataTable = rdr.GetSchemaTable();
            var list = new List<AttractionType>();
            while (rdr.Read())
            {
                System.Diagnostics.Debug.WriteLine(rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(3));
                list.Add(new AttractionType()
                {
                    Title = rdr.GetString(1),
                    Description = rdr.GetString(2),
                    ImagePath = rdr.GetString(3)
                });
            }
            return list;
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

        public IList<Attraction> GetAttractions()
        {
            throw new NotImplementedException();
        }
    }
}
