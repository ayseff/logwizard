namespace LogWizard
{
    partial class log_view
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
            this.list = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.labelName = new System.Windows.Forms.Label();
            this.viewName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllColumns.Add(this.olvColumn1);
            this.list.AllColumns.Add(this.olvColumn2);
            this.list.AllColumns.Add(this.olvColumn3);
            this.list.AllColumns.Add(this.olvColumn4);
            this.list.AllColumns.Add(this.olvColumn5);
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.list.Location = new System.Drawing.Point(3, 30);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(691, 394);
            this.list.TabIndex = 0;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "Line";
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "Date";
            // 
            // olvColumn3
            // 
            this.olvColumn3.Text = "Time";
            // 
            // olvColumn4
            // 
            this.olvColumn4.Text = "Level";
            // 
            // olvColumn5
            // 
            this.olvColumn5.FillsFreeSpace = true;
            this.olvColumn5.Text = "Message";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // viewName
            // 
            this.viewName.Location = new System.Drawing.Point(51, 6);
            this.viewName.Name = "viewName";
            this.viewName.Size = new System.Drawing.Size(265, 20);
            this.viewName.TabIndex = 2;
            this.viewName.TextChanged += new System.EventHandler(this.filterName_TextChanged);
            // 
            // log_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.list);
            this.Controls.Add(this.viewName);
            this.Controls.Add(this.labelName);
            this.Name = "log_view";
            this.Size = new System.Drawing.Size(697, 427);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView list;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox viewName;
    }
}
