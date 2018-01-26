namespace AirLineManager
{
    partial class AswLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginReason = new System.Windows.Forms.TextBox();
            this.rdSorfware = new System.Windows.Forms.RadioButton();
            this.rdSystem = new System.Windows.Forms.RadioButton();
            this.btncomfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No logout in last login :";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Location = new System.Drawing.Point(190, 23);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(0, 17);
            this.lblLastLogin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reason:";
            // 
            // txtLoginReason
            // 
            this.txtLoginReason.Location = new System.Drawing.Point(34, 76);
            this.txtLoginReason.Multiline = true;
            this.txtLoginReason.Name = "txtLoginReason";
            this.txtLoginReason.Size = new System.Drawing.Size(354, 133);
            this.txtLoginReason.TabIndex = 3;
            // 
            // rdSorfware
            // 
            this.rdSorfware.AutoSize = true;
            this.rdSorfware.Location = new System.Drawing.Point(34, 219);
            this.rdSorfware.Name = "rdSorfware";
            this.rdSorfware.Size = new System.Drawing.Size(144, 21);
            this.rdSorfware.TabIndex = 4;
            this.rdSorfware.TabStop = true;
            this.rdSorfware.Text = "Sorftware Crash";
            this.rdSorfware.UseVisualStyleBackColor = true;
            // 
            // rdSystem
            // 
            this.rdSystem.AutoSize = true;
            this.rdSystem.Location = new System.Drawing.Point(179, 220);
            this.rdSystem.Name = "rdSystem";
            this.rdSystem.Size = new System.Drawing.Size(128, 21);
            this.rdSystem.TabIndex = 4;
            this.rdSystem.TabStop = true;
            this.rdSystem.Text = "System Crash";
            this.rdSystem.UseVisualStyleBackColor = true;
            // 
            // btncomfirm
            // 
            this.btncomfirm.Location = new System.Drawing.Point(313, 216);
            this.btncomfirm.Name = "btncomfirm";
            this.btncomfirm.Size = new System.Drawing.Size(75, 25);
            this.btncomfirm.TabIndex = 5;
            this.btncomfirm.Text = "Comfirm";
            this.btncomfirm.UseVisualStyleBackColor = true;
            this.btncomfirm.Click += new System.EventHandler(this.btncomfirm_Click);
            // 
            // AswLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 253);
            this.Controls.Add(this.btncomfirm);
            this.Controls.Add(this.rdSystem);
            this.Controls.Add(this.rdSorfware);
            this.Controls.Add(this.txtLoginReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLastLogin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AswLog";
            this.Text = "No Logout detected";
            this.Load += new System.EventHandler(this.AswLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginReason;
        private System.Windows.Forms.RadioButton rdSorfware;
        private System.Windows.Forms.RadioButton rdSystem;
        private System.Windows.Forms.Button btncomfirm;
    }
}