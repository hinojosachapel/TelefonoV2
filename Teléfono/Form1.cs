// Cómo hacer una llamada telefónica en Windows Mobile con C#
// Cómo abrir el menú Inicio en Windows Mobile con C#

#region License

/* Copyright (c) 2011 Rubén Hinojosa Chapel
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
 * sell copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software. 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
 */

#endregion

#region Contact

/*
 * Rubén Hinojosa Chapel
 * Web: www.hinojosachapel.com
 */

#endregion

#region Using directives

using System;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Telephony;

#endregion

namespace RH.MobilePhone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtBoxPhoneNumber.Text.Length > 0)
            {
                txtBoxPhoneNumber.Text =
                    txtBoxPhoneNumber.Text.Substring(0, txtBoxPhoneNumber.Text.Length - 1);
                txtBoxPhoneNumber.Select(txtBoxPhoneNumber.TextLength, 1);
                txtBoxPhoneNumber.Focus();
            }
        }

        private void AddDigit(char digit)
        {
            if (txtBoxPhoneNumber.TextLength < txtBoxPhoneNumber.MaxLength)
            {
                txtBoxPhoneNumber.Text += digit;
                txtBoxPhoneNumber.Select(txtBoxPhoneNumber.TextLength, 1);
                txtBoxPhoneNumber.Focus();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AddDigit('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddDigit('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddDigit('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddDigit('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddDigit('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddDigit('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddDigit('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddDigit('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddDigit('9');
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AddDigit('0');
        }

        /// <summary>
        /// Ejecuta una llamada a un número de teléfono
        /// </summary>
        private void btnCall_Click(object sender, EventArgs e)
        {
            if (txtBoxPhoneNumber.Text == String.Empty)
            {
                MessageBox.Show("No existe ningún número de teléfono al cual llamar",
                    "Información...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            Phone p = new Phone();
            p.Talk(txtBoxPhoneNumber.Text);
        }

        #region Abrir menú Inicio

        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "keybd_event", SetLastError = true)]
        internal static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int VK_LWIN = 0x5B;
        const int KEYEVENTF_KEYUP = 0x2;
        const int KEYEVENTF_KEYDOWN = 0x0;
        
        /// <summary>
        /// Abre el menú Inicio
        /// </summary>
        private void btnInicio_Click(object sender, EventArgs e)
        {
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);

            //Código alternativo
            //keybd_event((byte)Keys.LWin, 0, KEYEVENTF_KEYDOWN, 0);
            //keybd_event((byte)Keys.LWin, 0, KEYEVENTF_KEYUP, 0);
        }

        #endregion

    }
}