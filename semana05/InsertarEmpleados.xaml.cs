using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace semana05
{
    public partial class InsertarEmpleados : Window
    {
        string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=NeptunoDB; ";

        public InsertarEmpleados()
        {
            InitializeComponent();
        }

        private void InsertarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    connection.Open();

                    
                    using (SqlCommand command = new SqlCommand("USP_GetEmpleados", connection))
                    {
                        
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                        command.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                        command.Parameters.AddWithValue("@FechaNacimiento", txtTratamiento.Text);
                        command.Parameters.AddWithValue("@FechaContratacion", txtTratamiento.Text);
                        command.Parameters.AddWithValue("@Ciudad", txtTratamiento.Text);
                        command.Parameters.AddWithValue("@region", txtTratamiento.Text);







                        command.ExecuteNonQuery();

                        
                        MessageBox.Show("Empleado insertado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message);
            }
        }
    }
}
