namespace Configurator.Repository
{
    partial class RepositoryView
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Issue Tracker");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Repository", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRepositoryTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvRepositoryTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Size = new System.Drawing.Size(723, 451);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvRepositoryTree
            // 
            this.tvRepositoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRepositoryTree.Location = new System.Drawing.Point(0, 0);
            this.tvRepositoryTree.Name = "tvRepositoryTree";
            treeNode7.Name = "ndRepositoryGeneral";
            treeNode7.Text = "General";
            treeNode8.Name = "ndRepositoryIssueTracker";
            treeNode8.Text = "Issue Tracker";
            treeNode9.Name = "ndRepositoryRoot";
            treeNode9.Text = "Repository";
            this.tvRepositoryTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvRepositoryTree.Size = new System.Drawing.Size(228, 451);
            this.tvRepositoryTree.TabIndex = 0;
            this.tvRepositoryTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRepositoryTree_AfterSelect);
            // 
            // RepositoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainer1);
            this.Name = "RepositoryView";
            this.Size = new System.Drawing.Size(723, 451);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvRepositoryTree;
    }
}
