using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        
            try
            {
                conn.Open();
                string query = "Select * from users where username ='" + username.Text + "' and password ='" + password.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                  MySqlDataReader rdr = cmd.ExecuteReader();

        
            //while (rdr.Read())
            //{
            //    results.Add(rdr.GetString(0));
            //}
            //var thearray = results.ToArray();
            
           if (rdr.Read())
            {
               Session["user"] = rdr[0];
               Session["role"] = rdr[2];
                Response.Redirect("Default.aspx");
            }
                   
              else
                {
                   Response.Write("Login Failed");
                }
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message);
                //ShowMessage(ex.Message);
                // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", "alert('" + ex.Message.Replace("'", "") + "');", true);
            }
            finally
            {
                conn.Close();
            }
        }
    
}