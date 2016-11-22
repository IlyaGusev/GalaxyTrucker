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
            ((System.ComponentModel.ISupportInitialize)(this.queuePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Highlight;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 23);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGetSegment
            // 
            this.btnGetSegment.Location = new System.Drawing.Point(992, 23);
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
            this.queuePictureBox.Location = new System.Drawing.Point(1013, 52);
            this.queuePictureBox.Name = "queuePictureBox";
            this.queuePictureBox.Size = new System.Drawing.Size(50, 50);
            this.queuePictureBox.TabIndex = 2;
            this.queuePictureBox.TabStop = false;
            // 
            // storePictureBox1
            // 
            this.storePictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.storePictureBox1.InitialImage = null;
            this.storePictureBox1.Location = new System.Drawing.Point(22, 439);
            this.storePictureBox1.Name = "storePictureBox1";
            this.storePictureBox1.Size = new System.Drawing.Size(50, 50);
            this.storePictureBox1.TabIndex = 3;
            this.storePictureBox1.TabStop = false;
            // 
            // storePictureBox2
            // 
            this.storePictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.storePictureBox2.InitialImage = null;
            this.storePictureBox2.Location = new System.Drawing.Point(78, 439);
            this.storePictureBox2.Name = "storePictureBox2";
            this.storePictureBox2.Size = new System.Drawing.Size(50, 50);
            this.storePictureBox2.TabIndex = 4;
            this.storePictureBox2.TabStop = false;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 538);
            this.Controls.Add(this.storePictureBox2);
            this.Controls.Add(this.storePictureBox1);
            this.Controls.Add(this.queuePictureBox);
            this.Controls.Add(this.btnGetSegment);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "Galaxy Trucker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.queuePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storePictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGetSegment;
        private System.Windows.Forms.PictureBox queuePictureBox;
        private System.Windows.Forms.PictureBox storePictureBox1;
        private System.Windows.Forms.PictureBox storePictureBox2;
    }
}

