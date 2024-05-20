using System;
using System.Windows.Forms;

namespace practice13_FWF {
    public class TextBoxInput {
        //allows you to input money values only in the textBox
        public static bool InputMoney(TextBox tbx, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                return true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return false;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == ',')) return true;
            string text = tbx.Text;
            switch (e.KeyChar) {
                case ',' when text.Length == 0:
                case ',' when text.Contains(","):
                case '-' when text.Length != 0:
                case '-' when text.Contains("-"):
                    return true;
            }

            int commaIndex = text.IndexOf(',');
            if (commaIndex != -1 && text.Length - commaIndex > 4)
            {
                return true;
            }

            return false;
        }

        
        //buttonLess money input
        public static bool ButtonLessInputMoney(TextBox tbx, KeyPressEventArgs e,  Action action) {
            if (e.KeyChar != (int)Keys.Enter) return InputMoney(tbx, e);
            action();
            return false;
        }
    }
}