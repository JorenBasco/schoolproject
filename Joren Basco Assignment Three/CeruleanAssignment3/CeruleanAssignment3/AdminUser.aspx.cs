using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Data;

namespace CeruleanAssignment3
{
    public partial class AdminUser : System.Web.UI.Page
    {
        string conn = "Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["UserSecurity"] != "Admin")
                {
                    Response.Redirect("Index.aspx");
                }
                loadUsers();
            }
        }

        private void loadUsers()
        {
            DAL myDal = new DAL(conn);
            myDal.AddParam("action", "r");
            DataSet ds = myDal.ExecuteProcedure("spUser");
            gvUsers.DataSource = ds;
            gvUsers.DataBind();
        }


        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DAL myDal = new DAL(conn);
            int index = Convert.ToInt32(e.CommandArgument);
            gvUsers.SelectedIndex = index;
            
            if (e.CommandName == "del")
            {
                myDal.AddParam("action", "d");
                myDal.AddParam("userID", gvUsers.SelectedDataKey.Value.ToString());
                myDal.ExecuteProcedure("spUser");
                Response.AddHeader("REFRESH", ".1;AdminUser.aspx");
            }
            else if (e.CommandName == "upd")
            {
                myDal.AddParam("action", "r");
                myDal.AddParam("userID", gvUsers.SelectedDataKey.Value.ToString());
                DataSet ds = myDal.ExecuteProcedure("spUser");
                txtEmail.Text = ds.Tables[0].Rows[0]["userEmail"].ToString();
                txtPass.Text = ds.Tables[0].Rows[0]["userPass"].ToString();
                txtSecurity.Text = ds.Tables[0].Rows[0]["securityLevel"].ToString();
                lblUserID.Text = ds.Tables[0].Rows[0]["userID"].ToString();
                pnlUserInfo.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL myDal = new DAL(conn);
            myDal.AddParam("userEmail", txtEmail.Text);
            myDal.AddParam("userPass", txtPass.Text);
            myDal.AddParam("securityLevel", txtSecurity.Text);
            if(lblUserID.Text == "")
            {
                myDal.AddParam("action", "c");
            }
            else
            {
                myDal.AddParam("action", "u");
                myDal.AddParam("userID", lblUserID.Text);
            }
            myDal.ExecuteProcedure("spUser");
            Response.AddHeader("REFRESH", ".1;AdminUser.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPass.Text = "";
            txtSecurity.Text = "";
            pnlUserInfo.Visible = false;
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            pnlUserInfo.Visible = true;
            txtEmail.Text = "";
            txtPass.Text = "";
            txtSecurity.Text = "";
            lblUserID.Text = "";
        }
    }
}