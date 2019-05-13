using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

            textBox1.DragEnter += TextBox1_DragEnter;
            textBox1.DragDrop += TextBox1_DragDrop;
        }

        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                string text = File.ReadAllText(
                    Path.Combine(Environment.CurrentDirectory, file[0]));
                textBox1.Text = text;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void TextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //разрешаем списку стать адресатом буксировки
            textBox1.AllowDrop = true;
        }
    }
}
