using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prueba_pdf.Formularios
{
    public partial class Form_Mantenimiento_Plan : Form
    {
        private static readonly string connectionString = "Data Source=DESKTOP-UFQBKNN\\MIRKO;TrustServerCertificate=True;Initial Catalog=BD_ARCHIVOS_VENAR;User Id=sa;Password=piloto;";
        public Form_Mantenimiento_Plan()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void LlenarCombo() {


            string query = "SELECT * FROM PlantillaPDF";
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
                {
                    adapter.Fill(dt);
                }
            }

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "planv_des";
            comboBox1.ValueMember = "plani_id";

           
        }



    }


    }


