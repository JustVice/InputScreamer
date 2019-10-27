namespace VScreamer
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
            this.button1_test_room = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1_test_room
            // 
            this.button1_test_room.Location = new System.Drawing.Point(469, 271);
            this.button1_test_room.Name = "button1_test_room";
            this.button1_test_room.Size = new System.Drawing.Size(75, 23);
            this.button1_test_room.TabIndex = 0;
            this.button1_test_room.Text = "Test Room";
            this.button1_test_room.UseVisualStyleBackColor = true;
            this.button1_test_room.Click += new System.EventHandler(this.button1_test_room_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 306);
            this.Controls.Add(this.button1_test_room);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1_test_room;
    }
}

