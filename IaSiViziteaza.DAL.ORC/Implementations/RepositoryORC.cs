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
                DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

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
                DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("v_address", OracleDbType.Varchar2, ParameterDirection.Input).Value = location.Address;
            cmd.Parameters.Add("v_postal_code", OracleDbType.Varchar2, ParameterDirection.Input).Value = location.PostalCode.ToString();
            cmd.Parameters.Add("v_attraction_id", OracleDbType.Int32, ParameterDirection.Input).Value = null;
            cmd.Parameters.Add("v_location_id", OracleDbType.Int32, ParameterDirection.Output);

            try
            {
                cmd.ExecuteNonQuery();
                var result = cmd.Parameters["v_location_id"].Value;

                return int.Parse(result.ToString());
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
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_attraction",
                DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_name", OracleDbType.Varchar2).Value = attraction.Name;
            cmd.Parameters.Add("v_desc", OracleDbType.Varchar2).Value = attraction.Description;
            cmd.Parameters.Add("v_open_time", OracleDbType.Varchar2).Value = DateTime.Parse(attraction.OpenTime.ToString());
            cmd.Parameters.Add("v_close_time", OracleDbType.Varchar2).Value = DateTime.Parse(attraction.CloseTime.ToString());
            cmd.Parameters.Add("v_phone_number", OracleDbType.Varchar2).Value = attraction.PhoneNumber;
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

        public void AddUser(User user)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_user", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_first_name", OracleDbType.Varchar2).Value = user.FirstName;
            cmd.Parameters.Add("v_last_name", OracleDbType.Varchar2).Value = user.LastName;
            cmd.Parameters.Add("v_phone_number", OracleDbType.Varchar2).Value = user.PhoneNumber;
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
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }

        public void AddAccesRight(AccessRight accessRight)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_acces_right",
                DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("v_value", OracleDbType.Int32).Value = accessRight.Priority;
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

        public void AddUserToRight(int user_id, int rigth_id)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_user_to_right",
                DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("v_user_id_user", OracleDbType.Int32).Value = user_id;
            cmd.Parameters.Add("v_acces_right_id_acces_right", OracleDbType.Int32).Value = rigth_id;
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

        public void AddComment(Comment comment)
        {
            OracleCommand cmd = new OracleCommand("insert_procedure.insert_comment", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_content", OracleDbType.Varchar2).Value = comment.CommentContent;
            cmd.Parameters.Add("v_user_id", OracleDbType.Int32).Value = comment.User.Id;
            cmd.Parameters.Add("v_attraction_id", OracleDbType.Int32).Value = comment.Attraction.Id;

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

        public void UpdateUserInformation(User user, string currentEmail)
        {
            OracleCommand cmd = new OracleCommand("user_methods.update_user_info", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_old_email", OracleDbType.Varchar2).Value = currentEmail;
            cmd.Parameters.Add("v_new_phone_number", OracleDbType.Varchar2).Value = user.PhoneNumber;
            cmd.Parameters.Add("v_new_email", OracleDbType.Varchar2).Value = user.Email;
            cmd.Parameters.Add("v_new_password", OracleDbType.Varchar2).Value = user.Password;

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

        public IList<AttractionType> GetAttractionTypes()
        {
            OracleCommand cmd = new OracleCommand("get_function.get_attractiontype", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new OracleParameter("l_rc", OracleDbType.RefCursor, ParameterDirection.Output));
            cmd.Parameters["l_rc"].Direction = ParameterDirection.ReturnValue;

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            try
            {
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
                        Id = rdr.GetInt32(0),
                        Title = rdr.GetString(1),
                        Description = rdr.GetString(2),
                        ImagePath = rdr.GetString(3)
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }

        public IList<Attraction> GetAttractions()
        {
            OracleCommand cmd = new OracleCommand("get_function.get_attraction", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new OracleParameter("l_rc", OracleDbType.RefCursor, ParameterDirection.Output));
            cmd.Parameters["l_rc"].Direction = ParameterDirection.ReturnValue;

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();

                OracleRefCursor t = (OracleRefCursor)cmd.Parameters[0].Value;

                OracleDataReader rdr = t.GetDataReader();
                var dataTable = rdr.GetSchemaTable();
                var list = new List<Attraction>();
                while (rdr.Read())
                {
                    // System.Diagnostics.Debug.WriteLine(rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(3));
                    list.Add(new Attraction()
                    {
                        Id = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Description = rdr.GetString(2),
                        OpenTime = rdr.GetDateTime(3).TimeOfDay,
                        CloseTime = rdr.GetDateTime(4).TimeOfDay,
                        CreateAtractionTime = rdr.GetDateTime(5),
                        Rating = rdr.GetInt32(10),
                        PhoneNumber = rdr.GetString(11),
                        ImagePath = rdr.GetString(6),
                        Location = new Location() { Id = rdr.GetInt32(7), Address = rdr.GetString(15), PostalCode = uint.Parse(rdr.GetString(16)) },
                        AttractionType = new AttractionType() { Id = rdr.GetInt32(8), Title = rdr.GetString(12) },
                        User = new User() { Id = rdr.GetInt32(9), FirstName = rdr.GetString(13), LastName = rdr.GetString(14) }

                    });
                }
                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }

        public IList<Attraction> GetAttractionsByType(string attractionTitle)
        {
            OracleCommand cmd = new OracleCommand("get_function.get_attraction_by_attraction_type", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new OracleParameter("l_rc", OracleDbType.RefCursor, ParameterDirection.Output));
            cmd.Parameters["l_rc"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_title", OracleDbType.Varchar2, ParameterDirection.Input).Value = attractionTitle;

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();

                OracleRefCursor t = (OracleRefCursor)cmd.Parameters[0].Value;

                OracleDataReader rdr = t.GetDataReader();
                var list = new List<Attraction>();
                while (rdr.Read())
                {
                    // System.Diagnostics.Debug.WriteLine(rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(3));
                    /*{< ID_ATTRACTION = 10,NAME = ceva,DESCRIPTION = o descriere,OPEN_TIME = 05 - NOV - 19,
                     * CLOSE_TIME = 05 - NOV - 19,CREATE_ATTRACTION_TIME = 05 - NOV - 19,
                     * IMAGE_PATH =/ img / ceva,LOCATION_ID_LOCATION = 26,ATT_TYPE_ID_ATTRACTION_TYPE = 2,
                     * USER_ID_USER = 2,
                     * RATING = 1,PHONE_NUMBER = 3123123,
                     * TITLE = string,FIRST_NAME = dudu,
                     * LAST_NAME = marin,
                     * ADDRESS = undeva frumos,POSTAL_CODE = 1020312 >,}
                    */list.Add(new Attraction()
                    {
                        Id = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Description = rdr.GetString(2),
                        OpenTime = rdr.GetDateTime(3).TimeOfDay,
                        CloseTime = rdr.GetDateTime(4).TimeOfDay,
                        CreateAtractionTime = rdr.GetDateTime(5),
                        Rating=rdr.GetInt32(10),
                        PhoneNumber=rdr.GetString(11),
                        ImagePath = rdr.GetString(6),
                        Location = new Location() { Id = rdr.GetInt32(7),Address= rdr.GetString(15),PostalCode= uint.Parse(rdr.GetString(16)) },
                        AttractionType = new AttractionType() { Id = rdr.GetInt32(8),Title=rdr.GetString(12)},
                        User = new User() { Id = rdr.GetInt32(9) ,FirstName= rdr.GetString(13),LastName= rdr.GetString(14) }

                    });
                }
                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }

        public bool CheckUserPriority(User user, uint priority)
        {
            OracleCommand cmd = new OracleCommand("user_methods.check_user_priority", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new OracleParameter("v_status", OracleDbType.Decimal));
            cmd.Parameters["v_status"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_email", OracleDbType.Varchar2).Value = user.Email;
            cmd.Parameters.Add("v_priority", OracleDbType.Int32).Value = priority;

            try
            {
                cmd.ExecuteNonQuery();
                var result = int.Parse(cmd.Parameters["v_status"].Value.ToString());

                return result == 1;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
            return true;
        }

        public void UpdateCommentById(int id, bool status)
        {
            OracleCommand cmd = new OracleCommand("update_comment_rating", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_comment_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("v_increase", OracleDbType.Int32).Value = status;
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

        public void UpdateRatingAttractionById(int id, bool status)
        {
            OracleCommand cmd = new OracleCommand("update_attraction_rating", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("v_attraction_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("v_increase", OracleDbType.Int32).Value = status;
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

        public AttractionType GetAttractionTypeByTitle(string title)
        {
            OracleCommand cmd = new OracleCommand("get_function.get_attractiontypedata", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            OracleParameter v_attraction_type = new OracleParameter("v_attraction_type",
                OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            cmd.Parameters.Add(v_attraction_type);

            cmd.Parameters.Add("v_title", OracleDbType.Varchar2, ParameterDirection.Input).Value = title;

            try
            {
                cmd.ExecuteNonQuery();
                OracleRefCursor t = (OracleRefCursor)cmd.Parameters["v_attraction_type"].Value;
                OracleDataReader rd = t.GetDataReader();
                if (rd.Read())
                {
                    AttractionType attraction = new AttractionType()
                    {
                        Id = rd.GetInt32(0),
                        Title = rd.GetString(1),
                        Description = rd.GetString(2),
                        ImagePath = rd.GetString(3)
                    };
                    return attraction;
                }
                return null;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }

            return null;
        }

        public bool FindAttractionTypeByTitle(string title)
        {
            return GetAttractionTypeByTitle(title) != null;
        }

        public User GetUserByEmail(string email)
        {

            OracleCommand cmd = new OracleCommand("user_methods.get_user_by_email", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            OracleParameter v_attraction_type = new OracleParameter("v_user",
                OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            cmd.Parameters.Add(v_attraction_type);

            cmd.Parameters.Add("v_email", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;

            try
            {
                cmd.ExecuteNonQuery();
                OracleRefCursor t = (OracleRefCursor)cmd.Parameters["v_user"].Value;
                OracleDataReader rd = t.GetDataReader();
                if (rd.Read())
                {
                    User     user    = new User()
                    {
                        Id = rd.GetInt32(0),
                        FirstName = rd.GetString(1),
                        LastName = rd.GetString(2),
                        Email = rd.GetString(3),
                        PhoneNumber=rd.GetString(5)
                    };
                    return user;
                }
                return null;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }

            return null;
        }

        public bool FindUserByEmail(string email)
        {
            return GetUserByEmail(email) != null;
        }

        public IList<Comment> GetCommentsByAttraction(Attraction attraction)
        {
            OracleCommand cmd = new OracleCommand("get_function.get_comments_by_attraction_id", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new OracleParameter("v_comments", OracleDbType.RefCursor, ParameterDirection.Output));
            cmd.Parameters["v_comments"].Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add("v_attraction_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = attraction.Id;

            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();

                OracleRefCursor t = (OracleRefCursor)cmd.Parameters["v_comments"].Value;

                OracleDataReader rdr = t.GetDataReader();
                var list = new List<Comment>();
                while (rdr.Read())
                {
                    // System.Diagnostics.Debug.WriteLine(rdr.GetInt32(0) + rdr.GetString(1) + rdr.GetString(2) + rdr.GetString(3));
                    //{< ID_COMMENT = 1,COMMENT_CONTENT = ce frumos,
                    //POSTING_DATE = 02 - NOV - 19,USER_ID_USER = 2
                    //ATTRACTION_ID_ATTRACTION = 1,
                    //RATING = 4,FIRST_NAME = dudu,LAST_NAME = marin >,}
                    list.Add(new Comment()
                    {
                        Id = rdr.GetInt32(0),
                        CommentContent = rdr.GetString(1),
                        PostingDate = rdr.GetDateTime(2),
                        User = new User() { Id = rdr.GetInt32(3),
                            FirstName = rdr.GetString(6),
                            LastName = rdr.GetString(7) },
                        Attraction = new Attraction() { Id = rdr.GetInt32(4) },
                        Rating=rdr.GetInt32(5)
                        
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }
        }

        public IList<Comment> GetCommentsByAttractionId(int attractionId)
        {
            return GetCommentsByAttraction(new Attraction() { Id = attractionId });
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            OracleCommand cmd = new OracleCommand("user_methods.user_login", DataBaseConnection.getDbInstance().GetDBConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            OracleParameter v_attraction_type = new OracleParameter("v_user",
                OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            cmd.Parameters.Add(v_attraction_type);
            cmd.Parameters.Add("v_email", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;
            cmd.Parameters.Add("v_password", OracleDbType.Varchar2, ParameterDirection.Input).Value = password;

            try
            {
                cmd.ExecuteNonQuery();
                OracleRefCursor t = (OracleRefCursor)cmd.Parameters["v_user"].Value;
                OracleDataReader rd = t.GetDataReader();
                if (rd.Read())
                {
                    User user = new User()
                    {
                        Id = rd.GetInt32(0),
                        FirstName = rd.GetString(1),
                        LastName = rd.GetString(2),
                        Email = rd.GetString(3),
                        PhoneNumber = rd.GetString(5)
                    };
                    return user;
                }
                return null;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            finally
            {
                DataBaseConnection.getDbInstance().closeDBConnection();
            }

            return null;
        }



        public bool Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
        
        public TEntity GetEntityById<TEntity>(int id) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
