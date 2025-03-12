    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NuevosComponentes.LabelTextBox;

namespace NuevosComponentes//Refresh subr
{
    [
        DefaultProperty("TextLbl"),
        DefaultEvent("Load")
    ]
    public partial class LabelTextBox : UserControl
    {
        public enum EPosicion
        {
            DERECHA, IZQUIERDA
        }

        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            Refresh();

        }



        private EPosicion posicion = EPosicion.IZQUIERDA;
        [Category("Mis Propiedades")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA Textbox")]
        public EPosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(EPosicion), value))
                {
                    posicion = value;
                    Refresh();

                    OnPositionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }



        //Pixeles de separación entre label y textbox
        private int separacion = 0;
        [Category("Mis Propiedades")] // O se puede meter en categoría Design.
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    Refresh();
                    OnSeparacionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        [Category("Mis Propiedades")] // O se puede meter en categoría Appearance.
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
               
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Mis Propiedades")] // O se puede meter en categoría Appearance.
        [Description("Texto asociado a la Label del control")]
        public char PswChar
        {
            set
            {
                txt.PasswordChar = value;
              
            }
            get
            {
                return txt.PasswordChar;
            }
        }
        [Category("Mis Propiedades")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }
        private bool subrayar;
        [Category("Mis propiedades")]
        [Description("Subrayar label")]
        public bool Subrayar
        {
            set
            {
                subrayar = value;
                Refresh();
            }
            get
            {
                return subrayar;
            }
        }

        private void recolocar()
        {
            switch (posicion)
            {
                case EPosicion.IZQUIERDA:
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    //Establecemos ancho del Textbox
                    //(la label tiene ancho por autosize)
                    //txt.Width = lbl.Width - Separacion;
                    this.Width = lbl.Width + Separacion + txt.Width;
                    //Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case EPosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del Textbox
                    //txt.Width = lbl.Width - Separacion;
                    //Establecemos posición del componente lbl
                    this.Width = lbl.Width + Separacion + txt.Width;

                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    //Establecemos altura del componente (Puede sacarse del switch)
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Refresh();
        }


        [Category("Mis propiedades")]
        [Description("Se lanza cuando la rpopiedad de la posicion cambia")]

        public event EventHandler PositionChanged;

        protected virtual void OnPositionChanged(EventArgs e)
        {
            if(PositionChanged != null)
            {
                PositionChanged(this, e);
            }
        }

        [Category("Mis propiedades")]
        [Description("Se lanza cuando la popiedad de la se cambia")]
        public event EventHandler SeparacionChanged;
        protected virtual void OnSeparacionChanged(EventArgs e)
        {
            if(SeparacionChanged != null)
            {
                SeparacionChanged(this, e);
            }
        }


        [Category("Mis propiedades")]
        [Description("Se lanza cuando la popiedad de la keyup cambia")]
        public event EventHandler KeysUp;
        protected virtual void OnKeyUp(EventArgs e)
        {
            if (KeysUp != null)
            {
                KeysUp(this, e);
            }
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }


        [Category("Mis propiedades")]
        [Description("Se lanza cuando la popiedad de la posicion cambia")]
        public event EventHandler TxtChanged;
        protected virtual void OnTxtChanged(EventArgs e)
        {
            if (TxtChanged != null)
            {
                TxtChanged(this, e);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            OnTxtChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            recolocar();
            if (subrayar)
            {
                e.Graphics.DrawLine(new Pen(Color.Black),lbl.Left,lbl.Height,lbl.Left+lbl.Width,lbl.Height);
            }
        }
        
    }
}
