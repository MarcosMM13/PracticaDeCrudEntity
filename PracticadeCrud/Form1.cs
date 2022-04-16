using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticadeCrud.Modelo;

namespace PracticadeCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();

        }

        #region Help
        private void Refrescar()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var lst = from d in db.Empleadoes
                          select d;

                dgvListado.DataSource = lst.ToList();
            }
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.frmCarga oFrmCarga = new Presentacion.frmCarga();
            oFrmCarga.ShowDialog();

            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                Presentacion.frmCarga frmCarga = new Presentacion.frmCarga(id);
                frmCarga.ShowDialog();

                Refrescar();
            }

        }
        private int? GetId()
        {
            try
            {
                return int.Parse(dgvListado.Rows[dgvListado.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
               using(CrudEntities db = new CrudEntities())
                {
                    Empleado empleado = db.Empleadoes.Find(id);
                    db.Empleadoes.Remove(empleado);

                    db.SaveChanges();
                }

                Refrescar();
            }

        }
    }
}
