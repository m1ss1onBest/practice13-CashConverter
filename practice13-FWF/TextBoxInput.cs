using System;
using System.Windows.Forms;

namespace practice13_FWF {
    public class TextBoxInput {
        //allows you to input money values only in the textBox
        public static bool InputMoney(TextBox tbx, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                return false;
            }

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)) return true;
            switch (e.KeyChar) {
                case ',' when tbx.Text.Length == 0:
                case ',' when tbx.Text.Contains(","):
                case '-' when tbx.Text.Length != 0:
                case '-' when tbx.Text.Contains("-"):
                    return true;
                default:
                    return false;
            }
        }
        
        //buttonLess money input
        public static bool ButtonLessInputMoney(TextBox tbx, KeyPressEventArgs e,  Action action) {
            if (e.KeyChar != (int)Keys.Enter) return InputMoney(tbx, e);
            action();
            return false;
            
            
            
            
        }
    }
}