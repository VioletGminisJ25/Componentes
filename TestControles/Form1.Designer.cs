namespace TestControles
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            NuevosComponentes.EtiquetaAviso etiquetaAviso1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.FolderBrowser = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.reproductor1 = new NuevosComponentes.Reproductor();
            this.labelTextBox1 = new NuevosComponentes.LabelTextBox();
            this.dibujoAhorcado1 = new NuevosComponentes.DibujoAhorcado();
            etiquetaAviso1 = new NuevosComponentes.EtiquetaAviso();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cambio de la posicion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(553, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Separacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Location = new System.Drawing.Point(736, 319);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInterval.TabIndex = 6;
            this.comboBoxInterval.SelectedIndexChanged += new System.EventHandler(this.filesCombo_SelectedIndexChanged);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Location = new System.Drawing.Point(881, 317);
            this.FolderBrowser.Name = "FolderBrowser";
            this.FolderBrowser.Size = new System.Drawing.Size(75, 23);
            this.FolderBrowser.TabIndex = 7;
            this.FolderBrowser.Text = "Selected Folder";
            this.FolderBrowser.UseVisualStyleBackColor = true;
            this.FolderBrowser.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(747, 36);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(253, 226);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 8;
            this.imageBox.TabStop = false;
            // 
            // reproductor1
            // 
            this.reproductor1.Location = new System.Drawing.Point(763, 161);
            this.reproductor1.Minutes = 0;
            this.reproductor1.Name = "reproductor1";
            this.reproductor1.Seconds = 0;
            this.reproductor1.Size = new System.Drawing.Size(237, 150);
            this.reproductor1.TabIndex = 5;
            this.reproductor1.PlayClick += new System.EventHandler(this.reproductor1_PlayClick);
            this.reproductor1.DesbordaTiempo += new System.EventHandler(this.reproductor1_DesbordaTiempo);
            this.reproductor1.Load += new System.EventHandler(this.reproductor1_Load);
            // 
            // etiquetaAviso1
            // 
            etiquetaAviso1.Color1 = System.Drawing.Color.Gainsboro;
            etiquetaAviso1.Color2 = System.Drawing.Color.GreenYellow;
            etiquetaAviso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            etiquetaAviso1.GradientBackground = true;
            etiquetaAviso1.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso1.ImagenMarca")));
            etiquetaAviso1.Location = new System.Drawing.Point(175, 161);
            etiquetaAviso1.Marca = NuevosComponentes.EMarca.Imagen;
            etiquetaAviso1.Name = "etiquetaAviso1";
            etiquetaAviso1.Size = new System.Drawing.Size(155, 90);
            etiquetaAviso1.TabIndex = 4;
            etiquetaAviso1.Text = "aa";
            etiquetaAviso1.ClickEnMarca += new System.EventHandler(this.etiquetaAviso1_ClickEnMarca);
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.Location = new System.Drawing.Point(190, 92);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = NuevosComponentes.LabelTextBox.EPosicion.DERECHA;
            this.labelTextBox1.PswChar = '\0';
            this.labelTextBox1.Separacion = 0;
            this.labelTextBox1.Size = new System.Drawing.Size(172, 20);
            this.labelTextBox1.Subrayar = true;
            this.labelTextBox1.TabIndex = 3;
            this.labelTextBox1.TextLbl = "LabelTextBox";
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.PositionChanged += new System.EventHandler(this.labelTextBox1_PositionChanged);
            this.labelTextBox1.SeparacionChanged += new System.EventHandler(this.labelTextBox1_SeparacionChanged);
            this.labelTextBox1.KeysUp += new System.EventHandler(this.labelTextBox1_KeysUp);
            this.labelTextBox1.TxtChanged += new System.EventHandler(this.labelTextBox1_TxtChanged);
            this.labelTextBox1.Load += new System.EventHandler(this.labelTextBox1_Load);
            // 
            // dibujoAhorcado1
            // 
            this.dibujoAhorcado1.Errores = 1;
            this.dibujoAhorcado1.Location = new System.Drawing.Point(355, 118);
            this.dibujoAhorcado1.Name = "dibujoAhorcado1";
            this.dibujoAhorcado1.Size = new System.Drawing.Size(192, 317);
            this.dibujoAhorcado1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 450);
            this.Controls.Add(this.dibujoAhorcado1);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.FolderBrowser);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.reproductor1);
            this.Controls.Add(etiquetaAviso1);
            this.Controls.Add(this.labelTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Prueba componentes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private NuevosComponentes.LabelTextBox labelTextBox1;
        private NuevosComponentes.Reproductor reproductor1;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.Button FolderBrowser;
        private System.Windows.Forms.PictureBox imageBox;
        private NuevosComponentes.DibujoAhorcado dibujoAhorcado1;
    }
}

