using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace CRUD.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOP = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOP = Request.QueryString["op"].ToString();
                    switch (sOP)
                    {
                        case "C":
                            this.lblTitulo.Text = "Crear Usuario";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consultar Usuario";
                            // Bloqueamos los campos en modo solo lectura
                            txtNombre.Enabled = false;
                            txtEdad.Enabled = false;
                            txtCorreo.Enabled = false;
                            txtFechaNacimiento.Enabled = false;
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Usuario";
                            this.btnUpdate.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            using (MySqlDataAdapter da = new MySqlDataAdapter("sp_read", con))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(sID);

                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtNombre.Text = row["Nombre"].ToString();
                    txtCorreo.Text = row["Correo"].ToString();
                    txtEdad.Text = row["Edad"].ToString();

                    DateTime d = Convert.ToDateTime(row["FechaNacimiento"]);
                    txtFechaNacimiento.Text = d.ToString("yyyy-MM-dd");
                }
            }
            con.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert_user", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("_nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                cmd.Parameters.Add("_edad", MySqlDbType.Int32).Value = Convert.ToInt32(txtEdad.Text);
                cmd.Parameters.Add("_correo", MySqlDbType.VarChar).Value = txtCorreo.Text;
                cmd.Parameters.Add("_fechanacimiento", MySqlDbType.Date).Value = DateTime.Parse(txtFechaNacimiento.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_update", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(sID);
                cmd.Parameters.Add("_nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                cmd.Parameters.Add("_edad", MySqlDbType.Int32).Value = Convert.ToInt32(txtEdad.Text);
                cmd.Parameters.Add("_correo", MySqlDbType.VarChar).Value = txtCorreo.Text;
                cmd.Parameters.Add("_fechanacimiento", MySqlDbType.Date).Value = DateTime.Parse(txtFechaNacimiento.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
