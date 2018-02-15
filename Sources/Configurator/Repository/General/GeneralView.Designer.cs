namespace Configurator.Repository.General
{
    partial class GeneralView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitRepository = new System.Windows.Forms.Button();
            this.lblRepositoryStaus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInitRepository
            // 
            this.btnInitRepository.Location = new System.Drawing.Point(10, 42);
            this.btnInitRepository.Name = "btnInitRepository";
            this.btnInitRepository.Size = new System.Drawing.Size(120, 23);
            this.btnInitRepository.TabIndex = 0;
            this.btnInitRepository.Text = "Initialize repository";
            this.btnInitRepository.UseVisualStyleBackColor = true;
            this.btnInitRepository.Click += new System.EventHandler(this.btnInitRepository_Click);
            // 
            // lblRepositoryStaus
            // 
            this.lblRepositoryStaus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRepositoryStaus.BackColor = System.Drawing.Color.Lime;
            this.lblRepositoryStaus.Location = new System.Drawing.Point(10, 10);
            this.lblRepositoryStaus.Name = "lblRepositoryStaus";
            this.lblRepositoryStaus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRepositoryStaus.Size = new System.Drawing.Size(453, 29);
            this.lblRepositoryStaus.TabIndex = 1;
            this.lblRepositoryStaus.Text = "label1";
            this.lblRepositoryStaus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeneralView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblRepositoryStaus);
            this.Controls.Add(this.btnInitRepository);
            this.Name = "GeneralView";
            this.Size = new System.Drawing.Size(473, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitRepository;
        private System.Windows.Forms.Label lblRepositoryStaus;
    }
}
