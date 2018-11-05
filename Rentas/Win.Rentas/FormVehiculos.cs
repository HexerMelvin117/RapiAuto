using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormVehiculos : Form
    {
        VehiculosBL _vehiculos;
        CategoriasBL _categorias;
        TiposBL _tipos;

        public FormVehiculos()
        {
            InitializeComponent();

            _vehiculos = new VehiculosBL();
            listaVehiculosBindingSource.DataSource = _vehiculos.ObtenerVehiculos();

            _categorias = new CategoriasBL();
            listaCategoriasBindingSource.DataSource = _categorias.ObtenerCategorias();

            _tipos = new TiposBL();
            listaTiposBindingSource.DataSource = _tipos.ObtenerTipos();
        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaVehiculosBindingSource.EndEdit();
            var vehiculo = (Vehiculo)listaVehiculosBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                vehiculo.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                vehiculo.Foto = null;
            }

            var resultado = _vehiculos.GuardarVehiculo(vehiculo);

            if (resultado.Exitoso == true)
            {
                listaVehiculosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Vehiculo guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _vehiculos.AgregarVehiculo();
            listaVehiculosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            //toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _vehiculos.EliminarVehiculo(id);

            if (resultado == true)
            {
                listaVehiculosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vehiculo = (Vehiculo)listaVehiculosBindingSource.Current;
            if (vehiculo != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show("Cree un vehiculo antes de asignarle una imagen");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
