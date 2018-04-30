using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
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
            string url = Request.QueryString["id"];
            DataTable dt = this.GetData(url);
            foreach (DataRow row in dt.Rows)
            {
                
                //  foreach (DataColumn column in dt.Columns)
                //  {
                string title = row.Field<string>("Title");
                string image = row.Field<string>("Image");
                string content = row.Field<string>("Content");
                username.user = row.Field<string>("user");
                Title.Text = title;
                Image.Text = image;
                ContentID.InnerText = content;
            }
            if(!Session["user"].Equals(username.user))
            {
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
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM  posts where Id = " + id + ""))
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


    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string url = Request.QueryString["id"];
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Update posts set Title=@title,Image=@image,Content=@content where Id ="+url+"", conn);
            cmd.Parameters.AddWithValue("@title", Title.Text);
            cmd.Parameters.AddWithValue("@image", Image.Text);
            cmd.Parameters.AddWithValue("@content", ContentID.InnerText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Registered successfully......!");
            Response.Redirect("View.aspx?id="+url+"");
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
    void ShowMessage(string msg)
    {
        var message = new JavaScriptSerializer().Serialize(msg.ToString());//if the message contains some escape characters like ' or " this will definitely break your javascript:
        var script = string.Format("alert({0});", message);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", script, true);
    }
}