using System.Collections.Generic;

namespace GalaxyTruckerClient
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetSegment = new System.Windows.Forms.Button();
            this.queuePictureBox = new System.Windows.Forms.PictureBox();
            this.storePictureBox1 = new System.Windows.Forms.PictureBox();
            this.storePictureBox2 = new System.Windows.Forms.PictureBox();
            this.openPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statGroupBox = new System.Windows.Forms.GroupBox();
            this.energyLabel = new System.Windows.Forms.Label();
            this.crewLabel = new System.Windows.Forms.Label();
            this.weaponLabel = new System.Windows.Forms.Label();
            this.engineLabel = new System.Windows.Forms.Label();
            this.bufferLabel = new System.Windows.Forms.Label();
            this.starshipLabel = new System.Windows.Forms.Label();
            this.storageLabel = new System.Windows.Forms.Label();
            this.constructorPanel = new System.Windows.Forms.Panel();
            this.cardsButton3 = new System.Windows.Forms.Button();
            this.cardsButton2 = new System.Windows.Forms.Button();
            this.cardsButton1 = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.configureButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.queuePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox2)).BeginInit();
            this.statGroupBox.SuspendLayout();
            this.constructorPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGetSegment
            // 
            this.btnGetSegment.Location = new System.Drawing.Point(418, 408);
            this.btnGetSegment.Name = "btnGetSegment";
            this.btnGetSegment.Size = new System.Drawing.Size(92, 23);
            this.btnGetSegment.TabIndex = 1;
            this.btnGetSegment.Text = "Get Segment";
            this.btnGetSegment.UseVisualStyleBackColor = true;
            this.btnGetSegment.Click += new System.EventHandler(this.btnGetSegment_Click);
            // 
            // queuePictureBox
            // 
            this.queuePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.queuePictureBox.InitialImage = null;
            this.queuePictureBox.Location = new System.Drawing.Point(440, 437);
            this.queuePictureBox.Name = "queuePictureBox";
            this.queuePictureBox.Size = new System.Drawing.Size(50, 50);
            this.queuePictureBox.TabIndex = 2;
            this.queuePictureBox.TabStop = false;
            // 
            // storePictureBox1
            // 
            this.storePictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.storePictureBox1.InitialImage = null;
            this.storePictureBox1.Location = new System.Drawing.Point(39, 424);
            this.storePictureBox1.Name = "storePictureBox1";
            this.storePictureBox1.Size = new System.Drawing.Size(50, 50);
            this.storePictureBox1.TabIndex = 3;
            this.storePictureBox1.TabStop = false;
            // 
            // storePictureBox2
            // 
            this.storePictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.storePictureBox2.InitialImage = null;
            this.storePictureBox2.Location = new System.Drawing.Point(95, 424);
            this.storePictureBox2.Name = "storePictureBox2";
            this.storePictureBox2.Size = new System.Drawing.Size(50, 50);
            this.storePictureBox2.TabIndex = 4;
            this.storePictureBox2.TabStop = false;
            // 
            // openPanel
            // 
            this.openPanel.AllowDrop = true;
            this.openPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.openPanel.ColumnCount = 12;
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.openPanel.Location = new System.Drawing.Point(575, 25);
            this.openPanel.Name = "openPanel";
            this.openPanel.RowCount = 12;
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.openPanel.Size = new System.Drawing.Size(625, 625);
            this.openPanel.TabIndex = 5;
            // 
            // statGroupBox
            // 
            this.statGroupBox.Controls.Add(this.energyLabel);
            this.statGroupBox.Controls.Add(this.crewLabel);
            this.statGroupBox.Controls.Add(this.weaponLabel);
            this.statGroupBox.Controls.Add(this.engineLabel);
            this.statGroupBox.Location = new System.Drawing.Point(185, 408);
            this.statGroupBox.Name = "statGroupBox";
            this.statGroupBox.Size = new System.Drawing.Size(200, 79);
            this.statGroupBox.TabIndex = 6;
            this.statGroupBox.TabStop = false;
            this.statGroupBox.Text = "Starship Stats";
            // 
            // energyLabel
            // 
            this.energyLabel.AutoSize = true;
            this.energyLabel.Location = new System.Drawing.Point(7, 59);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(52, 13);
            this.energyLabel.TabIndex = 3;
            this.energyLabel.Text = "Enegry: 0";
            // 
            // crewLabel
            // 
            this.crewLabel.AutoSize = true;
            this.crewLabel.Location = new System.Drawing.Point(7, 46);
            this.crewLabel.Name = "crewLabel";
            this.crewLabel.Size = new System.Drawing.Size(79, 13);
            this.crewLabel.TabIndex = 2;
            this.crewLabel.Text = "Human crew: 0";
            // 
            // weaponLabel
            // 
            this.weaponLabel.AutoSize = true;
            this.weaponLabel.Location = new System.Drawing.Point(7, 33);
            this.weaponLabel.Name = "weaponLabel";
            this.weaponLabel.Size = new System.Drawing.Size(92, 13);
            this.weaponLabel.TabIndex = 1;
            this.weaponLabel.Text = "Weapon power: 0";
            // 
            // engineLabel
            // 
            this.engineLabel.AutoSize = true;
            this.engineLabel.Location = new System.Drawing.Point(7, 20);
            this.engineLabel.Name = "engineLabel";
            this.engineLabel.Size = new System.Drawing.Size(84, 13);
            this.engineLabel.TabIndex = 0;
            this.engineLabel.Text = "Engine power: 0";
            // 
            // bufferLabel
            // 
            this.bufferLabel.AutoSize = true;
            this.bufferLabel.Location = new System.Drawing.Point(45, 408);
            this.bufferLabel.Name = "bufferLabel";
            this.bufferLabel.Size = new System.Drawing.Size(64, 13);
            this.bufferLabel.TabIndex = 7;
            this.bufferLabel.Text = "Local Buffer";
            // 
            // starshipLabel
            // 
            this.starshipLabel.AutoSize = true;
            this.starshipLabel.Location = new System.Drawing.Point(45, 9);
            this.starshipLabel.Name = "starshipLabel";
            this.starshipLabel.Size = new System.Drawing.Size(45, 13);
            this.starshipLabel.TabIndex = 8;
            this.starshipLabel.Text = "Starship";
            // 
            // storageLabel
            // 
            this.storageLabel.AutoSize = true;
            this.storageLabel.Location = new System.Drawing.Point(584, 9);
            this.storageLabel.Name = "storageLabel";
            this.storageLabel.Size = new System.Drawing.Size(71, 13);
            this.storageLabel.TabIndex = 9;
            this.storageLabel.Text = "Open storage";
            // 
            // constructorPanel
            // 
            this.constructorPanel.Controls.Add(this.cardsButton3);
            this.constructorPanel.Controls.Add(this.cardsButton2);
            this.constructorPanel.Controls.Add(this.cardsButton1);
            this.constructorPanel.Controls.Add(this.tableLayoutPanel1);
            this.constructorPanel.Controls.Add(this.storageLabel);
            this.constructorPanel.Controls.Add(this.bufferLabel);
            this.constructorPanel.Controls.Add(this.queuePictureBox);
            this.constructorPanel.Controls.Add(this.openPanel);
            this.constructorPanel.Controls.Add(this.statGroupBox);
            this.constructorPanel.Controls.Add(this.starshipLabel);
            this.constructorPanel.Controls.Add(this.btnGetSegment);
            this.constructorPanel.Controls.Add(this.storePictureBox2);
            this.constructorPanel.Controls.Add(this.storePictureBox1);
            this.constructorPanel.Location = new System.Drawing.Point(12, 12);
            this.constructorPanel.Name = "constructorPanel";
            this.constructorPanel.Size = new System.Drawing.Size(1240, 777);
            this.constructorPanel.TabIndex = 10;
            this.constructorPanel.Visible = false;
            // 
            // cardsButton3
            // 
            this.cardsButton3.Location = new System.Drawing.Point(370, 520);
            this.cardsButton3.Name = "cardsButton3";
            this.cardsButton3.Size = new System.Drawing.Size(140, 200);
            this.cardsButton3.TabIndex = 12;
            this.cardsButton3.Text = "Cards 3";
            this.cardsButton3.UseVisualStyleBackColor = true;
            // 
            // cardsButton2
            // 
            this.cardsButton2.Location = new System.Drawing.Point(205, 520);
            this.cardsButton2.Name = "cardsButton2";
            this.cardsButton2.Size = new System.Drawing.Size(140, 200);
            this.cardsButton2.TabIndex = 11;
            this.cardsButton2.Text = "Cards 2";
            this.cardsButton2.UseVisualStyleBackColor = true;
            // 
            // cardsButton1
            // 
            this.cardsButton1.Location = new System.Drawing.Point(39, 520);
            this.cardsButton1.Name = "cardsButton1";
            this.cardsButton1.Size = new System.Drawing.Size(140, 200);
            this.cardsButton1.TabIndex = 10;
            this.cardsButton1.Text = "Cards 1";
            this.cardsButton1.UseVisualStyleBackColor = true;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.exitButton);
            this.menuPanel.Controls.Add(this.configureButton);
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Location = new System.Drawing.Point(400, 200);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(480, 340);
            this.menuPanel.TabIndex = 10;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(65, 217);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(350, 50);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // configureButton
            // 
            this.configureButton.Location = new System.Drawing.Point(65, 133);
            this.configureButton.Name = "configureButton";
            this.configureButton.Size = new System.Drawing.Size(350, 50);
            this.configureButton.TabIndex = 1;
            this.configureButton.Text = "Configure";
            this.configureButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(65, 50);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(350, 50);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 801);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.constructorPanel);
            this.Name = "MainWindow";
            this.Text = "Galaxy Trucker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.queuePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox2)).EndInit();
            this.statGroupBox.ResumeLayout(false);
            this.statGroupBox.PerformLayout();
            this.constructorPanel.ResumeLayout(false);
            this.constructorPanel.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGetSegment;
        private System.Windows.Forms.PictureBox queuePictureBox;
        private System.Windows.Forms.PictureBox storePictureBox1;
        private System.Windows.Forms.PictureBox storePictureBox2;
        private System.Windows.Forms.TableLayoutPanel openPanel;
        private System.Windows.Forms.GroupBox statGroupBox;
        private System.Windows.Forms.Label weaponLabel;
        private System.Windows.Forms.Label engineLabel;
        private System.Windows.Forms.Label energyLabel;
        private System.Windows.Forms.Label crewLabel;
        private System.Windows.Forms.Label bufferLabel;
        private System.Windows.Forms.Label starshipLabel;
        private System.Windows.Forms.Label storageLabel;
        private System.Windows.Forms.Panel constructorPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button configureButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cardsButton3;
        private System.Windows.Forms.Button cardsButton2;
        private System.Windows.Forms.Button cardsButton1;
    }
}

