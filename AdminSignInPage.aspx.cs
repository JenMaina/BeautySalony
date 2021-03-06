﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace BeautySalony
{
    public partial class AdminSignInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");

        }
        protected void linkAboutUsPage_Click(object sender, EventArgs e)
        {
             Response.Redirect("AboutUsPage.aspx");

        }
        protected void linkPricesPage_Click(object sender, EventArgs e)
        {
             Response.Redirect("PricesPage.aspx");

        }
        protected void linkServicesPage_Click(object sender, EventArgs e)
        {
             Response.Redirect("ServicesPage.aspx");

        }
        protected void linkSignUpPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");

        }
        protected void linkSignInPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignInPage.aspx");

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            try
            {
                string myDatabase = "datasource=localhost;port=3306;username=root;password=root";
                MySqlConnection Mycon = new MySqlConnection(myDatabase);
                MySqlCommand selectCommand = new MySqlCommand("select * from EntrepreneurialTechnology.AdminTable where username='" + this.txtUsernameAdmin.Text + "'and Password=aes_encrypt('" + this.txtPasswordAdmin.Text + "','secret1');", Mycon);

                MySqlDataReader myReader;
                Mycon.Open();
                myReader = selectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    Session["UsernameAdmin"] = txtUsernameAdmin.Text;
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>$(document).ready(function(){ $('.alert-danger').show(); $('.alert-danger').html('username or password is incorrect'); })</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }


    }
}