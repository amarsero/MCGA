//====================================================================================================
// Base code generated with LeatherGoods - ASF.Data
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientDac : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Create(Client client)
        {
            const string sqlStatement = "INSERT INTO dbo.Client ([AspNetUsers], [City], [CountryId], [Email], [FirstName], " +
                "[LastName], [OrderCount], [SignupDate], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@AspNetUsers, @City, @CountryId, @Email, @FirstName, @LastName, @OrderCount, @SignupDate, " +
                "@CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@OrderCount", DbType.Int32, client.OrderCount);
                db.AddInParameter(cmd, "@SignupDate", DbType.DateTime, client.SignupDate);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, client.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, client.ChangedBy);
                // Obtener el valor de la primary key.
                client.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public void UpdateById(Client client)
        {
            const string sqlStatement = "UPDATE dbo.Client " +
                "SET [AspNetUsers]=@AspNetUsers, " +
                    "[City]=@City, " +
                    "[CountryId]=@CountryId, " +
                    "[Email]=@Email, " +
                    "[FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[OrderCount]=@OrderCount, " +
                    "[SignupDate]=@SignupDate, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@OrderCount", DbType.Int32, client.OrderCount);
                db.AddInParameter(cmd, "@SignupDate", DbType.DateTime, client.SignupDate);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, client.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, client.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, client.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, client.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, client.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Client WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client SelectById(int id)
        {
            const string sqlStatement = "SELECT [AspNetUsers], [City], [CountryId], [Email], [FirstName], " +
                "[LastName], [OrderCount], [SignupDate], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.Client WHERE [Id]=@Id ";

            Client client = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) client = LoadClient(dr);
                }
            }

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Client> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [AspNetUsers], [City], [CountryId], [Email], [FirstName], " +
                "[LastName], [OrderCount], [SignupDate], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client ";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var client = LoadClient(dr); // Mapper
                        result.Add(client);
                    }
                }
            }

            return result;
        }
        
        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                AspNetUsers = GetDataValue<string>(dr, "AspNetUsers"),
                City = GetDataValue<string>(dr, "City"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                Email = GetDataValue<string>(dr, "Email"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                OrderCount = GetDataValue<Int32>(dr, "OrderCount"),
                SignupDate = GetDataValue<DateTime>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return client;
        }
    }
}
