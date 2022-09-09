using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace RichTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap myBitmap = new Bitmap(RichTextBox.Properties.Resources._1);
            Clipboard.SetDataObject(myBitmap);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            richTextBox1.Text = "Meоw";
            richTextBox1.Paste(format);
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap FormScreenShot = new Bitmap(this.Width, this.Height);
            Graphics G = Graphics.FromImage(FormScreenShot);
            G.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
            Clipboard.SetImage(FormScreenShot);
            Clipboard.GetImage();
            var date = DateTime.Now.ToString();
            date = date.Replace(':', ' ');
            FormScreenShot.Save($@"C:\1\{date}.jpeg", ImageFormat.Jpeg);
        }
    }
}
