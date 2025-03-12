using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes//revisar refresh y nombre propiedades. SIn imagen. Probar ClickEnMarca
{
    public enum EMarca
    {
        Nada,
        Cruz,
        Circulo,
        Imagen
    }
    public partial class EtiquetaAviso : Control
    {
        private int grosor; //Grosor de las líneas de dibujo
        private int offsetX;  //Desplazamiento a la derecha del texto
        private int offsetY;
        private EMarca marca = EMarca.Nada;
        private bool gradientBackground = false;
        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        public EMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }

        private Image imagenMarca;
        [Category("Appearance")]
        [Description("Ruta a la imagen de marca")]
        public Image ImagenMarca
        {
            set
            {
                if (value != null)
                {
                    imagenMarca = value;
                    this.Refresh();
                }
            }
            get
            {
                return imagenMarca;
            }
        }
        private Color color1;
        [Category("Appearance")]
        [Description("Color1")]
        public Color Color1
        {
            set
            {
                color1 = value;
                this.Refresh();
            }
            get
            {
                return color1;
            }
        }
        private Color color2;
        [Category("Appearance")]
        [Description("Ruta a la imagen de marca")]
        public Color Color2
        {
            set
            {
                color2 = value;
                this.Refresh();
            }
            get
            {
                return color2;
            }
        }
        [Category("Appearance")]
        [Description("Para poner un gradiente de fondo")]
        public bool GradientBackground
        {
            set
            {
                gradientBackground = value;
                this.Refresh();
            }
            get
            {
                return gradientBackground;
            }
        }
        public EtiquetaAviso()
        {
            InitializeComponent();
            color1 = Color.Red;
            color2 = Color.Green;
        }

        [Category("Eventos Custom")]
        [Description("Click en marca lanza evento")]

        public event EventHandler ClickEnMarca;

        protected virtual void OnClickEnMarca(EventArgs e)
        {
            if (ClickEnMarca != null)
            {
                ClickEnMarca(this, e);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (marca != EMarca.Nada && e.Location.X > 0 && e.Location.X <= this.Height)
            {
                OnClickEnMarca(e);
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            grosor = 0; //Grosor de las líneas de dibujo
            offsetX = 0; //Desplazamiento a la derecha del texto
            offsetY = 0; //Desplazamiento hacia abajo del texto
                         // Altura de fuente, usada como referencia en varias partes
            int h = this.Font.Height;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
            // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            if (gradientBackground)
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Horizontal);
                g.FillRectangle(brush, rect);

            }
            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case EMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    h, h);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;
                case EMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;

                case EMarca.Imagen:
                    grosor = 15;
                    try
                    {
                        Bitmap image = new Bitmap(imagenMarca);
                        g.DrawImage(image, grosor, grosor, h, h);
                    }
                    catch (Exception ex) when (ex is ArgumentException || ex is FileNotFoundException)
                    {
                        marca = EMarca.Nada;
                    }
                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;
            }
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

    }
}
