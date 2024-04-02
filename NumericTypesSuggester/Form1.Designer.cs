
namespace NumericTypesSuggester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinTextBox = new System.Windows.Forms.TextBox();
            this.MaxTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkOnlyIntegral = new System.Windows.Forms.CheckBox();
            this.checkIsPrecise = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Suggested = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min Value:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max Value:";
            // 
            // MinTextBox
            // 
            this.MinTextBox.Location = new System.Drawing.Point(149, 72);
            this.MinTextBox.Name = "MinTextBox";
            this.MinTextBox.Size = new System.Drawing.Size(514, 27);
            this.MinTextBox.TabIndex = 2;
            this.MinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnFormElementInteraction);
            // 
            // MaxTextBox
            // 
            this.MaxTextBox.Location = new System.Drawing.Point(149, 113);
            this.MaxTextBox.Name = "MaxTextBox";
            this.MaxTextBox.Size = new System.Drawing.Size(514, 27);
            this.MaxTextBox.TabIndex = 3;
            this.MaxTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnFormElementInteraction);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Integral Only?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Must Be Precise?";
            // 
            // checkOnlyIntegral
            // 
            this.checkOnlyIntegral.AutoSize = true;
            this.checkOnlyIntegral.Location = new System.Drawing.Point(149, 158);
            this.checkOnlyIntegral.Name = "checkOnlyIntegral";
            this.checkOnlyIntegral.Size = new System.Drawing.Size(18, 17);
            this.checkOnlyIntegral.TabIndex = 6;
            this.checkOnlyIntegral.UseVisualStyleBackColor = true;
            this.checkOnlyIntegral.CheckedChanged += new System.EventHandler(this.OnFormElementInteraction);
            // 
            // checkIsPrecise
            // 
            this.checkIsPrecise.AutoSize = true;
            this.checkIsPrecise.Location = new System.Drawing.Point(149, 184);
            this.checkIsPrecise.Name = "checkIsPrecise";
            this.checkIsPrecise.Size = new System.Drawing.Size(18, 17);
            this.checkIsPrecise.TabIndex = 7;
            this.checkIsPrecise.UseVisualStyleBackColor = true;
            this.checkIsPrecise.CheckedChanged += new System.EventHandler(this.OnFormElementInteraction);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(24, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Suggested type:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-43, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 9;
            // 
            // Suggested
            // 
            this.Suggested.AutoSize = true;
            this.Suggested.Location = new System.Drawing.Point(150, 224);
            this.Suggested.Name = "Suggested";
            this.Suggested.Size = new System.Drawing.Size(0, 20);
            this.Suggested.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(145, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "not enough data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 278);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Suggested);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkIsPrecise);
            this.Controls.Add(this.checkOnlyIntegral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaxTextBox);
            this.Controls.Add(this.MinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MinTextBox;
        private System.Windows.Forms.TextBox MaxTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkOnlyIntegral;
        private System.Windows.Forms.CheckBox checkIsPrecise;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Suggested;
        private System.Windows.Forms.Label label7;
    }
}

