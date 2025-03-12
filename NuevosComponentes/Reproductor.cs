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
    public partial class Reproductor : UserControl//Retocar segundos (set)
    {


        private ImageList imageList;
        public Reproductor()
        {
            InitializeComponent();
            btnPLay.Text = "▶";
        }

        private int minutes;
        [Category("Mis propiedades")]
        [Description("Minutos del contador")]
        public int Minutes
        {
            set
            {
                if (value >= 0)
                {

                    if (value >=60)
                    {
                        minutes = 0;

                    }
                    else
                    {
                        minutes = value;
                    }
                    lblTime.Text = $"{minutes.ToString("#00")}:{seconds.ToString("#00")}";
                    //  Refresh();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return minutes;
            }
        }

        private int seconds;
        [Category("Mis propiedades")]
        [Description("Segundos del contador")]
        public int Seconds
        {
            set
            {
                if (value >= 0)
                {

                    if (value >= 60)
                    {
                        seconds = 0;
                        OnDesbordaTiempo(EventArgs.Empty);
                    }
                    else
                    {
                        seconds = value;
                    }
                    lblTime.Text = $"{minutes.ToString("#00")}:{seconds.ToString("#00")}";
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return seconds;
            }
        }


        [Category("Mis Eventos")]
        [Description("Se lanza cuando hace click en el button play/pause")]
        public event EventHandler PlayClick;
        protected virtual void OnPlayClick(EventArgs e)
        {
            if (PlayClick != null)
            {
                PlayClick(this, e);
            }
        }

        [Category("Mis Eventos")]
        [Description("Se lanza cuando el tiempo pasa de 59 s.")]
        public event EventHandler DesbordaTiempo;
        protected virtual void OnDesbordaTiempo(EventArgs e)
        {
            if (DesbordaTiempo != null)
            {
                DesbordaTiempo(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnPLay.Text = btnPLay.Text == "▶" ? "| |" : "▶";
            OnPlayClick(e);
        }
    }
}
