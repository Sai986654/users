using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace users
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMovies();
            }
        }

        protected void BindMovies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movies", con);
                con.Open();
                gvMovieDetails.DataSource = cmd.ExecuteReader();
                gvMovieDetails.DataBind();
            }
        }
        protected void ClearInputs()
        {
            txtMovieName.Text = "";
            txtId.Text = "";
            txtDirector.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Movies (ID,Name, Director) VALUES (@ID,@Name, @Director);SELECT SCOPE_IDENTITY()", con);
                cmd.Parameters.AddWithValue("@ID", txtId.Text);
                cmd.Parameters.AddWithValue("@Name", txtMovieName.Text);
                cmd.Parameters.AddWithValue("@Director", txtDirector.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Movie added");
                    ClearInputs();
                    BindMovies();
                }
                else
                {
                    Response.Write("Error occured while adding movie");
                }
            }
        }
    }
}