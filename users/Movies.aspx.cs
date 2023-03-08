using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace users
{
    //[Authorize(Roles = "Admin, Manager")]
    public partial class Movies : System.Web.UI.Page
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

        protected void gvMovieDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMovieDetails.Rows[index];
                int id = Convert.ToInt32(row.Cells[0].Text);
                string name = row.Cells[1].Text;
                string director = row.Cells[2].Text;
                // perform any additional logic or redirection as needed
                Response.Redirect("EditMovie.aspx?id=" + id);
            }
            else if (e.CommandName == "DeleteRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMovieDetails.Rows[index];
                int id = Convert.ToInt32(row.Cells[0].Text);
                DeleteMovieById(id);
                BindMovies();
            }
        }

        //protected void gvMovieDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ButtonField btnEdit = (ButtonField)e.Row.Cells[3].Controls[0];
        //        ButtonField btnDelete = (ButtonField)e.Row.Cells[4].Controls[0];
        //        if (!User.IsInRole("Admin") && !User.IsInRole("Manager"))
        //        {
        //            btnEdit.Enabled = false;
        //            btnDelete.Enabled = false;
        //        }
        //    }
        //}

        private void DeleteMovieById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            string query = "DELETE FROM Movies WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Response.Write("movie deleted successfully");
                    }
                    else
                    {
                        Response.Write("movie not found or multiple movies with same ID");
                    }
                }
            }
        }
    }
}