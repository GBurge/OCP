using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using OCP.Controllers;
using OCP.Models;

namespace OCP.Views.Admin
{
    public partial class TeamAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["Id"] != null)
            {
                hdnPK.Value = Page.RouteData.Values["Id"].ToString();
            }
            //Session["pageIndex"] = grdAltTeams.PageIndex;

            if (Page.IsPostBack) return;

            // Check to see if this is a postback or was submitted via the <a href>
            if (Request.QueryString["id"] == null) return;
            var PK = Convert.ToString(Request.QueryString["id"]);

            //var sortExpression = grdAltTeams.SortExpression;

            lblTitle.InnerText = "Update Team";
            btnSave.Text = "Update Team";
            btnSave.ToolTip = "Update Team";
            hdnPK.Value = PK;
            hdnAddMode.Value = "false";

            LoadInfoForEdit(PK);
            LoadEditScript();
        }

        private void LoadInfoForEdit(string PK)
        {
            var ctrl = new TeamController();
            var entity = new TeamModel();
            entity = ctrl.GetTeam(Convert.ToInt32(PK), grdAltTeams.SortExpression);

            txtTeamName.Text = entity.Name;
            boolIsActive.Checked = entity.IsActive;
            //txtUpdatedBy.Text = 
            hdnPK.Value = entity.Id.ToString();
            hdnAddMode.Value = "false";

        }
        private void LoadEditScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("$(document).ready(function(){");
            sb.AppendLine("$('#teamDialog').modal();");
            sb.AppendLine("});");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "EditData", sb.ToString(), true);
        }

        protected void grdTeams_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ctrl = new TeamController();

            switch (e.CommandName.ToLower())
            {
                case "delete":
                    ctrl.Delete(Convert.ToInt32(e.CommandArgument));
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var ctrl = new TeamController();
            var entity = new TeamModel();

            entity.Id = Convert.ToInt32(hdnPK.Value);
            entity.Name = txtTeamName.Text;
            entity.IsActive = boolIsActive.Checked;

            if (Convert.ToBoolean(hdnAddMode.Value))
            {
                ctrl.Insert(entity);
            }
            else
            {
                ctrl.Update(entity);
            }
        }

        protected void btnResetSort_Click(object sender, EventArgs e)
        {
            Session.Remove("SortExpression");
            Session.Remove("SortDirection");
            var ctrl = new TeamController();
            ctrl.GetTeams(null);
        }
       
        protected void grdAltTeams_OnSorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression != string.Empty)
            {
                Session["SortExpression"] = e.SortExpression;
            }

            Session["SortDirection"] = e.SortDirection;

            


        }

        protected void grdAltTeams_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAltTeams.PageIndex = e.NewPageIndex;
            Session["PageIndex"] = grdAltTeams.PageIndex;
        }
    }
}