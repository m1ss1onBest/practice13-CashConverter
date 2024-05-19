using System.Windows.Forms;

namespace practice13_FWF
{
    partial class Form1
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
            this.commitButton = new System.Windows.Forms.Button();
            this.tbxBuyPrice = new System.Windows.Forms.TextBox();
            this.rbtBuyMode = new System.Windows.Forms.RadioButton();
            this.rbtSellMode = new System.Windows.Forms.RadioButton();
            this.tbxSellPrice = new System.Windows.Forms.TextBox();
            this.inputUah = new System.Windows.Forms.TextBox();
            this.inputOther = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputUah = new System.Windows.Forms.Label();
            this.outputUsd = new System.Windows.Forms.Label();
            this.outputEuro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commitButton
            // 
            this.commitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commitButton.Location = new System.Drawing.Point(11, 469);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(234, 38);
            this.commitButton.TabIndex = 0;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // tbxBuyPrice
            // 
            this.tbxBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxBuyPrice.Location = new System.Drawing.Point(11, 56);
            this.tbxBuyPrice.Name = "tbxBuyPrice";
            this.tbxBuyPrice.Size = new System.Drawing.Size(234, 38);
            this.tbxBuyPrice.TabIndex = 1;
            this.tbxBuyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBuyPrice_KeyPressed);
            // 
            // rbtBuyMode
            // 
            this.rbtBuyMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtBuyMode.Location = new System.Drawing.Point(12, 12);
            this.rbtBuyMode.Name = "rbtBuyMode";
            this.rbtBuyMode.Size = new System.Drawing.Size(233, 38);
            this.rbtBuyMode.TabIndex = 2;
            this.rbtBuyMode.TabStop = true;
            this.rbtBuyMode.Text = "Buy";
            this.rbtBuyMode.UseVisualStyleBackColor = true;
            this.rbtBuyMode.CheckedChanged += new System.EventHandler(this.rbtBuyMode_CheckedChanged);
            // 
            // rbtSellMode
            // 
            this.rbtSellMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtSellMode.Location = new System.Drawing.Point(477, 12);
            this.rbtSellMode.Name = "rbtSellMode";
            this.rbtSellMode.Size = new System.Drawing.Size(233, 38);
            this.rbtSellMode.TabIndex = 3;
            this.rbtSellMode.TabStop = true;
            this.rbtSellMode.Text = "Sell";
            this.rbtSellMode.UseVisualStyleBackColor = true;
            this.rbtSellMode.CheckedChanged += new System.EventHandler(this.rbtSellMode_CheckedChanged);
            // 
            // tbxSellPrice
            // 
            this.tbxSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxSellPrice.Location = new System.Drawing.Point(476, 56);
            this.tbxSellPrice.Name = "tbxSellPrice";
            this.tbxSellPrice.Size = new System.Drawing.Size(234, 38);
            this.tbxSellPrice.TabIndex = 4;
            this.tbxSellPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSellPrice_KeyPressed);
            // 
            // inputUah
            // 
            this.inputUah.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputUah.Location = new System.Drawing.Point(476, 145);
            this.inputUah.Name = "inputUah";
            this.inputUah.Size = new System.Drawing.Size(234, 38);
            this.inputUah.TabIndex = 5;
            // 
            // inputOther
            // 
            this.inputOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputOther.Location = new System.Drawing.Point(11, 145);
            this.inputOther.Name = "inputOther";
            this.inputOther.Size = new System.Drawing.Size(234, 38);
            this.inputOther.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "$ USD", "€ EUR" });
            this.comboBox1.Location = new System.Drawing.Point(11, 100);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 39);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(11, 337);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 38);
            this.textBox1.TabIndex = 11;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(11, 381);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(234, 38);
            this.textBox2.TabIndex = 12;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(12, 425);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(234, 38);
            this.textBox3.TabIndex = 13;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(251, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 68);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // outputUah
            // 
            this.outputUah.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputUah.Location = new System.Drawing.Point(389, 336);
            this.outputUah.Name = "outputUah";
            this.outputUah.Size = new System.Drawing.Size(219, 38);
            this.outputUah.TabIndex = 15;
            this.outputUah.Text = "0,0000";
            this.outputUah.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outputUsd
            // 
            this.outputUsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputUsd.Location = new System.Drawing.Point(389, 380);
            this.outputUsd.Name = "outputUsd";
            this.outputUsd.Size = new System.Drawing.Size(219, 38);
            this.outputUsd.TabIndex = 16;
            this.outputUsd.Text = "0,0000";
            this.outputUsd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outputEuro
            // 
            this.outputEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputEuro.Location = new System.Drawing.Point(389, 425);
            this.outputEuro.Name = "outputEuro";
            this.outputEuro.Size = new System.Drawing.Size(219, 38);
            this.outputEuro.TabIndex = 17;
            this.outputEuro.Text = "0,0000";
            this.outputEuro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(614, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 38);
            this.label2.TabIndex = 18;
            this.label2.Text = "UAH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(614, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 38);
            this.label3.TabIndex = 19;
            this.label3.Text = "USD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(614, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 38);
            this.label4.TabIndex = 20;
            this.label4.Text = "EUR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(251, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 38);
            this.label5.TabIndex = 23;
            this.label5.Text = "EUR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(251, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 38);
            this.label6.TabIndex = 22;
            this.label6.Text = "USD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(251, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 38);
            this.label7.TabIndex = 21;
            this.label7.Text = "UAH";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(378, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(332, 38);
            this.label8.TabIndex = 24;
            this.label8.Text = "Total: 0,0000 UAH";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(476, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 38);
            this.label14.TabIndex = 30;
            this.label14.Text = "UAH";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 519);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputEuro);
            this.Controls.Add(this.outputUsd);
            this.Controls.Add(this.outputUah);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.inputOther);
            this.Controls.Add(this.inputUah);
            this.Controls.Add(this.tbxSellPrice);
            this.Controls.Add(this.rbtSellMode);
            this.Controls.Add(this.rbtBuyMode);
            this.Controls.Add(this.tbxBuyPrice);
            this.Controls.Add(this.commitButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label14;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label outputUsd;
        private System.Windows.Forms.Label outputEuro;

        private System.Windows.Forms.Label outputUah;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.TextBox inputOther;
        private System.Windows.Forms.TextBox inputUah;

        private System.Windows.Forms.RadioButton rbtBuyMode;
        private System.Windows.Forms.RadioButton rbtSellMode;
        private System.Windows.Forms.TextBox tbxSellPrice;

        private System.Windows.Forms.TextBox tbxBuyPrice;

        private System.Windows.Forms.Button commitButton;

        #endregion
    }
}