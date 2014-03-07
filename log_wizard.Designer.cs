namespace LogWizard
{
    partial class LogWizard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWizard));
            this.delFilter = new System.Windows.Forms.Button();
            this.addFilter = new System.Windows.Forms.Button();
            this.filtersCtrl = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label4 = new System.Windows.Forms.Label();
            this.curFilterCtrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMatch = new System.Windows.Forms.TextBox();
            this.newView = new System.Windows.Forms.Button();
            this.logHistory = new System.Windows.Forms.ComboBox();
            this.newFilteredView = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.friendlyNameCtrl = new System.Windows.Forms.TextBox();
            this.toggleFilters = new System.Windows.Forms.Button();
            this.toggleSource = new System.Windows.Forms.Button();
            this.toggleFullLog = new System.Windows.Forms.Button();
            this.logSyntaxCtrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.delFilteredView = new System.Windows.Forms.Button();
            this.toggleTips = new System.Windows.Forms.Button();
            this.curContextCtrl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addContext = new System.Windows.Forms.Button();
            this.delContext = new System.Windows.Forms.Button();
            this.main = new System.Windows.Forms.SplitContainer();
            this.sourceUp = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.sourceNameCtrl = new System.Windows.Forms.TextBox();
            this.sourceTypeCtrl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filteredLeft = new System.Windows.Forms.SplitContainer();
            this.filteredViewsCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dropHere = new System.Windows.Forms.Label();
            this.fullLogCtrl = new System.Windows.Forms.TextBox();
            this.refresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.filtersCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main)).BeginInit();
            this.main.Panel1.SuspendLayout();
            this.main.Panel2.SuspendLayout();
            this.main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceUp)).BeginInit();
            this.sourceUp.Panel1.SuspendLayout();
            this.sourceUp.Panel2.SuspendLayout();
            this.sourceUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filteredLeft)).BeginInit();
            this.filteredLeft.Panel1.SuspendLayout();
            this.filteredLeft.Panel2.SuspendLayout();
            this.filteredLeft.SuspendLayout();
            this.filteredViewsCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delFilter
            // 
            this.delFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delFilter.Location = new System.Drawing.Point(245, 358);
            this.delFilter.Name = "delFilter";
            this.delFilter.Size = new System.Drawing.Size(24, 23);
            this.delFilter.TabIndex = 10;
            this.delFilter.Text = "-";
            this.tip.SetToolTip(this.delFilter, "Delete Filter");
            this.delFilter.UseVisualStyleBackColor = true;
            this.delFilter.Click += new System.EventHandler(this.delFilter_Click);
            // 
            // addFilter
            // 
            this.addFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilter.Location = new System.Drawing.Point(215, 358);
            this.addFilter.Name = "addFilter";
            this.addFilter.Size = new System.Drawing.Size(24, 23);
            this.addFilter.TabIndex = 9;
            this.addFilter.Text = "+";
            this.tip.SetToolTip(this.addFilter, "Add Filter");
            this.addFilter.UseVisualStyleBackColor = true;
            this.addFilter.Click += new System.EventHandler(this.addFilter_Click);
            // 
            // filtersCtrl
            // 
            this.filtersCtrl.AllColumns.Add(this.olvColumn4);
            this.filtersCtrl.AllColumns.Add(this.olvColumn1);
            this.filtersCtrl.AllColumns.Add(this.olvColumn2);
            this.filtersCtrl.AllColumns.Add(this.olvColumn3);
            this.filtersCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersCtrl.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.filtersCtrl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn4,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.filtersCtrl.FullRowSelect = true;
            this.filtersCtrl.HeaderUsesThemes = false;
            this.filtersCtrl.HeaderWordWrap = true;
            this.filtersCtrl.HideSelection = false;
            this.filtersCtrl.HighlightBackgroundColor = System.Drawing.Color.Silver;
            this.filtersCtrl.Location = new System.Drawing.Point(12, 30);
            this.filtersCtrl.MultiSelect = false;
            this.filtersCtrl.Name = "filtersCtrl";
            this.filtersCtrl.ShowFilterMenuOnRightClick = false;
            this.filtersCtrl.ShowImagesOnSubItems = true;
            this.filtersCtrl.Size = new System.Drawing.Size(257, 322);
            this.filtersCtrl.TabIndex = 4;
            this.filtersCtrl.UseAlternatingBackColors = true;
            this.filtersCtrl.UseCellFormatEvents = true;
            this.filtersCtrl.UseCompatibleStateImageBehavior = false;
            this.filtersCtrl.UseCustomSelectionColors = true;
            this.filtersCtrl.UseSubItemCheckBoxes = true;
            this.filtersCtrl.View = System.Windows.Forms.View.Details;
            this.filtersCtrl.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.filtersCtrl_ItemsChanged);
            this.filtersCtrl.SelectionChanged += new System.EventHandler(this.filters_SelectionChanged);
            // 
            // olvColumn4
            // 
            this.olvColumn4.MaximumWidth = 0;
            this.olvColumn4.MinimumWidth = 0;
            this.olvColumn4.Width = 0;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "enabled";
            this.olvColumn1.CheckBoxes = true;
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Text = "Enabled";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "used";
            this.olvColumn2.CheckBoxes = true;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Used";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "name";
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.Text = "Name";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hover for tips";
            // 
            // curFilterCtrl
            // 
            this.curFilterCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.curFilterCtrl.Enabled = false;
            this.curFilterCtrl.Location = new System.Drawing.Point(58, 386);
            this.curFilterCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.curFilterCtrl.Multiline = true;
            this.curFilterCtrl.Name = "curFilterCtrl";
            this.curFilterCtrl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.curFilterCtrl.Size = new System.Drawing.Size(211, 72);
            this.curFilterCtrl.TabIndex = 3;
            this.tip.SetToolTip(this.curFilterCtrl, resources.GetString("curFilterCtrl.ToolTip"));
            this.curFilterCtrl.TextChanged += new System.EventHandler(this.curFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filters";
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 32000;
            this.tip.InitialDelay = 500;
            this.tip.IsBalloon = true;
            this.tip.ReshowDelay = 100;
            // 
            // contextMatch
            // 
            this.contextMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contextMatch.Location = new System.Drawing.Point(338, 88);
            this.contextMatch.Name = "contextMatch";
            this.contextMatch.Size = new System.Drawing.Size(633, 23);
            this.contextMatch.TabIndex = 5;
            this.tip.SetToolTip(this.contextMatch, "If non empty, it\'s a regex - if any source\'s name matches this, this context is a" +
        "pplied by default");
            // 
            // newView
            // 
            this.newView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newView.Location = new System.Drawing.Point(1192, 491);
            this.newView.Name = "newView";
            this.newView.Size = new System.Drawing.Size(51, 23);
            this.newView.TabIndex = 6;
            this.newView.Text = "New";
            this.tip.SetToolTip(this.newView, "Opens a new view, in which you can view another log");
            this.newView.UseVisualStyleBackColor = true;
            this.newView.Click += new System.EventHandler(this.newView_Click);
            // 
            // logHistory
            // 
            this.logHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logHistory.FormattingEnabled = true;
            this.logHistory.Location = new System.Drawing.Point(161, 491);
            this.logHistory.Name = "logHistory";
            this.logHistory.Size = new System.Drawing.Size(1025, 23);
            this.logHistory.TabIndex = 7;
            this.tip.SetToolTip(this.logHistory, "History - just select any of the previous logs, and they instantly load");
            this.logHistory.SelectedIndexChanged += new System.EventHandler(this.logHistory_SelectedIndexChanged);
            this.logHistory.DropDownClosed += new System.EventHandler(this.logHistory_DropDownClosed);
            // 
            // newFilteredView
            // 
            this.newFilteredView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFilteredView.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFilteredView.Location = new System.Drawing.Point(513, 3);
            this.newFilteredView.Name = "newFilteredView";
            this.newFilteredView.Size = new System.Drawing.Size(18, 18);
            this.newFilteredView.TabIndex = 1;
            this.newFilteredView.Text = "+";
            this.tip.SetToolTip(this.newFilteredView, "New Filtered View of the same Log");
            this.newFilteredView.UseVisualStyleBackColor = true;
            this.newFilteredView.Click += new System.EventHandler(this.newFilteredView_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Friendly Name (optional)";
            this.tip.SetToolTip(this.label7, "You can assign a friendlier name to this log, so you can easier locate it in hist" +
        "ory");
            // 
            // friendlyNameCtrl
            // 
            this.friendlyNameCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyNameCtrl.Location = new System.Drawing.Point(206, 59);
            this.friendlyNameCtrl.Name = "friendlyNameCtrl";
            this.friendlyNameCtrl.Size = new System.Drawing.Size(765, 23);
            this.friendlyNameCtrl.TabIndex = 8;
            this.tip.SetToolTip(this.friendlyNameCtrl, "You can assign a friendlier name to this log, so you can easier locate it in hist" +
        "ory");
            this.friendlyNameCtrl.TextChanged += new System.EventHandler(this.friendlyName_TextChanged);
            // 
            // toggleFilters
            // 
            this.toggleFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleFilters.Location = new System.Drawing.Point(8, 491);
            this.toggleFilters.Name = "toggleFilters";
            this.toggleFilters.Size = new System.Drawing.Size(32, 23);
            this.toggleFilters.TabIndex = 8;
            this.toggleFilters.Text = "+F";
            this.tip.SetToolTip(this.toggleFilters, "Show/Hide Filters");
            this.toggleFilters.UseVisualStyleBackColor = true;
            this.toggleFilters.Click += new System.EventHandler(this.toggleFilters_Click);
            // 
            // toggleSource
            // 
            this.toggleSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleSource.Location = new System.Drawing.Point(46, 491);
            this.toggleSource.Name = "toggleSource";
            this.toggleSource.Size = new System.Drawing.Size(32, 23);
            this.toggleSource.TabIndex = 9;
            this.toggleSource.Text = "+S";
            this.tip.SetToolTip(this.toggleSource, "Show/Hide Source");
            this.toggleSource.UseVisualStyleBackColor = true;
            this.toggleSource.Click += new System.EventHandler(this.toggleSource_Click);
            // 
            // toggleFullLog
            // 
            this.toggleFullLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleFullLog.Location = new System.Drawing.Point(84, 491);
            this.toggleFullLog.Name = "toggleFullLog";
            this.toggleFullLog.Size = new System.Drawing.Size(32, 23);
            this.toggleFullLog.TabIndex = 10;
            this.toggleFullLog.Text = "+L";
            this.tip.SetToolTip(this.toggleFullLog, "Show/Hide Full Log");
            this.toggleFullLog.UseVisualStyleBackColor = true;
            this.toggleFullLog.Click += new System.EventHandler(this.toggleFullLog_Click);
            // 
            // logSyntaxCtrl
            // 
            this.logSyntaxCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logSyntaxCtrl.Location = new System.Drawing.Point(206, 30);
            this.logSyntaxCtrl.Name = "logSyntaxCtrl";
            this.logSyntaxCtrl.Size = new System.Drawing.Size(765, 23);
            this.logSyntaxCtrl.TabIndex = 10;
            this.tip.SetToolTip(this.logSyntaxCtrl, "The syntax of each line");
            this.logSyntaxCtrl.TextChanged += new System.EventHandler(this.logSyntax_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Log Line Syntax";
            this.tip.SetToolTip(this.label8, "The syntax of each line");
            // 
            // delFilteredView
            // 
            this.delFilteredView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delFilteredView.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delFilteredView.Location = new System.Drawing.Point(535, 3);
            this.delFilteredView.Name = "delFilteredView";
            this.delFilteredView.Size = new System.Drawing.Size(18, 18);
            this.delFilteredView.TabIndex = 2;
            this.delFilteredView.Text = "-";
            this.tip.SetToolTip(this.delFilteredView, "Delete this View");
            this.delFilteredView.UseVisualStyleBackColor = true;
            this.delFilteredView.Click += new System.EventHandler(this.delFilteredView_Click);
            // 
            // toggleTips
            // 
            this.toggleTips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleTips.Location = new System.Drawing.Point(122, 491);
            this.toggleTips.Name = "toggleTips";
            this.toggleTips.Size = new System.Drawing.Size(33, 23);
            this.toggleTips.TabIndex = 11;
            this.toggleTips.Text = "-T";
            this.tip.SetToolTip(this.toggleTips, "Show/Hide Tips");
            this.toggleTips.UseVisualStyleBackColor = true;
            this.toggleTips.Click += new System.EventHandler(this.toggleTips_Click);
            // 
            // curContextCtrl
            // 
            this.curContextCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.curContextCtrl.FormattingEnabled = true;
            this.curContextCtrl.Location = new System.Drawing.Point(66, 89);
            this.curContextCtrl.Name = "curContextCtrl";
            this.curContextCtrl.Size = new System.Drawing.Size(134, 23);
            this.curContextCtrl.TabIndex = 4;
            this.tip.SetToolTip(this.curContextCtrl, resources.GetString("curContextCtrl.ToolTip"));
            this.curContextCtrl.DropDown += new System.EventHandler(this.curContextCtrl_DropDown);
            this.curContextCtrl.SelectedIndexChanged += new System.EventHandler(this.curContextCtrl_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Template";
            this.tip.SetToolTip(this.label5, "\r\n");
            // 
            // addContext
            // 
            this.addContext.Location = new System.Drawing.Point(206, 90);
            this.addContext.Name = "addContext";
            this.addContext.Size = new System.Drawing.Size(23, 22);
            this.addContext.TabIndex = 11;
            this.addContext.Text = "+";
            this.tip.SetToolTip(this.addContext, "Add a template");
            this.addContext.UseVisualStyleBackColor = true;
            this.addContext.Click += new System.EventHandler(this.addContext_Click);
            // 
            // delContext
            // 
            this.delContext.Enabled = false;
            this.delContext.Location = new System.Drawing.Point(233, 90);
            this.delContext.Name = "delContext";
            this.delContext.Size = new System.Drawing.Size(25, 22);
            this.delContext.TabIndex = 12;
            this.delContext.Text = "-";
            this.tip.SetToolTip(this.delContext, "Delete current template");
            this.delContext.UseVisualStyleBackColor = true;
            this.delContext.Click += new System.EventHandler(this.delContext_Click);
            // 
            // main
            // 
            this.main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main.IsSplitterFixed = true;
            this.main.Location = new System.Drawing.Point(2, 1);
            this.main.Name = "main";
            // 
            // main.Panel1
            // 
            this.main.Panel1.Controls.Add(this.delFilter);
            this.main.Panel1.Controls.Add(this.filtersCtrl);
            this.main.Panel1.Controls.Add(this.addFilter);
            this.main.Panel1.Controls.Add(this.label1);
            this.main.Panel1.Controls.Add(this.label2);
            this.main.Panel1.Controls.Add(this.label4);
            this.main.Panel1.Controls.Add(this.curFilterCtrl);
            // 
            // main.Panel2
            // 
            this.main.Panel2.Controls.Add(this.sourceUp);
            this.main.Size = new System.Drawing.Size(1258, 484);
            this.main.SplitterDistance = 273;
            this.main.TabIndex = 4;
            // 
            // sourceUp
            // 
            this.sourceUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceUp.IsSplitterFixed = true;
            this.sourceUp.Location = new System.Drawing.Point(0, 0);
            this.sourceUp.Name = "sourceUp";
            this.sourceUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sourceUp.Panel1
            // 
            this.sourceUp.Panel1.Controls.Add(this.delContext);
            this.sourceUp.Panel1.Controls.Add(this.addContext);
            this.sourceUp.Panel1.Controls.Add(this.logSyntaxCtrl);
            this.sourceUp.Panel1.Controls.Add(this.label8);
            this.sourceUp.Panel1.Controls.Add(this.friendlyNameCtrl);
            this.sourceUp.Panel1.Controls.Add(this.label7);
            this.sourceUp.Panel1.Controls.Add(this.label6);
            this.sourceUp.Panel1.Controls.Add(this.contextMatch);
            this.sourceUp.Panel1.Controls.Add(this.curContextCtrl);
            this.sourceUp.Panel1.Controls.Add(this.label5);
            this.sourceUp.Panel1.Controls.Add(this.sourceNameCtrl);
            this.sourceUp.Panel1.Controls.Add(this.sourceTypeCtrl);
            this.sourceUp.Panel1.Controls.Add(this.label3);
            // 
            // sourceUp.Panel2
            // 
            this.sourceUp.Panel2.Controls.Add(this.filteredLeft);
            this.sourceUp.Size = new System.Drawing.Size(981, 484);
            this.sourceUp.SplitterDistance = 116;
            this.sourceUp.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Auto Match";
            // 
            // sourceNameCtrl
            // 
            this.sourceNameCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceNameCtrl.Location = new System.Drawing.Point(206, 3);
            this.sourceNameCtrl.Name = "sourceNameCtrl";
            this.sourceNameCtrl.Size = new System.Drawing.Size(772, 23);
            this.sourceNameCtrl.TabIndex = 2;
            this.sourceNameCtrl.TextChanged += new System.EventHandler(this.sourceName_TextChanged);
            // 
            // sourceTypeCtrl
            // 
            this.sourceTypeCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceTypeCtrl.FormattingEnabled = true;
            this.sourceTypeCtrl.Items.AddRange(new object[] {
            "File",
            "Shared Memory",
            "Debug Window"});
            this.sourceTypeCtrl.Location = new System.Drawing.Point(66, 4);
            this.sourceTypeCtrl.Name = "sourceTypeCtrl";
            this.sourceTypeCtrl.Size = new System.Drawing.Size(134, 23);
            this.sourceTypeCtrl.TabIndex = 1;
            this.sourceTypeCtrl.SelectedIndexChanged += new System.EventHandler(this.sourceType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Source";
            // 
            // filteredLeft
            // 
            this.filteredLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filteredLeft.Location = new System.Drawing.Point(0, 0);
            this.filteredLeft.Name = "filteredLeft";
            // 
            // filteredLeft.Panel1
            // 
            this.filteredLeft.Panel1.Controls.Add(this.delFilteredView);
            this.filteredLeft.Panel1.Controls.Add(this.newFilteredView);
            this.filteredLeft.Panel1.Controls.Add(this.filteredViewsCtrl);
            // 
            // filteredLeft.Panel2
            // 
            this.filteredLeft.Panel2.Controls.Add(this.fullLogCtrl);
            this.filteredLeft.Size = new System.Drawing.Size(981, 364);
            this.filteredLeft.SplitterDistance = 558;
            this.filteredLeft.TabIndex = 0;
            // 
            // filteredViewsCtrl
            // 
            this.filteredViewsCtrl.AllowDrop = true;
            this.filteredViewsCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filteredViewsCtrl.Controls.Add(this.tabPage1);
            this.filteredViewsCtrl.Location = new System.Drawing.Point(0, 3);
            this.filteredViewsCtrl.Name = "filteredViewsCtrl";
            this.filteredViewsCtrl.SelectedIndex = 0;
            this.filteredViewsCtrl.Size = new System.Drawing.Size(553, 361);
            this.filteredViewsCtrl.TabIndex = 0;
            this.filteredViewsCtrl.SelectedIndexChanged += new System.EventHandler(this.filteredViews_SelectedIndexChanged);
            this.filteredViewsCtrl.DragDrop += new System.Windows.Forms.DragEventHandler(this.filteredViews_DragDrop);
            this.filteredViewsCtrl.DragEnter += new System.Windows.Forms.DragEventHandler(this.filteredViews_DragEnter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dropHere);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dropHere
            // 
            this.dropHere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropHere.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropHere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dropHere.Location = new System.Drawing.Point(8, 0);
            this.dropHere.Name = "dropHere";
            this.dropHere.Size = new System.Drawing.Size(534, 360);
            this.dropHere.TabIndex = 0;
            this.dropHere.Text = "Drop it Like it\'s Hot!\r\nJust drop a file here, and get to work!\r\n";
            this.dropHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fullLogCtrl
            // 
            this.fullLogCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullLogCtrl.Location = new System.Drawing.Point(3, 3);
            this.fullLogCtrl.Multiline = true;
            this.fullLogCtrl.Name = "fullLogCtrl";
            this.fullLogCtrl.ReadOnly = true;
            this.fullLogCtrl.Size = new System.Drawing.Size(406, 357);
            this.fullLogCtrl.TabIndex = 0;
            // 
            // refresh
            // 
            this.refresh.Enabled = true;
            this.refresh.Interval = 500;
            this.refresh.Tick += new System.EventHandler(this.refresh_Tick);
            // 
            // LogWizard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 526);
            this.Controls.Add(this.toggleTips);
            this.Controls.Add(this.toggleFullLog);
            this.Controls.Add(this.toggleSource);
            this.Controls.Add(this.toggleFilters);
            this.Controls.Add(this.logHistory);
            this.Controls.Add(this.newView);
            this.Controls.Add(this.main);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogWizard";
            this.Text = "Log Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWizard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogNinja_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.filtersCtrl)).EndInit();
            this.main.Panel1.ResumeLayout(false);
            this.main.Panel1.PerformLayout();
            this.main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main)).EndInit();
            this.main.ResumeLayout(false);
            this.sourceUp.Panel1.ResumeLayout(false);
            this.sourceUp.Panel1.PerformLayout();
            this.sourceUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceUp)).EndInit();
            this.sourceUp.ResumeLayout(false);
            this.filteredLeft.Panel1.ResumeLayout(false);
            this.filteredLeft.Panel2.ResumeLayout(false);
            this.filteredLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filteredLeft)).EndInit();
            this.filteredLeft.ResumeLayout(false);
            this.filteredViewsCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox curFilterCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label label4;
        private BrightIdeasSoftware.ObjectListView filtersCtrl;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Button delFilter;
        private System.Windows.Forms.Button addFilter;
        private System.Windows.Forms.SplitContainer main;
        private System.Windows.Forms.SplitContainer sourceUp;
        private System.Windows.Forms.TextBox sourceNameCtrl;
        private System.Windows.Forms.ComboBox sourceTypeCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contextMatch;
        private System.Windows.Forms.ComboBox curContextCtrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newView;
        private System.Windows.Forms.ComboBox logHistory;
        private System.Windows.Forms.SplitContainer filteredLeft;
        private System.Windows.Forms.TextBox friendlyNameCtrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button newFilteredView;
        private System.Windows.Forms.TabControl filteredViewsCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox fullLogCtrl;
        private System.Windows.Forms.Button toggleFilters;
        private System.Windows.Forms.Button toggleSource;
        private System.Windows.Forms.Button toggleFullLog;
        private System.Windows.Forms.TextBox logSyntaxCtrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dropHere;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.Timer refresh;
        private System.Windows.Forms.Button delFilteredView;
        private System.Windows.Forms.Button toggleTips;
        private System.Windows.Forms.Button delContext;
        private System.Windows.Forms.Button addContext;
    }
}

