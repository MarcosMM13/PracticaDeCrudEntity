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

namespace PracticadeCrud.Presentacion
{
    public partial class frmCarga : Form
    {
        public int? id;
        Empleado oEmpleado = null;
        
        public frmCarga(int? id = null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {

                oEmpleado = db.Empleadoes.Find(id);
                txtNombre.Text = oEmpleado.Nombre;
                txtCorreo.Text = oEmpleado.Correo;
                dtpFechaNacimiento.Value = oEmpleado.FechaNacimiento;

                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(CrudEntities db = new CrudEntities())
            {
                if (id == null)
                    oEmpleado = new Empleado();
                                
                oEmpleado.Nombre = txtNombre.Text;
                oEmpleado.Correo = txtCorreo.Text;
                oEmpleado.FechaNacimiento = dtpFechaNacimiento.Value;

                if (id == null)
                {
                    db.Empleadoes.Add(oEmpleado);
                }
                else
                {
                    db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                }


                db.SaveChanges();

                this.Close();
            }
        }

        private void frmCarga_Load(object sender, EventArgs e)
        {

        }
    }
}
