using System.Windows.Forms;

namespace RedragonBatteryIcon
{
    partial class BatteryInfoDisplay
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

        /*protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Hide();
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChargeLevel = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChargeLevel
            // 
            this.lblChargeLevel.AutoSize = true;
            this.lblChargeLevel.CausesValidation = false;
            this.lblChargeLevel.Font = new System.Drawing.Font("Roboto", 20F);
            this.lblChargeLevel.Location = new System.Drawing.Point(0, 0);
            this.lblChargeLevel.Margin = new System.Windows.Forms.Padding(0);
            this.lblChargeLevel.Name = "lblChargeLevel";
            this.lblChargeLevel.Size = new System.Drawing.Size(80, 35);
            this.lblChargeLevel.TabIndex = 0;
            this.lblChargeLevel.Text = "100%";
            this.lblChargeLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChargeLevel.UseMnemonic = false;
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(24, 45);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.CausesValidation = false;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblConnectionStatus.Location = new System.Drawing.Point(80, 9);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(114, 20);
            this.lblConnectionStatus.TabIndex = 2;
            this.lblConnectionStatus.Text = "(Disconnected)";
            this.lblConnectionStatus.UseMnemonic = false;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.CausesValidation = false;
            this.lblDeviceName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(12, 15);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(104, 21);
            this.lblDeviceName.TabIndex = 3;
            this.lblDeviceName.Text = "Mouse Name";
            this.lblDeviceName.UseMnemonic = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblChargeLevel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblConnectionStatus, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 35);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // BatteryInfoDisplay
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(255, 100);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.picIcon);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatteryInfoDisplay";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblChargeLevel;
        private System.Windows.Forms.PictureBox picIcon;
        private Label lblConnectionStatus;
        private Label lblDeviceName;
        private TableLayoutPanel tableLayoutPanel1;
    }
}