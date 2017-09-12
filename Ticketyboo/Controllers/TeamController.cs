using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Compilation;
using System.Web.ModelBinding;
using System.Web.Services.Protocols;
using OCP.Components;
using OCP.Models;
using OCP.Views.Admin;

namespace OCP.Controllers
{
    public class TeamController : TeamAdmin
    {
        protected System.Web.UI.StateBag Viewstate;
        #region GetTeams Method

        /// <summary>
        /// Get all Teams from Team table
        /// </summary>
        /// <returns>A List of Team objects</returns>

        public List<TeamModel> GetTeams(string sortExpression)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            sortExpression = string.Empty;
            string sortDirection = string.Empty;

            if (Session["SortExpression"] != null)
            {
                sortExpression = Session["SortExpression"].ToString();
            }

            if (Session["SortDirection"] != null)
            {
                switch (Session["SortDirection"].ToString())
                {
                    case "Ascending":
                        sortDirection = "ASC";
                        break;
                    case "Descending":
                        sortDirection = "DESC";
                        break;
                }

            }




            string sqlCommand = string.Empty;

            if (sortExpression == string.Empty)
            {
                
                sqlCommand = "SELECT * FROM SystemConfiguration.Team ORDER BY Id ASC";
            }

            if (sortExpression != string.Empty)
            {
                if (sortExpression.Trim() == "")
                    sqlCommand = "SELECT * FROM SystemConfiguration.Team ORDER BY Id ASC";
                else
                    sqlCommand += "SELECT * FROM SystemConfiguration.Team ORDER BY " + sortExpression + " " + sortDirection;
            }



            da = new SqlDataAdapter(sqlCommand, AppSettings.Instance.ConnectString);

            da.Fill(dt);

            var query =
                (from dr in dt.AsEnumerable()
                 select new TeamModel()
                 {
                     Id = Convert.ToInt32(dr["Id"]),
                     Name = dr["Name"].ToString(),
                     IsActive = DataConvert.ConvertTo<bool>(
                         dr["IsActive"], default(bool)),
                     UpdatedBy = dr["UpdatedBy"].ToString(),
                     UpdatedDate = DataConvert.ConvertTo<DateTime>(dr["UpdatedDate"],
                         default(DateTime))
                 });


            return query.ToList();
        }
        #endregion

        #region GetTeam Method

        /// <summary>
        /// Get a single Product from the Product table
        /// </summary>
        /// <param name="productId">A Product ID to find</param>
        /// <returns>A Product object</returns>

        public TeamModel GetTeam(int TeamId, string sortExpression)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;
            SqlCommand cmd = null;

            string sqlCommand = "SELECT * FROM SystemConfiguration.Team WHERE Id = " + TeamId;

            //if (sortExpression.Trim() == "")
            //    sqlCommand += " ORDER BY Id";
            //else
            //    sqlCommand += " ORDER BY " + sortExpression;
            da = new SqlDataAdapter(sqlCommand, AppSettings.Instance.ConnectString);
            da.Fill(dt);

            var entity =
                (from dr in dt.AsEnumerable()
                 select new TeamModel()
                 {
                     Id = Convert.ToInt32(dr["Id"]),
                     Name = dr["Name"].ToString(),
                     IsActive = DataConvert.ConvertTo<bool>(
                         dr["IsActive"], default(bool)),
                     UpdatedBy = dr["UpdatedBy"].ToString(),
                     UpdatedDate = DataConvert.ConvertTo<DateTime>(dr["UpdatedDate"],
                         default(DateTime))
                 }).FirstOrDefault();

            return entity;
        }
        #endregion

        #region Insert Method

        /// <summary>
        /// Inserts a new Team into the Team table
        /// </summary>
        public bool Insert(TeamModel entity)
        {
            return true;
        }
        #endregion

        #region Update Method

        /// <summary>
        /// Updates a Team in the Team table
        /// </summary>
        public bool Update(TeamModel entity)
        {
            return true;
        }
        #endregion

        #region Delete Method

        /// <summary>
        /// Deletes a Team from the Team table
        /// </summary>
        public bool Delete(int TeamId)
        {
            return true;
        }
        #endregion
    }
}