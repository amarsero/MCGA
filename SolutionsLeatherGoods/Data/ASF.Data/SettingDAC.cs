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
    public class SettingDac : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public Setting Create(Setting setting)
        {
            const string sqlStatement = "INSERT INTO dbo.Setting ([AdminEmailAddress], [DefaultLanguageId], [Description], [LastChangeDate], [Name], [PageTitle], [SMTP], " +
                "[SMTPEnableSSL], [SMTPPassword], [SMTPPort], [SMTPUsername], [Theme], [Value], [WebSiteName], [WebSiteUrl], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@AdminEmailAddress, @DefaultLanguageId, @Description, @LastChangeDate, @Name, @PageTitle, @SMTP, @SMTPEnableSSL, @SMTPPassword, @SMTPPort, @SMTPUsername, " +
                "@Theme, @Value, @WebSiteName, @WebSiteUrl, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, setting.LastChangeDate);
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, setting.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, setting.ChangedBy);
                // Obtener el valor de la primary key.
                setting.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public void UpdateById(Setting setting)
        {
            const string sqlStatement = "UPDATE dbo.Setting " +
                "SET [AdminEmailAddress]=@AdminEmailAddress, " +
                    "[DefaultLanguageId]=@DefaultLanguageId, " +
                    "[Description]=@Description, " +
                    "[LastChangeDate]=@LastChangeDate, " +
                    "[Name]=@Name, " +
                    "[PageTitle]=@PageTitle, " +
                    "[SMTP]=@SMTP, " +
                    "[SMTPEnableSSL]=@SMTPEnableSSL, " +
                    "[SMTPPassword]=@SMTPPassword, " +
                    "[SMTPPort]=@SMTPPort, " +
                    "[SMTPUsername]=@SMTPUsername, " +
                    "[Theme]=@Theme, " +
                    "[Value]=@Value, " +
                    "[WebSiteName]=@WebSiteName, " +
                    "[WebSiteUrl]=@WebSiteUrl, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, setting.LastChangeDate);
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, setting.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, setting.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, setting.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, setting.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, setting.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Setting WHERE [Id]=@Id ";
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
        public Setting SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [AdminEmailAddress], [DefaultLanguageId], [Description], [LastChangeDate], [Name], [PageTitle], [SMTP], " +
                "[SMTPEnableSSL], [SMTPPassword], [SMTPPort], [SMTPUsername], [Theme], [Value], [WebSiteName], [WebSiteUrl], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Setting WHERE [Id]=@Id ";

            Setting setting = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) setting = LoadSetting(dr);
                }
            }

            return setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Setting> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [AdminEmailAddress], [DefaultLanguageId], [Description], [LastChangeDate], [Name], [PageTitle], [SMTP], " +
                "[SMTPEnableSSL], [SMTPPassword], [SMTPPort], [SMTPUsername], [Theme], [Value], [WebSiteName], [WebSiteUrl], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Setting ";

            var result = new List<Setting>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var setting = LoadSetting(dr); // Mapper
                        result.Add(setting);
                    }
                }
            }

            return result;
        }
        
        private static Setting LoadSetting(IDataReader dr)
        {
            var setting = new Setting
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                AdminEmailAddress = GetDataValue<string>(dr, "AdminEmailAddress"),
                DefaultLanguageId = GetDataValue<int>(dr, "DefaultLanguageId"),
                Description = GetDataValue<string>(dr, "Description"),
                LastChangeDate = GetDataValue<DateTime>(dr, "LastChangeDate"),
                PageTitle = GetDataValue<string>(dr, "PageTitle"),
                SMTP = GetDataValue<string>(dr, "SMTP"),
                SMTPEnableSSL = GetDataValue<bool?>(dr, "SMTPEnableSSL"),
                SMTPPassword = GetDataValue<string>(dr, "SMTPPassword"),
                SMTPPort = GetDataValue<string>(dr, "SMTPPort"),
                SMTPUsername = GetDataValue<string>(dr, "SMTPUsername"),
                Theme = GetDataValue<string>(dr, "Theme"),
                Value = GetDataValue<string>(dr, "Value"),
                WebSiteName = GetDataValue<string>(dr, "WebSiteName"),
                WebSiteUrl = GetDataValue<string>(dr, "WebSiteUrl"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return setting;
        }
    }
}
