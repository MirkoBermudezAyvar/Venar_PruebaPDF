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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba_pdf.Formularios
{
    public partial class Form_Mantenimiento_Plan : Form
    {
        private static readonly string connectionString = "Data Source=DESKTOP-UFQBKNN\\MIRKO;TrustServerCertificate=True;Initial Catalog=BD_ARCHIVOS_VENAR;User Id=sa;Password=piloto;";
        public Form_Mantenimiento_Plan()
        {
            InitializeComponent();
            LlenarCombo();
            LlenarActualizarDGVPlantillas();
        }

        private void LlenarCombo()
        {


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
            // Agregar un elemento adicional al ComboBox en el índice 0 con el texto deseado
            if (dt.Rows.Count > 0)
            {
                // Establecer el índice seleccionado en 0
                comboBox1.SelectedIndex = 0;
            }


        }



        private void LLenardgtxCombo(string codcombo)
        {

            int numero;
            double numeroDecimal;


            if (int.TryParse(codcombo, out numero))
            {
                // Consulta para obtener los datos de la tabla
                string query = "SELECT p.planv_des as Planilla,planidet_anio as Año  FROM PlantillaPDFDetalle pd inner join PlantillaPDF p " +
                    " on pd.plani_id=p.plani_id where p.plani_id=" + codcombo;

                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear un comando para ejecutar la consulta
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Crear un DataAdapter para obtener los datos de la tabla
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Crear un DataTable para almacenar los datos de la tabla
                            DataTable dataTable = new DataTable();

                            // Llenar el DataTable con los datos de la tabla
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dgtablaplantillas.DataSource = dataTable;
                        }
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedIndex != -1)
                {
                    string filtro = comboBox1.SelectedValue.ToString();
                    LLenardgtxCombo(filtro);
                }
            }
            catch (Exception)
            {


            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores a insertar desde los controles del formulario
            string nomplantilla = txtnomplantilla.Text;
            // query de insercción 
            string sql = "INSERT INTO PlantillaPDF (planv_des) VALUES (@nomplantilla)";
            // Crear la conexión y el comando de inserción
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Agregar los parámetros de consulta
                command.Parameters.AddWithValue("@nomplantilla", nomplantilla);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }

            // Actualizar la vista del DataGridView
            LlenarActualizarDGVPlantillas();

        }

        private void LlenarActualizarDGVPlantillas()
        {
            // Consulta para obtener los datos de la tabla
            string query = "SELECT planv_des as Plantillas from PlantillaPDF";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();

                    // Crear un DataAdapter para obtener los datos de la tabla
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Crear un DataTable para almacenar los datos de la tabla
                        DataTable dataTable = new DataTable();

                        // Llenar el DataTable con los datos de la tabla
                        adapter.Fill(dataTable);

                        // Asignar el DataTable al DataGridView
                        dgvListaPlantillas.DataSource = dataTable;
                    }
                }
            }
            dgvListaPlantillas.Refresh();
            txtnomplantilla.Text = string.Empty;

        }
    }


}


