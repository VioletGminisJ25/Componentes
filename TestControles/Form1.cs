using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestControles
{
    public partial class Form1 : Form//CB noeditable. Titulo e icono. Quitqr imAGEN al coger otro dir. Continuar si se cancela una nuevA APERTURA. Falla al abrir otro dir de imagenes si está en funcionamiento, SOLVED
    {
        private List<FileInfo> selectedFiles;
        private int imageCounter;
        private int timer;
        Timer tmr;
        Timer time;
        int counter;
        private bool timerStart;
        public Form1()
        {
            InitializeComponent();
            selectedFiles = new List<FileInfo>();
            imageCounter = 0;
            timer = 0;
            timerStart = true;
            counter = 0;

            for (int i = 1; i <= 20; i++)
            {
                comboBoxInterval.Items.Add(i);
            }


            time = new Timer();
            time.Interval = 1000;
            time.Tick += (object sender, EventArgs e) =>
            {
                reproductor1.Seconds = timer;
                if (selectedFiles != null && selectedFiles.Count != 0)
                {
                    if (counter == comboBoxInterval.SelectedIndex + 1)
                    {
                        imageCounter++;
                        counter = 0;
                    }
                    if (imageCounter == selectedFiles.Count)
                    {
                        imageCounter = 0;
                    }
                    Console.WriteLine(selectedFiles[imageCounter].FullName);
                    imageBox.Image = new Bitmap(selectedFiles[imageCounter].FullName);
                    counter++;
                }
                timer++;

            };
            //tmr = new Timer();
            //tmr.Tick += (object sender, EventArgs e) =>
            //{
            //};
            comboBoxInterval.SelectedIndex = 0;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            labelTextBox1.Posicion = labelTextBox1.Posicion == NuevosComponentes.LabelTextBox.EPosicion.DERECHA ? NuevosComponentes.LabelTextBox.EPosicion.IZQUIERDA : NuevosComponentes.LabelTextBox.EPosicion.DERECHA;
        }

        private void labelTextBox1_PositionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("LabelTextBox_Posicion:" + labelTextBox1.Posicion.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelTextBox1.Separacion += 5;
        }

        private void labelTextBox1_SeparacionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("SeparationChanged!");
        }

        private void labelTextBox1_KeysUp(object sender, EventArgs e)
        {
            Console.WriteLine("KeysUp!");
        }



        //        private void Form1_Paint(object sender, PaintEventArgs e)
        //        {
        //            Debug.WriteLine("Pintado");
        ////            e.Graphics.DrawString("Prueba de escritura de texto",
        ////this.Font, Brushes.BlueViolet, 10, 10);
        ////            this.CreateGraphics().DrawLine(new Pen(Color.Green), 10, 10, 100, 100);

        //        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    //Traslación
        //    g.TranslateTransform(100, 100);
        //    g.DrawLine(Pens.Red, 0, 0, 100, 0);
        //    g.ResetTransform();
        //    //Rotación de 30º en sentido horario
        //    g.RotateTransform(30);
        //    g.DrawLine(Pens.Blue, 0, 0, 100, 0);
        //    g.ResetTransform();
        //    //Traslación + rotación
        //    g.TranslateTransform(100, 100);
        //    g.RotateTransform(30);
        //    g.DrawLine(Pens.Green, 0, 0, 100, 0);
        //    g.ResetTransform();
        //}

        private void labelTextBox1_TxtChanged(object sender, EventArgs e)
        {
            Console.WriteLine("TextChanged");
        }

        private void etiquetaAviso1_Click(object sender, EventArgs e)
        {

        }

        private void etiquetaAviso1_ClickEnMarca(object sender, EventArgs e)
        {
            this.Text = this.Text == "ClickMarca" ? "Form1" : "ClickMarca";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reproductor1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imageBox.Image = null;
                selectedFiles.Clear();
                string path = dlg.SelectedPath.Trim();
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                FileInfo[] files = dirinfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".png" | file.Extension == ".jpg" | file.Extension == ".jpeg")
                    {
                        selectedFiles.Add(file);
                    }
                }

            }
        }

        private void reproductor1_PlayClick(object sender, EventArgs e)
        {

            if (timerStart)
            {
                //tmr.Start();
                time.Start();
                timerStart = false;
            }
            else
            {
                //tmr.Stop();
                time.Stop();
                timerStart = true;
            }
        }

        private void reproductor1_DesbordaTiempo(object sender, EventArgs e)
        {
            reproductor1.Minutes++;
            timer = 0;
        }

        private void filesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine((Int32.Parse(comboBoxInterval.SelectedItem + "")) * 1000);
            //    tmr.Interval = (Int32.Parse(comboBoxInterval.SelectedItem + "")) * 1000;
        }

        private void labelTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void validateTextBox1_TextBoxChanged_Event(object sender, EventArgs e)
        {
            this.Text = "Changed!";
        }
    }
}
