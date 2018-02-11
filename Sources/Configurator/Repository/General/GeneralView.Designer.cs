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
            this.SuspendLayout();
            // 
            // btnInitRepository
            // 
            this.btnInitRepository.Location = new System.Drawing.Point(3, 3);
            this.btnInitRepository.Name = "btnInitRepository";
            this.btnInitRepository.Size = new System.Drawing.Size(120, 23);
            this.btnInitRepository.TabIndex = 0;
            this.btnInitRepository.Text = "Initialize repository";
            this.btnInitRepository.UseVisualStyleBackColor = true;
            // 
            // GeneralView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInitRepository);
            this.Name = "GeneralView";
            this.Size = new System.Drawing.Size(473, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitRepository;
    }
}
