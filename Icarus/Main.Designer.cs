namespace Icarus
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnTargetProc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstRenderFlags = new Icarus.Components.RenderFlagListbox();
            this.btnToggleEnable = new System.Windows.Forms.Button();
            this.btnResetFlags = new System.Windows.Forms.Button();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabProcs = new System.Windows.Forms.TabPage();
            this.btnSelectProc = new System.Windows.Forms.Button();
            this.btnRefreshProc = new System.Windows.Forms.Button();
            this.grpProcesses = new System.Windows.Forms.GroupBox();
            this.lstProcs = new System.Windows.Forms.ListBox();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyBindControl = new Icarus.Components.KeyBindControl();
            this.btnPatchExe = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.tabProcs.SuspendLayout();
            this.grpProcesses.SuspendLayout();
            this.tabKeys.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTargetProc
            // 
            this.btnTargetProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTargetProc.Location = new System.Drawing.Point(12, 18);
            this.btnTargetProc.Name = "btnTargetProc";
            this.btnTargetProc.Size = new System.Drawing.Size(126, 39);
            this.btnTargetProc.TabIndex = 0;
            this.btnTargetProc.Text = "Select Process";
            this.btnTargetProc.UseVisualStyleBackColor = true;
            this.btnTargetProc.Click += new System.EventHandler(this.BtnTargetProc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstRenderFlags);
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 226);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Render Flags";
            // 
            // lstRenderFlags
            // 
            this.lstRenderFlags.CameraManager = null;
            this.lstRenderFlags.CheckOnClick = true;
            this.lstRenderFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRenderFlags.FormattingEnabled = true;
            this.lstRenderFlags.Items.AddRange(new object[] {
            Icarus.Logic.Game.Enums.Enables.AABoxes,
            Icarus.Logic.Game.Enums.Enables.Anisotropic,
            Icarus.Logic.Game.Enums.Enables.Chunks,
            Icarus.Logic.Game.Enums.Enables.Collision,
            Icarus.Logic.Game.Enums.Enables.CrappyBatches,
            Icarus.Logic.Game.Enums.Enables.Culling,
            Icarus.Logic.Game.Enums.Enables.DebugBSP,
            Icarus.Logic.Game.Enums.Enables.DetailDoodads,
            Icarus.Logic.Game.Enums.Enables.Doodads,
            Icarus.Logic.Game.Enums.Enables.Lod,
            Icarus.Logic.Game.Enums.Enables.LowDetail,
            Icarus.Logic.Game.Enums.Enables.MapObjBSP,
            Icarus.Logic.Game.Enums.Enables.MapObjLight,
            Icarus.Logic.Game.Enums.Enables.MapObjs,
            Icarus.Logic.Game.Enums.Enables.MapObjTex,
            Icarus.Logic.Game.Enums.Enables.NoAnimation,
            Icarus.Logic.Game.Enums.Enables.NoFullAlpha,
            Icarus.Logic.Game.Enums.Enables.Particulates,
            Icarus.Logic.Game.Enums.Enables.PixelShaders,
            Icarus.Logic.Game.Enums.Enables.Portals,
            Icarus.Logic.Game.Enums.Enables.PortalVis,
            Icarus.Logic.Game.Enums.Enables.Shadow,
            Icarus.Logic.Game.Enums.Enables.ShowNormals,
            Icarus.Logic.Game.Enums.Enables.ShowQuery,
            Icarus.Logic.Game.Enums.Enables.ShowTris,
            Icarus.Logic.Game.Enums.Enables.Sky,
            Icarus.Logic.Game.Enums.Enables.Specular,
            Icarus.Logic.Game.Enums.Enables.Texture,
            Icarus.Logic.Game.Enums.Enables.Trilinear,
            Icarus.Logic.Game.Enums.Enables.VertexLight,
            Icarus.Logic.Game.Enums.Enables.Water,
            Icarus.Logic.Game.Enums.Enables.ZoneBounds});
            this.lstRenderFlags.Location = new System.Drawing.Point(3, 16);
            this.lstRenderFlags.Name = "lstRenderFlags";
            this.lstRenderFlags.Size = new System.Drawing.Size(209, 207);
            this.lstRenderFlags.Sorted = true;
            this.lstRenderFlags.TabIndex = 0;
            // 
            // btnToggleEnable
            // 
            this.btnToggleEnable.Location = new System.Drawing.Point(12, 63);
            this.btnToggleEnable.Name = "btnToggleEnable";
            this.btnToggleEnable.Size = new System.Drawing.Size(126, 25);
            this.btnToggleEnable.TabIndex = 6;
            this.btnToggleEnable.Text = "Enable Free Move";
            this.btnToggleEnable.UseVisualStyleBackColor = true;
            this.btnToggleEnable.Click += new System.EventHandler(this.BtnToggleEnable_Click);
            // 
            // btnResetFlags
            // 
            this.btnResetFlags.Location = new System.Drawing.Point(12, 94);
            this.btnResetFlags.Name = "btnResetFlags";
            this.btnResetFlags.Size = new System.Drawing.Size(126, 23);
            this.btnResetFlags.TabIndex = 4;
            this.btnResetFlags.Text = "Reset Render Flags";
            this.btnResetFlags.UseVisualStyleBackColor = true;
            this.btnResetFlags.Click += new System.EventHandler(this.BtnResetFlags_Click);
            // 
            // tabContent
            // 
            this.tabContent.Controls.Add(this.tabMain);
            this.tabContent.Controls.Add(this.tabProcs);
            this.tabContent.Controls.Add(this.tabKeys);
            this.tabContent.Location = new System.Drawing.Point(140, 12);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(235, 337);
            this.tabContent.TabIndex = 4;
            this.tabContent.SelectedIndexChanged += new System.EventHandler(this.TabContent_SelectedIndexChanged);
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.SystemColors.Window;
            this.tabMain.Controls.Add(this.label4);
            this.tabMain.Controls.Add(this.label3);
            this.tabMain.Controls.Add(this.tbSpeed);
            this.tabMain.Controls.Add(this.label2);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.lblStatus);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(227, 311);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(188, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "1000%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(69, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "100%";
            // 
            // tbSpeed
            // 
            this.tbSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.tbSpeed.Location = new System.Drawing.Point(70, 29);
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(148, 45);
            this.tbSpeed.TabIndex = 8;
            this.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSpeed.Value = 1;
            this.tbSpeed.Scroll += new System.EventHandler(this.TbSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed (%):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(67, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(106, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "No process attached";
            // 
            // tabProcs
            // 
            this.tabProcs.BackColor = System.Drawing.SystemColors.Window;
            this.tabProcs.Controls.Add(this.btnSelectProc);
            this.tabProcs.Controls.Add(this.btnRefreshProc);
            this.tabProcs.Controls.Add(this.grpProcesses);
            this.tabProcs.Location = new System.Drawing.Point(4, 22);
            this.tabProcs.Name = "tabProcs";
            this.tabProcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcs.Size = new System.Drawing.Size(227, 311);
            this.tabProcs.TabIndex = 1;
            this.tabProcs.Text = "Processes";
            // 
            // btnSelectProc
            // 
            this.btnSelectProc.Location = new System.Drawing.Point(146, 282);
            this.btnSelectProc.Name = "btnSelectProc";
            this.btnSelectProc.Size = new System.Drawing.Size(75, 23);
            this.btnSelectProc.TabIndex = 8;
            this.btnSelectProc.Text = "Select";
            this.btnSelectProc.UseVisualStyleBackColor = true;
            this.btnSelectProc.Click += new System.EventHandler(this.LstProcs_DoubleClick);
            // 
            // btnRefreshProc
            // 
            this.btnRefreshProc.Location = new System.Drawing.Point(65, 282);
            this.btnRefreshProc.Name = "btnRefreshProc";
            this.btnRefreshProc.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshProc.TabIndex = 7;
            this.btnRefreshProc.Text = "Refresh";
            this.btnRefreshProc.UseVisualStyleBackColor = true;
            this.btnRefreshProc.Click += new System.EventHandler(this.BtnRefreshProc_Click);
            // 
            // grpProcesses
            // 
            this.grpProcesses.Controls.Add(this.lstProcs);
            this.grpProcesses.Location = new System.Drawing.Point(6, 6);
            this.grpProcesses.Name = "grpProcesses";
            this.grpProcesses.Size = new System.Drawing.Size(215, 273);
            this.grpProcesses.TabIndex = 6;
            this.grpProcesses.TabStop = false;
            this.grpProcesses.Text = "Processes";
            // 
            // lstProcs
            // 
            this.lstProcs.DisplayMember = "Details";
            this.lstProcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcs.FormattingEnabled = true;
            this.lstProcs.Location = new System.Drawing.Point(3, 16);
            this.lstProcs.Name = "lstProcs";
            this.lstProcs.Size = new System.Drawing.Size(209, 254);
            this.lstProcs.TabIndex = 3;
            this.lstProcs.ValueMember = "ProcessID";
            this.lstProcs.DoubleClick += new System.EventHandler(this.LstProcs_DoubleClick);
            // 
            // tabKeys
            // 
            this.tabKeys.Controls.Add(this.groupBox1);
            this.tabKeys.Location = new System.Drawing.Point(4, 22);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Size = new System.Drawing.Size(227, 311);
            this.tabKeys.TabIndex = 2;
            this.tabKeys.Text = "Key Bindings";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keyBindControl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Bindings";
            // 
            // keyBindControl
            // 
            this.keyBindControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyBindControl.Location = new System.Drawing.Point(3, 16);
            this.keyBindControl.Name = "keyBindControl";
            this.keyBindControl.Size = new System.Drawing.Size(215, 286);
            this.keyBindControl.TabIndex = 0;
            // 
            // btnPatchExe
            // 
            this.btnPatchExe.Location = new System.Drawing.Point(12, 129);
            this.btnPatchExe.Name = "btnPatchExe";
            this.btnPatchExe.Size = new System.Drawing.Size(126, 23);
            this.btnPatchExe.TabIndex = 8;
            this.btnPatchExe.Text = "Patch Executable";
            this.btnPatchExe.UseVisualStyleBackColor = true;
            this.btnPatchExe.Click += new System.EventHandler(this.BtnPatchExe_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 361);
            this.Controls.Add(this.btnPatchExe);
            this.Controls.Add(this.tabContent);
            this.Controls.Add(this.btnToggleEnable);
            this.Controls.Add(this.btnResetFlags);
            this.Controls.Add(this.btnTargetProc);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Icarus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.tabContent.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.tabProcs.ResumeLayout(false);
            this.grpProcesses.ResumeLayout(false);
            this.tabKeys.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTargetProc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnToggleEnable;
        private System.Windows.Forms.Button btnResetFlags;
        private Components.RenderFlagListbox lstRenderFlags;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabProcs;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.ListBox lstProcs;
        private System.Windows.Forms.GroupBox grpProcesses;
        private System.Windows.Forms.Button btnRefreshProc;
        private System.Windows.Forms.Button btnSelectProc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbSpeed;
        private Components.KeyBindControl keyBindControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPatchExe;
    }
}

