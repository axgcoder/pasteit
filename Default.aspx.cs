using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Populating a DataTable from database.

        if (!this.IsPostBack)
        {
            DataTable dt = this.GetPrivileges();
            //Building an HTML string.
            StringBuilder html = new StringBuilder();


            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<div class = item>");
              //  foreach (DataColumn column in dt.Columns)
              //  {
                    string title = row.Field<string>("Title");
                    string image = row.Field<string>("Image");
                string content = row.Field<string>("Content");
                     int id = row.Field<int>("Id");
                content = (content.Length > 100) ? content.Substring(0, 100) : content;
                html.Append("<div class = 'image'><img class = 'homeImg' src = " + image + "></div>" +
                        "<div class = content><a class = header>" + title + "</a>" +
                        "<div class = description><p>" + content + "...</p>"+
                        "<div class = extra>"+
                        "<a itemId='"+ id + "' class = 'ui floated basic purple button' href='View.aspx?id="+id+"'> Read More<i class = 'right chevron icon'></i></a>" +
                        "</div></div></div>");
              //  }
                html.Append("</div>");    

               // html.Append("<div class = item><div class =image><img src ='"+ row[column.ColumnName] + "' >");
            }

            dynamic.Controls.Add(new Literal { Text = html.ToString() });

            if (Session["user"] == null)
            {
                btnLogout.Visible = false;
                Response.Redirect("login.aspx");
            }
        }
    }

    private DataTable GetPrivileges()
    {

        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM  posts"))
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

    protected void Logout(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}