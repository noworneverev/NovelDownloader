using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string Site = textBox1.Text;
            string ParseSite = null;
            string NovelName = textBox4.Text;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = path + @"\" + NovelName + ".txt";
            string ExportText = null;
            System.IO.StreamWriter objWriter = new System.IO.StreamWriter(filename);
           
            for (int i = Int32.Parse(textBox3.Text); i <= Int32.Parse(textBox2.Text); i++)
            {
                ParseSite = Site + i;
                HtmlDocument doc = new HtmlWeb().Load(ParseSite);
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table/tr/td[@class='t_f']"))
                {
                    ExportText = table.InnerText;
                    objWriter.Write(ExportText);

                }
            }
            objWriter.Close();
        }
    }
}
