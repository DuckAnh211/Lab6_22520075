using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_22520075
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string plaintext = textBox1.Text;
                int shift = int.Parse(textBox4.Text);
                string encryptedText = Encrypt(plaintext, shift);
                textBox2.Text = encryptedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string encryptedText = textBox2.Text;
                int shift = int.Parse(textBox4.Text);
                string decryptedText = Decrypt(encryptedText, shift);
                textBox3.Text = decryptedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private string Encrypt(string plaintext, int shift)
        {
            string ciphertext = string.Empty;

            foreach (char ch in plaintext)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    char encryptedChar = (char)((ch + shift - offset) % 26 + offset);
                    ciphertext += encryptedChar;
                }
                else
                {
                    ciphertext += ch;
                }
            }

            return ciphertext;
        }

        private string Decrypt(string ciphertext, int shift)
        {
            return Encrypt(ciphertext, 26 - shift);
        }

       
    }
}
