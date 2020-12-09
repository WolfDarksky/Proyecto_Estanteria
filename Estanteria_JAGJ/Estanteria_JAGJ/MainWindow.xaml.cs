using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Estanteria_JAGJ.DAL;

namespace Estanteria_JAGJ
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Conectarse();
        }

        #region Metodos
        public void Conectarse()
        {
            if (ConexionMySQL.ConectionMySQL())
                MessageBox.Show("Conectado a BD MySQL");
            else
            {
                MessageBox.Show("Error en conexion a BD MySQL");
                Close();
            }
        }
        #endregion

        private void btnNuevoEstante_Click(object sender, RoutedEventArgs e)
        {
            Views.NuevoEstanteView nuevoEst = new Views.NuevoEstanteView();
            nuevoEst.ShowDialog();
        }

        private void btnConsultarEstante_Click(object sender, RoutedEventArgs e)
        {
            Views.ConsultarEstantesView consultarEst = new Views.ConsultarEstantesView();
            consultarEst.ShowDialog();
        }
    }
}
