using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using users.Models;

namespace users
{
    public partial class EditMovie : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Movie movie = GetMovieById(id);

                if (movie != null)
                {
                    lblId.Text = movie.Id.ToString();
                    txtMovieName.Text = movie.Name;
                    txtDirector.Text = movie.Director;
                }
            }
        }

        protected void BindMovies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movies", con);
                con.Open();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            string name = txtMovieName.Text;
            string director = txtDirector.Text;

            if (UpdateMovie(id, name, director))
            {
                Response.Redirect("Movies.aspx");
            }
            else
            {
                // Show error message
            }
        }

        private Movie GetMovieById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Movies WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Movie movie = null;

            if (reader.Read())
            {
                movie = new Movie();
                movie.Id = Convert.ToInt32(reader["Id"]);
                movie.Name = reader["Name"].ToString();
                movie.Director = reader["Director"].ToString();
            }

            reader.Close();
            conn.Close();

            return movie;
        }

        protected bool UpdateMovie(int id, string name, string director)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Movies SET Name = @Name, Director = @Director WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Director", director);
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        Response.Write("Movie details updated successfully.");
                        BindMovies();
                        return true;
                    }
                    else
                    {
                        Response.Write("Failed to update movie details.");
                        return false;
                    }
                }
            }
        }
    }
}


