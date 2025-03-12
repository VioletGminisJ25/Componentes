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
    public partial class ValidateTextBox : UserControl
    {

        public enum eTipo
        {
            Texto,
            Numerico
        }

        private eTipo tipo;
        [Category("Mis propiedades")]
        [Description("Tipo de validación")]
        public eTipo Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        private TextBox textbox;
        [Category("Mis propiedades")]
        [Description("Texto del textbox")]
        public string Texto
        {
            set
            {
                textbox.Text = value;
            }
            get
            {
                return textbox.Text;
            }
        }

        [Category("Mis propiedades")]
        [Description("MultiLine")]
        public bool Multiline
        {
            set
            {
                textbox.Multiline = value;
            }
            get
            {
                return textbox.Multiline;
            }
        }


        public ValidateTextBox()
        {
            InitializeComponent();
            textbox = new TextBox();
            textbox.Location = new Point(10, 10);
            this.Height = textbox.Height+20;
            textbox.Width = this.Width-20;
            this.Controls.Add(textbox);
            textbox.TextChanged += TextboxChanged;
        }
        private bool valid = false;

        private void TextboxChanged(object sender, EventArgs e)
        {
            if (tipo == eTipo.Numerico)
            {
                valid = false;
                if (int.TryParse(textbox.Text.Trim(), out int num))
                {
                    valid = true;
                }
                
            }
            if(tipo == eTipo.Texto)
            {
                valid = true;
                foreach (char c in textbox.Text)
                {
                    if (!(char.IsLetter(c) || c == ' '))
                    {
                        valid = false;
                    }
                }
            }
            Refresh();
            OnTextBoxChanged(EventArgs.Empty);
        }
        [Category("Mis eventos")]
        [Description("Texbox changed")]
        public event EventHandler TextBoxChanged_Event;
        protected virtual void OnTextBoxChanged(EventArgs e)
        {
            TextBoxChanged_Event?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen lapiz = new Pen(Color.Black);
            if (valid)
            {
                lapiz.Color = Color.Green;
            }
            else
            {
                lapiz.Color = Color.Red;
            }
            g.DrawRectangle(lapiz, 5, 5, this.Width - 10, this.Height - 10);
        }

    }
}
