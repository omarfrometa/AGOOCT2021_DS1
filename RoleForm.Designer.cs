
namespace DS1
{
    partial class RoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GestionDeRoles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(30, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregación de rol";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // GestionDeRoles
            // 
            this.GestionDeRoles.AutoSize = true;
            this.GestionDeRoles.Location = new System.Drawing.Point(30, 13);
            this.GestionDeRoles.Name = "GestionDeRoles";
            this.GestionDeRoles.Size = new System.Drawing.Size(83, 13);
            this.GestionDeRoles.TabIndex = 1;
            this.GestionDeRoles.Text = "Gestion de roles";
            this.GestionDeRoles.Click += new System.EventHandler(this.label1_Click);
            // 
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GestionDeRoles);
            this.Controls.Add(this.groupBox1);
            this.Name = "RoleForm";
            this.Text = "RoleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label GestionDeRoles;
    }
}