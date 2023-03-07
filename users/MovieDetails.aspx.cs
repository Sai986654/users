using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class MovieDetails : Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True");

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        BindGridView();
    //    }
    //}
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
            GridView1.DataBind();
        }
    }

    protected void ClearInputs()
    {
        txtMovieName.Text = "";
        txtStartDate.Text = "";
        txtDuration.Text = "";
        txtDescription.Text = "";
        txtAuthor.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Movies (Name, StartDate, Duration, Description, Author) VALUES (@Name, @StartDate, @Duration, @Description, @Author)", con);
            cmd.Parameters.AddWithValue("@Name", txtMovieName.Text);
            cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
            cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            ClearInputs();
            BindMovies();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Movies SET Name = @Name, StartDate = @StartDate, Duration = @Duration, Description = @Description, Author = @Author WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", GridView1.SelectedValue);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
            cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            ClearInputs();
            BindMovies();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MovieDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Movies SET Name = @Name, StartDate = @StartDate, Duration = @Duration, Description = @Description, Author = @Author WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", GridView1.SelectedValue);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
            cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            ClearInputs();
            BindMovies();

        }
    }
}