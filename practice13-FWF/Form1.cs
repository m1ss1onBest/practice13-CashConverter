﻿// ReSharper disable RedundantUsingDirective
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
using System.Windows.Forms.VisualStyles;

namespace practice13_FWF {
    public partial class Form1 : Form {
        //region variables
        public static bool CanTransact = false;
        private static class Bank {
            public static float Dollar { set; get; }
            public static float Euro { set; get; }
            public static float Uah { set; get; }
        }

        private static class PriceBuy {
            public static float Usd { set; get; }
            public static float Eur { set; get; }
        }

        private static class PriceSell {
            public static float Usd { set; get; }
            public static float Eur { set; get; } 
        }

        public enum SelectedMoney { None, Dollar, Euro, }
        private SelectedMoney Currency { set; get; } = SelectedMoney.None;
        private static float Margin { set; get; }
        //endregion variables
        
        //region microsoft shit
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = @"CashConverter";
            label1.Text = @"↔";
        }
        //endregion microsoft shit

        //region crutches💀
        private void tbxSellPrice_KeyPressed(object sender, KeyPressEventArgs e) {
            e.Handled = TextBoxInput.ButtonLessInputMoney(tbxSellPrice, e, () => {
                if (e.KeyChar != (int)Keys.Enter || tbxSellPrice.Text.Length == 0) return;
                if (Currency == SelectedMoney.None) {
                    MessageBox.Show(@"CHOOSE CORRECT CURRENCY", @"YOU CAN'T",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var price = float.Parse(tbxSellPrice.Text);
                if (!(price > 0)) return;
                switch (Currency) {
                    case SelectedMoney.Dollar:
                        PriceSell.Usd = price;
                        break;
                    case SelectedMoney.Euro:
                        PriceSell.Eur = price;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }

                tbxSellPrice.Enabled = false;
            }) | Currency == SelectedMoney.None;
        }
        
        private void tbxBuyPrice_KeyPressed(object sender, KeyPressEventArgs e) {
            e.Handled = TextBoxInput.ButtonLessInputMoney(tbxBuyPrice, e, () => {
                if (e.KeyChar != (int)Keys.Enter || tbxBuyPrice.Text.Length == 0) return;
                if (Currency == SelectedMoney.None) {
                    MessageBox.Show(@"CHOOSE CORRECT CURRENCY", @"YOU CAN'T",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var price = float.Parse(tbxBuyPrice.Text);
                if (!(price > 0)) return;
                switch (Currency) {
                    case SelectedMoney.Dollar:
                        PriceBuy.Usd = price;
                        break;
                    case SelectedMoney.Euro:
                        PriceBuy.Eur = price;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                tbxBuyPrice.Enabled = false;
            }) | Currency == SelectedMoney.None;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (comboBox1.Text) {
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

        private void rbtBuyMode_CheckedChanged(object sender, EventArgs e) {
            label1.Text = @"←";
            TransactionPreview();
        }

        private void rbtSellMode_CheckedChanged(object sender, EventArgs e) {
            label1.Text = @"→";
            TransactionPreview();
        }

        //bank input
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () => {
                if (e.KeyChar != (int)Keys.Enter || textBox1.Text.Length == 0) return;
                Bank.Uah = float.Parse(textBox1.Text);
                textBox1.Enabled = false;
                UpdateBank();
            });
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () => {
                if (e.KeyChar != (int)Keys.Enter || textBox2.Text.Length == 0) return;
                Bank.Dollar = float.Parse(textBox2.Text);
                textBox2.Enabled = false;
                UpdateBank();
            });
        }
        
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = TextBoxInput.ButtonLessInputMoney(textBox3, e, () => {
                if (e.KeyChar != (int)Keys.Enter || textBox3.Text.Length == 0) return;
                Bank.Euro = float.Parse(textBox3.Text);
                textBox3.Enabled = false;
                UpdateBank();
            });
        }

        private void UpdateBank() {
            outputUah.Text = $@"{Bank.Uah :F4}";
            outputUsd.Text = $@"{Bank.Dollar :F4}";
            outputEuro.Text = $@"{Bank.Euro :F4}";
            label8.Text = $@"Margin: {Margin :F4} UAH";
        }
        
        private static void Error() {
            MessageBox.Show(@"ERROR", @"NOT ENOUGH MONEY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void commitButton_Click(object sender, EventArgs e) {
            incasationMessage.Text = "";
            if (!float.TryParse(inputOther.Text, out var transactionInOther) | Currency == SelectedMoney.None) return;
            var i = rbtBuyMode.Checked ? 1 : -1;
            float marg = 0;
            float transactionInUah;

            switch (Currency)
            {
                case SelectedMoney.Dollar:
                    transactionInUah = transactionInOther * (i == 1 ? PriceBuy.Usd : PriceSell.Usd);
                    marg = transactionInOther * (PriceBuy.Usd - PriceSell.Usd);
                    if (Bank.Dollar - transactionInOther * i < 0 || Bank.Uah + transactionInUah * i < 0) {
                        Error();
                        return;
                    }

                    Bank.Dollar -= transactionInOther * i;
                    Bank.Uah += transactionInUah * i;
                    Margin += marg;
                    UpdateBank();
                    break;

                case SelectedMoney.Euro:
                    transactionInUah = transactionInOther * (i == 1 ? PriceBuy.Eur : PriceSell.Eur);
                    marg = transactionInOther * (PriceBuy.Eur - PriceSell.Usd);
                    if (Bank.Dollar - transactionInOther * i < 0 || Bank.Uah + transactionInUah * i < 0) {
                        Error();
                        return;
                    }

                    Bank.Dollar -= transactionInOther * i;
                    Bank.Uah += transactionInUah * i;
                    Margin += marg;
                    UpdateBank();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int incUah = (int)(Bank.Uah / 1000);
            int incUsd = (int)(Bank.Dollar / 100);
            int incEur = (int)(Bank.Euro / 100);

            Bank.Uah -= incUah * 1000;
            Bank.Euro -= incEur * 100;
            Bank.Dollar -= incUsd * 100;

            incasationMessage.Text = String.Format(
                $"{incUah * 1000} UAH was taken \n" +
                $"{incUsd * 100} USD was taken \n" +
                $"{incEur * 100} EUR was taken \n" +
                $"{Margin} UAH was taken as margin");
            Margin = 0;
            UpdateBank();
        }
        private void inputUah_KeyPressed(object sender, KeyPressEventArgs e) => e.Handled = true;
        private void inputOther_KeyPressed(object sender, KeyPressEventArgs e) =>
            e.Handled = TextBoxInput.InputMoney(inputOther, e) | Currency == SelectedMoney.None;
        private void inputOther_TextChanged(object sender, EventArgs e) => TransactionPreview();

            private void TransactionPreview() { 
            if (!float.TryParse(inputOther.Text, out var val)) return;
            switch (Currency) {
                case SelectedMoney.Dollar when rbtBuyMode.Checked:
                    val *= PriceBuy.Usd; 
                    break;
                case SelectedMoney.Dollar:
                    val *= PriceSell.Usd;
                    break;
                case SelectedMoney.Euro when rbtBuyMode.Checked:
                    val *= PriceBuy.Eur;
                    break;
                case SelectedMoney.Euro:
                    val *= PriceSell.Eur;
                    break;
                case SelectedMoney.None:
                default:
                    return;
            }
            inputUah.Text = $@"{val}"; 
        } 
    }
    //endregion crutches💀
}