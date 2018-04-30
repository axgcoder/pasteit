using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    static class username
    {
        public static string user;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (!this.IsPostBack)
        {
            delete.Visible = false;//hide delete button
            BuildButton.Visible = false;

            string url = Request.QueryString["id"];
            DataTable dt = this.GetData(url);
            int id;
            StringBuilder html = new StringBuilder();
            StringBuilder Build = new StringBuilder();
            

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<div class = item>");
                //  foreach (DataColumn column in dt.Columns)
                //  {
                string title = row.Field<string>("Title");
                string image = row.Field<string>("Image");
                string content = row.Field<string>("Content");
                username.user = row.Field<string>("user");
                id = row.Field<int>("Id");
                html.Append("<div class = 'ui huge header'>"+title+ "</div><div class = 'ui top attached' runat='server'><div class = item><img class = 'ui centered rounded image' src = " + image+ "></div>" +
                    "<div class = description><p>"+content+ "</p></div>");
                //  }

                Build.Append("<div><a class = 'ui blue basic button' href = Edit.aspx?id=" + id + ">Edit Post</a></div>");
                // html.Append("<div class = item><div class =image><img src ='"+ row[column.ColumnName] + "' >");
            }
            
            dynamic.Controls.Add(new Literal { Text = html.ToString() });
            BuildButton.Controls.Add(new Literal { Text = Build.ToString() });
            if (Session["role"].Equals("admin")|| Session["user"].Equals(username.user))
            {
                delete.Visible = true;
                BuildButton.Visible = true;
            }

            if (Session["user"] == null)
            {
                btnLogout.Visible = false;
                Response.Redirect("login.aspx");
            }
           
           
        }

       

     
    }

    private DataTable GetData(string id)
    {

        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM  posts where Id = "+id+""))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;

                    }
                }
            }
        }
    }
 

    private void ShowMessage(string msg)
    {
        var message = new JavaScriptSerializer().Serialize(msg.ToString());//if the message contains some escape characters like ' or " this will definitely break your javascript:
        var script = string.Format("alert({0});", message);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", script, true);
    }

    protected void Delete(object sender, EventArgs e)
    {
        try
        {
            string url = Request.QueryString["id"];
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Delete from posts where Id =" + url + "", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Deleted successfully......!");
            Response.Redirect("Default.aspx");
        }
        catch (MySqlException ex)
        {
            ShowMessage(ex.Message);
            // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", "alert('" + ex.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Logout(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}