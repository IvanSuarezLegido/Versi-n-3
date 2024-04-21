namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.nombreReg = new System.Windows.Forms.TextBox();
            this.registroBoton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.usuarioActual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contraReg = new System.Windows.Forms.TextBox();
            this.logeoBoton = new System.Windows.Forms.Button();
            this.muertesDe = new System.Windows.Forms.RadioButton();
            this.mejorJugador = new System.Windows.Forms.RadioButton();
            this.victoriasDe = new System.Windows.Forms.RadioButton();
            this.mayorTurnos = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.consultaBoton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nombreConsulta = new System.Windows.Forms.TextBox();
            this.conectarBoton = new System.Windows.Forms.Button();
            this.desconectarBoton = new System.Windows.Forms.Button();
            this.contLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // nombreReg
            // 
            this.nombreReg.Location = new System.Drawing.Point(116, 31);
            this.nombreReg.Name = "nombreReg";
            this.nombreReg.Size = new System.Drawing.Size(164, 20);
            this.nombreReg.TabIndex = 3;
            // 
            // registroBoton
            // 
            this.registroBoton.Location = new System.Drawing.Point(28, 95);
            this.registroBoton.Name = "registroBoton";
            this.registroBoton.Size = new System.Drawing.Size(93, 35);
            this.registroBoton.TabIndex = 5;
            this.registroBoton.Text = "Registrarse";
            this.registroBoton.UseVisualStyleBackColor = true;
            this.registroBoton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.usuarioActual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.contraReg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.registroBoton);
            this.groupBox1.Controls.Add(this.nombreReg);
            this.groupBox1.Controls.Add(this.logeoBoton);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 202);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "Cerrar Sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // usuarioActual
            // 
            this.usuarioActual.AutoSize = true;
            this.usuarioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioActual.Location = new System.Drawing.Point(116, 147);
            this.usuarioActual.Name = "usuarioActual";
            this.usuarioActual.Size = new System.Drawing.Size(63, 25);
            this.usuarioActual.TabIndex = 13;
            this.usuarioActual.Text = "None";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Usuario:";
            // 
            // contraReg
            // 
            this.contraReg.Location = new System.Drawing.Point(146, 65);
            this.contraReg.Name = "contraReg";
            this.contraReg.Size = new System.Drawing.Size(134, 20);
            this.contraReg.TabIndex = 10;
            // 
            // logeoBoton
            // 
            this.logeoBoton.Location = new System.Drawing.Point(127, 95);
            this.logeoBoton.Name = "logeoBoton";
            this.logeoBoton.Size = new System.Drawing.Size(93, 35);
            this.logeoBoton.TabIndex = 5;
            this.logeoBoton.Text = "Logearse";
            this.logeoBoton.UseVisualStyleBackColor = true;
            this.logeoBoton.Click += new System.EventHandler(this.logeoBoton_Click);
            // 
            // muertesDe
            // 
            this.muertesDe.AutoSize = true;
            this.muertesDe.Location = new System.Drawing.Point(28, 134);
            this.muertesDe.Name = "muertesDe";
            this.muertesDe.Size = new System.Drawing.Size(175, 17);
            this.muertesDe.TabIndex = 12;
            this.muertesDe.TabStop = true;
            this.muertesDe.Text = "Dime cuantas veces ha muerto ";
            this.muertesDe.UseVisualStyleBackColor = true;
            // 
            // mejorJugador
            // 
            this.mejorJugador.AutoSize = true;
            this.mejorJugador.Location = new System.Drawing.Point(28, 111);
            this.mejorJugador.Name = "mejorJugador";
            this.mejorJugador.Size = new System.Drawing.Size(126, 17);
            this.mejorJugador.TabIndex = 9;
            this.mejorJugador.TabStop = true;
            this.mejorJugador.Text = "Dime el mejor jugador";
            this.mejorJugador.UseVisualStyleBackColor = true;
            // 
            // victoriasDe
            // 
            this.victoriasDe.AutoSize = true;
            this.victoriasDe.Location = new System.Drawing.Point(28, 89);
            this.victoriasDe.Name = "victoriasDe";
            this.victoriasDe.Size = new System.Drawing.Size(125, 17);
            this.victoriasDe.TabIndex = 7;
            this.victoriasDe.TabStop = true;
            this.victoriasDe.Text = "Dime las victorias de ";
            this.victoriasDe.UseVisualStyleBackColor = true;
            // 
            // mayorTurnos
            // 
            this.mayorTurnos.AutoSize = true;
            this.mayorTurnos.Location = new System.Drawing.Point(28, 66);
            this.mayorTurnos.Name = "mayorTurnos";
            this.mayorTurnos.Size = new System.Drawing.Size(243, 17);
            this.mayorTurnos.TabIndex = 8;
            this.mayorTurnos.TabStop = true;
            this.mayorTurnos.Text = "Dime la partida con el mayor numero de turnos";
            this.mayorTurnos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox3.Controls.Add(this.consultaBoton);
            this.groupBox3.Controls.Add(this.muertesDe);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nombreConsulta);
            this.groupBox3.Controls.Add(this.mejorJugador);
            this.groupBox3.Controls.Add(this.mayorTurnos);
            this.groupBox3.Controls.Add(this.victoriasDe);
            this.groupBox3.Location = new System.Drawing.Point(10, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 202);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultas";
            // 
            // consultaBoton
            // 
            this.consultaBoton.Location = new System.Drawing.Point(284, 72);
            this.consultaBoton.Name = "consultaBoton";
            this.consultaBoton.Size = new System.Drawing.Size(58, 79);
            this.consultaBoton.TabIndex = 16;
            this.consultaBoton.Text = "Enviar";
            this.consultaBoton.UseVisualStyleBackColor = true;
            this.consultaBoton.Click += new System.EventHandler(this.consultaBoton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nombre";
            // 
            // nombreConsulta
            // 
            this.nombreConsulta.Location = new System.Drawing.Point(116, 31);
            this.nombreConsulta.Name = "nombreConsulta";
            this.nombreConsulta.Size = new System.Drawing.Size(164, 20);
            this.nombreConsulta.TabIndex = 3;
            // 
            // conectarBoton
            // 
            this.conectarBoton.Location = new System.Drawing.Point(392, 36);
            this.conectarBoton.Name = "conectarBoton";
            this.conectarBoton.Size = new System.Drawing.Size(149, 72);
            this.conectarBoton.TabIndex = 16;
            this.conectarBoton.Text = "Conectar";
            this.conectarBoton.UseVisualStyleBackColor = true;
            this.conectarBoton.Click += new System.EventHandler(this.conectarBoton_Click);
            // 
            // desconectarBoton
            // 
            this.desconectarBoton.Location = new System.Drawing.Point(392, 126);
            this.desconectarBoton.Name = "desconectarBoton";
            this.desconectarBoton.Size = new System.Drawing.Size(149, 72);
            this.desconectarBoton.TabIndex = 17;
            this.desconectarBoton.Text = "Desconectar";
            this.desconectarBoton.UseVisualStyleBackColor = true;
            this.desconectarBoton.Click += new System.EventHandler(this.desconectarBoton_Click);
            // 
            // contLbl
            // 
            this.contLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contLbl.Location = new System.Drawing.Point(584, 126);
            this.contLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.contLbl.Name = "contLbl";
            this.contLbl.Size = new System.Drawing.Size(156, 109);
            this.contLbl.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 562);
            this.Controls.Add(this.contLbl);
            this.Controls.Add(this.desconectarBoton);
            this.Controls.Add(this.conectarBoton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreReg;
        private System.Windows.Forms.Button registroBoton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contraReg;
        private System.Windows.Forms.Button logeoBoton;
        private System.Windows.Forms.RadioButton muertesDe;
        private System.Windows.Forms.RadioButton mejorJugador;
        private System.Windows.Forms.RadioButton victoriasDe;
        private System.Windows.Forms.RadioButton mayorTurnos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button consultaBoton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombreConsulta;
        private System.Windows.Forms.Button conectarBoton;
        private System.Windows.Forms.Button desconectarBoton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label usuarioActual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label contLbl;
    }
}

