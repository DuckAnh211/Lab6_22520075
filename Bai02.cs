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
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string plaintext = textBox1.Text;
                string key = textBox4.Text;
                string encryptedText = Encrypt(plaintext, key);
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
                string key = textBox4.Text;
                string decryptedText = Decrypt(encryptedText, key);
                textBox3.Text = decryptedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private string Encrypt(string plaintext, string key)
        {
            string ciphertext = string.Empty;
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char ch in plaintext)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    int keyShift = key[keyIndex % key.Length] - 'A';
                    char encryptedChar = (char)(((ch + keyShift - offset) % 26) + offset);
                    ciphertext += encryptedChar;
                    keyIndex++;
                }
                else
                {
                    ciphertext += ch;
                }
            }

            return ciphertext;
        }

        // Hàm giải mã
        private string Decrypt(string ciphertext, string key)
        {
            string plaintext = string.Empty;
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char ch in ciphertext)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    int keyShift = key[keyIndex % key.Length] - 'A';
                    char decryptedChar = (char)(((ch - keyShift - offset + 26) % 26) + offset);
                    plaintext += decryptedChar;
                    keyIndex++;
                }
                else
                {
                    plaintext += ch;
                }
            }

            return plaintext;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
