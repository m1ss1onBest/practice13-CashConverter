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

        public enum SelectedMoney
        {
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = @"CashConverter";
            label1.Text = @"↔";
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
            outputUah.Text = $@"{Bank.Uah :F4}";
            outputUsd.Text = $@"{Bank.Dollar :F4}";
            outputEuro.Text = $@"{Bank.Euro :F4}";
            label8.Text = $@"Total: {Corruption :F4} UAH";
        }

        //F*CK YEAH I'M FINALLY FINISHING THAT SHIT
        private void commitButton_Click(object sender, EventArgs e)
        {
            switch (Currency)
            {
                case SelectedMoney.Dollar:
                    if (rbtBuyMode.Checked)
                    {
                        float transaction = float.Parse(inputUah.Text);
                        inputOther.Text = $@"{Math.Round(transaction / PriceBuy.Usd, 4)}";

                        Bank.Dollar -= transaction / PriceBuy.Usd;
                        if (Bank.Dollar < 0)
                        {
                            MessageBox.Show(@"NOT ENOUGH MONEY");
                            Bank.Dollar += transaction / PriceBuy.Usd;
                            return;
                        }

                        Bank.Uah += transaction;
                        Corruption += Math.Abs(transaction / PriceBuy.Usd * PriceSell.Usd - transaction);
                    }
                    else
                    {
                        float transaction = float.Parse(inputOther.Text);
                        inputUah.Text = $@"{Math.Round(transaction * PriceSell.Usd, 4)}";
                        Bank.Dollar += transaction;

                        Bank.Uah -= transaction * PriceSell.Usd;
                        if (Bank.Uah < 0)
                        {
                            MessageBox.Show(@"NOT ENOUGH MONEY");
                            Bank.Uah += transaction * PriceSell.Usd;
                            return;
                        }

                        Corruption += transaction * PriceBuy.Usd - transaction * PriceSell.Usd;
                    }

                    break;

                case SelectedMoney.Euro:
                    if (rbtBuyMode.Checked)
                    {
                        float transaction = float.Parse(inputUah.Text);
                        inputOther.Text = $@"{Math.Round(transaction * PriceBuy.Eur, 4)}";

                        Bank.Euro -= transaction / PriceBuy.Eur;
                        if (Bank.Euro < 0)
                        {
                            MessageBox.Show(@"NOT ENOUGH MONEY");
                            Bank.Euro += transaction / PriceBuy.Eur;
                            return;
                        }

                        Bank.Uah += transaction;
                        Corruption += Math.Abs(transaction / PriceBuy.Eur * PriceSell.Eur - transaction);
                    }
                    else
                    {
                        float transaction = float.Parse(inputOther.Text);
                        inputUah.Text = $@"{Math.Round(transaction * PriceSell.Eur)}";
                        Bank.Euro += transaction;

                        Bank.Uah -= transaction * PriceSell.Eur;
                        if (Bank.Uah < 0)
                        {
                            MessageBox.Show(@"NOT ENOUGH MONEY");
                            Bank.Uah += transaction * PriceSell.Eur;
                            return;
                        }

                        Corruption += transaction * PriceBuy.Eur - transaction * PriceSell.Eur;
                    }

                    break;
            }

            UpdateBank();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($@"{Corruption} UAH was taken from the vault", @"WARNING");
        }

        private void inputUah_KeyPressed(object sender, KeyPressEventArgs e) =>
            e.Handled = TextBoxInput.InputMoney(inputUah, e);

        private void inputOther_KeyPressed(object sender, KeyPressEventArgs e) =>
        e.Handled = TextBoxInput.InputMoney(inputOther, e);
        
    }
}