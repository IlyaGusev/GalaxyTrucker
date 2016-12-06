namespace GalaxyTruckerClient
{
    partial class LobbyDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playersLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(63, 31);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(130, 13);
            this.playersLabel.TabIndex = 0;
            this.playersLabel.Text = "Current number of players:";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(199, 31);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(13, 13);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "1";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(97, 57);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 34);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel?";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LobbyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 117);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.playersLabel);
            this.Name = "LobbyDialog";
            this.Text = "Searching for players...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LobbyDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}