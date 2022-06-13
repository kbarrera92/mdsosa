using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISPRO_TRANSPORTES
{
    public partial class frmPrincipal : Form
    {
        

        public frmPrincipal()
        {
            InitializeComponent();
        }

                
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

             

        private void camionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmCamiones camiones = new frmCamiones();
            camiones.MdiParent = this;
            camiones.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Logica.BL_Usuario.tipousuario == 1)
            {
                frmUsuarios usuarios = new frmUsuarios();
                usuarios.MdiParent = this;
                usuarios.Show();
            }
            else
            {
                MessageBox.Show("No tiene acceso a este módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pilotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmPilotos pilotos = new frmPilotos();
            pilotos.MdiParent = this;
            pilotos.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Logica.BL_Usuario.codusuarioActual = -1;
            Logica.BL_Usuario.nombreUsuarioActual = null;
            Logica.BL_Usuario.tipousuario = 0;
            toolStripLabel2.Text = ConfigurationManager.AppSettings["combustibleActual"] + " gl / 2000gl";
            toolStripProgressBar1.Value = int.Parse(ConfigurationManager.AppSettings["combustibleActual"]);
            timer1.Start();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmViaje viaje = new frmViaje();
            viaje.MdiParent = this;
            viaje.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente clientes = new frmCliente();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripButtonLogin.Text == "Login")
            {
                frmLogin login = new frmLogin();
                //AddOwnedForm(login);
                login.pasado += new frmLogin.pasar(ejecutar);
                login.MdiParent = this;
                login.Show();
            }
            else
            {
                toolStripButtonLogin.Text = "Login";
                toolStripLabelUsuario.Text = "usuario: ";
                Logica.BL_Usuario.tipousuario = 0;
                Logica.BL_Usuario.nombreUsuarioActual = null;
                Logica.BL_Usuario.codusuarioActual = -1;
            }
            
        }

        public void ejecutar(string dato)
        {
            this.toolStripLabelUsuario.Text += dato;
            this.toolStripButtonLogin.Text = "Cerrar sesión";
        }

        private void nuevoViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            toolStripButtonViaje.PerformClick();
        }

        private void historialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmVerViajes verviaje = new frmVerViajes();
            verviaje.MdiParent = this;
            verviaje.Show();
        }

        private void despachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValeCombustible vale = new frmValeCombustible();
            vale.MdiParent = this;
            vale.Show();
        }

        private void valesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmVerVales vervales = new frmVerVales();
            vervales.MdiParent = this;
            vervales.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
                frmCompras2 compra = new frmCompras2();
                compra.MdiParent = this;
                compra.Show();
            
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias cat = new frmCategorias();
            cat.MdiParent = this;
            cat.Show();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsumos insumo = new frmInsumos();
            insumo.MdiParent = this;
            insumo.Show();
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2.PerformClick();
        }

        private void pagarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmReporteViajes pagoviajes = new frmReporteViajes();
            pagoviajes.MdiParent = this;
            pagoviajes.Show();
        }

        private void verConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmConsumoDiesel consumo = new frmConsumoDiesel();
            consumo.MdiParent = this;
            consumo.Show();
        }

        private void reporteDeViajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmReporteViajes reporteviajes = new frmReporteViajes();
            reporteviajes.MdiParent = this;
            reporteviajes.Show();
        }

        private void reportesCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmConsumoDiesel consumodiesel = new frmConsumoDiesel();
            consumodiesel.MdiParent = this;
            consumodiesel.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox acercade = new AboutBox();
            acercade.MdiParent = this;
            acercade.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            historialToolStripMenuItem1.PerformClick();
        }

        private void preliquidacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            System.Diagnostics.Process.Start("explorer", @"Preliquidaciones");
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(decimal.ToInt32(Logica.BL_Insumos.getinsumo(100)).ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripLabel2.Text = Logica.BL_Insumos.getinsumo(100).ToString() + " gl / 1000gl";
            //toolStripProgressBar1.Value = int.Parse(decimal.ToInt32(Logica.BL_Insumos.getinsumo(100)).ToString());
        }

        private void pagoDeViajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmPagoAPilotos pago = new frmPagoAPilotos();
            pago.MdiParent = this;
            pago.Show();
        }

        private void asignarViajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAsignarPreliquidacion preliq = new frmAsignarPreliquidacion();
            preliq.MdiParent = this;
            preliq.Show();
        }

        private void preliquidacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmPreliquidaciones pre = new frmPreliquidaciones();
            pre.MdiParent = this;
            pre.Show();
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void ajustarTanqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Logica.BL_Usuario.tipousuario == 1)
            {
                frmAjustarTanque ajustartanque = new frmAjustarTanque();

                ajustartanque.txtcombustibleactual.Text = toolStripProgressBar1.Value.ToString();
                ajustartanque.ShowDialog();

                if (ajustartanque.DialogResult == DialogResult.OK)
                {
                    toolStripLabel2.Text = ConfigurationManager.AppSettings["combustibleActual"] + " gl / 1000gl";
                    toolStripProgressBar1.Value = int.Parse(ConfigurationManager.AppSettings["combustibleActual"]);
                }
            }
            else
            {
                MessageBox.Show("No tiene acceso a este módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
        }

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.toolStripLabel2.Text = ConfigurationManager.AppSettings["combustibleActual"] + " gl / 2000gl";
            this.toolStripProgressBar1.Value = int.Parse(ConfigurationManager.AppSettings["combustibleActual"]);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmVerCompras2 compras = new frmVerCompras2();
            compras.MdiParent = this;
            compras.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmCompra3 venta = new frmCompra3();
            venta.MdiParent = this;
            venta.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmVerVentas verventas = new frmVerVentas();
            verventas.MdiParent = this;
            verventas.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmVerViajesRegional verviaje = new frmVerViajesRegional();
            verviaje.MdiParent = this;
            verviaje.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.tipousuario == 0)
            {
                MessageBox.Show("Debe iniciar sesión", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmVerViajesWP verviaje = new frmVerViajesWP();
            verviaje.MdiParent = this;
            verviaje.Show();
        }

        private void verPagosAPilotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerPagos pagopilotos = new frmVerPagos();
            pagopilotos.MdiParent = this;
            pagopilotos.Show();
        }
    }
}
