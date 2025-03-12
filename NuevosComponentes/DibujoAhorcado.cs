using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class DibujoAhorcado : UserControl
    {
        private int errores = 1;
        [Category("Mis propiedades")]
        [Description("Errores del ahorcado")]
        public int Errores
        {
            set
            {
                if (value > 0 && value <= 7)
                {
                    if(value == 7)
                    {
                        OnAhorcado(EventArgs.Empty);
                    }
                    errores = value;
                }
                Refresh();
                OnCambiaError(EventArgs.Empty);
            }
            get
            {
                return errores;
            }
        }
        public DibujoAhorcado()
        {
            InitializeComponent();
        }

        [Category("Mis eventos")]
        [Description("Se lanza cuando cambian los errores del ahorcado")]
        public event EventHandler CambiaError;
        protected virtual void OnCambiaError(EventArgs e)
        {
            CambiaError?.Invoke(this, e);
        }

        [Category("Mis eventos")]
        [Description("Se lanza cuando se ha completado el dibujo")]
        public event EventHandler Ahorcado;
        protected virtual void OnAhorcado(EventArgs e)
        {
            Ahorcado?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen lapiz = new Pen(Color.Black, 2);

            if (errores >= 1)
            {
                g.DrawLine(lapiz, 20, 250, 130, 250);
                g.DrawLine(lapiz, 50, 50, 50, 250);
                g.DrawLine(lapiz, 50, 50, 100, 50);
                g.DrawLine(lapiz, 100, 50, 100, 75);
            }

            if (errores >= 2)
            {
                g.DrawEllipse(lapiz, 75, 75, 50, 50);
            }
            if (errores >= 3)
            {
                g.DrawLine(lapiz, 100, 125, 100, 200);
            }
            if (errores >= 4)
            {
                g.DrawLine(lapiz, 100, 140, 125, 170);
            }
            if (errores >= 5)
            {
                g.DrawLine(lapiz, 100, 140, 75, 170);
            }
            if (errores >= 6)
            {
                g.DrawLine(lapiz, 100, 200, 125, 230);
            }
            if (errores >= 7)
            {
                g.DrawLine(lapiz, 100, 200, 75, 230);
            }
        }

    }
}
