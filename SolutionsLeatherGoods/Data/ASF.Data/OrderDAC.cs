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
    public class OrderDac : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order Create(Order order)
        {
            const string sqlStatement = @"INSERT INTO [dbo].[Order]
           ([ClientId]
           ,[OrderDate]
           ,[TotalPrice]
           ,[State]
           ,[OrderNumber]
           ,[ItemCount]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ChangedOn]
           ,[ChangedBy])
     VALUES
           (@ClientId
           ,@OrderDate
           ,@TotalPrice
           ,@State
           ,@OrderNumber
           ,@ItemCount
           ,@CreatedOn
           ,@CreatedBy
           ,@ChangedOn
           ,@ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, order.ClientId);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, order.ItemCount);
                db.AddInParameter(cmd, "@OrderDate", DbType.DateTime, order.OrderDate);
                db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, order.OrderNumber);
                db.AddInParameter(cmd, "@State", DbType.Int32, order.State);
                db.AddInParameter(cmd, "@TotalPrice", DbType.Decimal, order.TotalPrice);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, order.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, order.ChangedBy);
                // Obtener el valor de la primary key.
                order.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public void UpdateById(Order order)
        {
            const string sqlStatement = "UPDATE [dbo].[Order] " +
                "SET [OrderDate]=@OrderDate, " +
                    "[ClientId]=@ClientId, " +
                    "[ItemCount]=@ItemCount, " +
                    "[OrderNumber]=@OrderNumber, " +
                    "[State]=@State, " +
                    "[TotalPrice]=@TotalPrice, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, order.ClientId);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, order.ItemCount);
                db.AddInParameter(cmd, "@OrderDate", DbType.DateTime, order.OrderDate);
                db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, order.OrderNumber);
                db.AddInParameter(cmd, "@State", DbType.Int32, order.State);
                db.AddInParameter(cmd, "@TotalPrice", DbType.Decimal, order.TotalPrice);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, order.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, order.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, order.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, order.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, order.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Order WHERE [Id]=@Id ";
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
        public Order SelectById(int id)
        {
            const string sqlStatement = @"SELECT [Id]
      ,[ClientId]
      ,[OrderDate]
      ,[TotalPrice]
      ,[State]
      ,[OrderNumber]
      ,[ItemCount]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ChangedOn]
      ,[ChangedBy]
  FROM[dbo].[Order]";

            Order order = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) order = LoadOrder(dr);
                }
            }

            return order;
        }

        public List<Order> SelectByClientId(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ItemCount], [OrderDate], [OrderNumber], [State], [TotalPrice],  [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM [dbo].[Order] WHERE [ClientId]=@Id";


            var result = new List<Order>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var order = LoadOrder(dr); // Mapper
                        result.Add(order);
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Order> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [ItemCount], [OrderDate], [OrderNumber], [State], [TotalPrice], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM [dbo].[Order] ";

            var result = new List<Order>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var order = LoadOrder(dr); // Mapper
                        result.Add(order);
                    }
                }
            }

            return result;
        }
        
        private static Order LoadOrder(IDataReader dr)
        {
            var order = new Order
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                OrderDate = GetDataValue<DateTime>(dr, "OrderDate"),
                OrderNumber = GetDataValue<int>(dr, "OrderNumber"),
                State = GetDataValue<int?>(dr, "State"),
                TotalPrice = GetDataValue<double>(dr, "TotalPrice"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return order;
        }
    }
}

