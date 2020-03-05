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

namespace FilemngFrolov
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string now_path, old_path;
        public int folders_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void go_to_path(string kuda)
        {
            treeView1.Nodes.Clear();
            string[] folders = Directory.GetDirectories(@kuda);
            string[] files = Directory.GetFiles(@kuda);
            folders_count = 0;
            foreach (string folder in folders)
            {
                treeView1.Nodes.Add(folder);
                folders_count++;
            }
            foreach (string file in files)
                treeView1.Nodes.Add(file);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            now_path = "C:\\";
            go_to_path(@now_path);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string z = now_path;
            now_path = old_path;
            go_to_path(@now_path);
            old_path = z;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(@now_path);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Index < folders_count)
            {
                old_path = now_path;
                now_path = @treeView1.SelectedNode.Text.ToString();
                go_to_path(@now_path);
            }
        }
    }
}
