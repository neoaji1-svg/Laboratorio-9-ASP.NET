using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace CRUD.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarTabla();
            }
        }

        void CargarTabla()
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_load", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvusuarios.DataSource = dt;
                    gvusuarios.DataBind();
                }
                con.Close();
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            Button btnConsultar = (Button)sender;
            string id = btnConsultar.CommandArgument;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Button btnActualizar = (Button)sender;
            string id = btnActualizar.CommandArgument;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string id = btnEliminar.CommandArgument;

            if (!string.IsNullOrEmpty(id))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                CargarTabla();
            }
        }
    }
}
