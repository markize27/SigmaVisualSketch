﻿namespace SigmaVisualSketch
{
    partial class OrderCreationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtextBoxForDescription = new System.Windows.Forms.RichTextBox();
            this.textBoxForShortDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desciption";
            // 
            // rtextBoxForDescription
            // 
            this.rtextBoxForDescription.Location = new System.Drawing.Point(12, 64);
            this.rtextBoxForDescription.Name = "rtextBoxForDescription";
            this.rtextBoxForDescription.Size = new System.Drawing.Size(253, 79);
            this.rtextBoxForDescription.TabIndex = 1;
            this.rtextBoxForDescription.Text = "";
            // 
            // textBoxForShortDescription
            // 
            this.textBoxForShortDescription.Location = new System.Drawing.Point(12, 25);
            this.textBoxForShortDescription.Name = "textBoxForShortDescription";
            this.textBoxForShortDescription.Size = new System.Drawing.Size(253, 20);
            this.textBoxForShortDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Short order descripton";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 369);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxForShortDescription);
            this.Controls.Add(this.rtextBoxForDescription);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderCreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtextBoxForDescription;
        private System.Windows.Forms.TextBox textBoxForShortDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}