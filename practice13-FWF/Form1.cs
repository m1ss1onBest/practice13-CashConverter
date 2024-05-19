using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice13_FWF
// pls help
// nobody asked me if I wanna use Win forms
// :sob:
{
    public partial class Form1 : Form
    {
        private static class Bank
        {
            public static float Dollar { set; get; } = 0;
            public static float Euro { set; get; } = 0;
            public static float Uah { set; get; } = 0;
        }

        private static class Current
        {
            public static float Dollar { set; get; } = 0;
            public static float Euro { set; get; } = 0;
            public static float Uah { set; get; } = 0;
        }
        
        private static class PriceBuy
        {
            public static float Usd { set; get; }
            public static float Eur { set; get; }
        }
        private static class PriceSell
        {
            public static float Usd { set; get; }
            public static float Eur { set; get; }
        }

        public enum SelectedMoney {
            None,
            Dollar,
            Euro,
        }

        public enum TransactionMode
        {
            None,
            Sell,
            Buy
        }

        public static float Corruption = 0;
        private SelectedMoney Currency { set; get; } = SelectedMoney.None;
        private TransactionMode TransactionType { set; get; } = TransactionMode.None;

        public Form1()
        {
            InitializeComponent();
            label1.Text = @"↔";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = @"CashConverter";
        }

        //KeyPressLoad
        //SellPrice
        private void tbxSellPrice_KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxInput.ButtonLessInputMoney(tbxSellPrice, e, () =>
            {
                if (e.KeyChar != (int)Keys.Enter || tbxSellPrice.Text.Length == 0) return;
                if (Currency == SelectedMoney.None)
                {
                    MessageBox.Show(@"CHOOSE CORRECT CURRENCY", @"YOU CAN'T",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var price = float.Parse(tbxSellPrice.Text);
                if (!(price > 0)) return;
                switch (Currency)
                {
                    case SelectedMoney.Dollar:
                        PriceSell.Usd = price;
                        break;
                    case SelectedMoney.Euro:
                        PriceSell.Eur = price;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }

                tbxSellPrice.Enabled = false;
            });
        }

        //BuyPrice
        private void tbxBuyPrice_KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxInput.ButtonLessInputMoney(tbxBuyPrice, e, () =>
            {
                if (e.KeyChar != (int)Keys.Enter || tbxBuyPrice.Text.Length == 0) return;
                if (Currency == SelectedMoney.None)
                {
                    MessageBox.Show(@"CHOOSE CORRECT CURRENCY", @"YOU CAN'T",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var price = float.Parse(tbxBuyPrice.Text);
                if (!(price > 0)) return;
                switch (Currency)
                {
                    case SelectedMoney.Dollar:
                        PriceBuy.Usd = price;
                        break;
                    case SelectedMoney.Euro:
                        PriceBuy.Eur = price;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                tbxBuyPrice.Enabled = false;
            });
        }
        
        //LogicLoad
        //Combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "$ USD":
                    tbxSellPrice.Text = $@"{PriceSell.Usd}";
                    tbxBuyPrice.Text = $@"{PriceBuy.Usd}";
                    Currency = SelectedMoney.Dollar;
                    
                    tbxSellPrice.Enabled = PriceSell.Usd == 0;
                    tbxBuyPrice.Enabled = PriceBuy.Usd == 0;
                    break;

                case "€ EUR":
                    tbxSellPrice.Text = $@"{PriceSell.Eur}";
                    tbxBuyPrice.Text = $@"{PriceBuy.Eur}";
                    Currency = SelectedMoney.Euro;
                    
                    tbxSellPrice.Enabled = PriceSell.Eur == 0;
                    tbxBuyPrice.Enabled = PriceBuy.Eur == 0;
                    break;
            }
        }

        //Transaction mode selection
        private void rbtBuyMode_CheckedChanged(object sender, EventArgs e)
        {
            TransactionType = TransactionMode.Buy;
            label1.Text = @"←";

        }
        private void rbtSellMode_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = @"→";
            TransactionType = TransactionMode.Sell;
        }

        //bank input
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () =>
            {
                if (e.KeyChar != (int)Keys.Enter || textBox1.Text.Length == 0) return;
                Bank.Uah = float.Parse(textBox1.Text);
                textBox1.Enabled = false;
                UpdateBank();
            });
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () =>
            {
                if (e.KeyChar != (int)Keys.Enter || textBox2.Text.Length == 0) return;
                Bank.Dollar = float.Parse(textBox2.Text);
                textBox2.Enabled = false;
                UpdateBank();
            });
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () =>
            {
                if (e.KeyChar != (int)Keys.Enter || textBox3.Text.Length == 0) return;
                Bank.Euro = float.Parse(textBox3.Text);
                textBox3.Enabled = false;
                UpdateBank();
            });
        }

        private void UpdateBank()
        {
            outputUah.Text = $@"{Bank.Uah}";
            outputUsd.Text = $@"{Bank.Dollar}";
            outputEuro.Text = $@"{Bank.Euro}";
            label8.Text = $@"Total: {Corruption}";
        }

        //F*CK YEAH I'M FINALLY FINISHING THAT SHIT
        private void commitButton_Click(object sender, EventArgs e)
        {
            float coefficient;
            switch (Currency)
            {
                case SelectedMoney.Dollar:
                    coefficient = PriceBuy.Usd / PriceSell.Usd - 1;
                    if (rbtBuyMode.Checked)
                    {
                        float transaction = float.Parse(inputUah.Text);
                        Bank.Dollar -= transaction / PriceBuy.Usd;
                        Bank.Uah += transaction;
                        Corruption += coefficient * transaction;
                    }
                    else
                    {
                        float transaction = float.Parse(inputOther.Text);
                        Bank.Dollar += transaction * PriceBuy.Usd;
                        Bank.Uah -= transaction;
                        Corruption += coefficient * transaction * PriceBuy.Usd;
                    }
                    break;
                
                case SelectedMoney.Euro:
                    coefficient = PriceBuy.Eur / PriceSell.Eur - 1;
                    if (rbtBuyMode.Checked)
                    {
                        float transaction = float.Parse(inputUah.Text);
                        Bank.Euro -= transaction / PriceBuy.Usd;
                        Bank.Uah += transaction;
                        Corruption += coefficient * transaction;
                    }
                    else
                    {
                        float transaction = float.Parse(inputOther.Text);
                        Bank.Euro += transaction * PriceBuy.Eur;
                        Bank.Uah -= transaction;
                        Corruption += coefficient * transaction * PriceBuy.Eur;
                    }
                    break;
            }
            UpdateBank();
        }
    }
}