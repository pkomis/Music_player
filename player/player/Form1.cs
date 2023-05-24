using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace player
{
    public partial class Form1 : Form
    {
        string[] doc, path;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Mp3 Files|*.mp3|Avi Files|*avi|Wav Files|*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
                doc = open.SafeFileNames;
                path = open.SafeFileNames;
                for (int i = 0; i < doc.Length; i++)
                {
                    listBox2.Items.Add(doc[i]);
                }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.URL = path[listBox2.SelectedIndex];
            }
            catch (IndexOutOfRangeException r)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection list = listBox2.Items;
            Random random = new Random();
            int w = list.Count;
            listBox2.BeginUpdate();
            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                object value = list[u];
                list[u] = list[w];
                list[w] = value;
            }
            listBox2.EndUpdate();   
            listBox2.Invalidate();
        }

        

        
    }
}
