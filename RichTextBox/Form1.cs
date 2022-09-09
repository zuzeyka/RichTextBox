using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.Win32;


namespace RichTextBox
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        string[] paths;
        public Form1()
        {
            InitializeComponent();
            Bitmap myBitmap = new Bitmap(RichTextBox.Properties.Resources._1);
            Clipboard.SetDataObject(myBitmap);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            richTextBox1.Text = "Meоw";
            richTextBox1.Paste(format);
            this.WindowState = FormWindowState.Maximized;
            paths = Directory.GetFiles(@"C:\Users\stepa\OneDrive\Изображения\MainBg");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Bitmap FormScreenShot = new Bitmap(this.Width, this.Height);
            Graphics G = Graphics.FromImage(FormScreenShot);
            G.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
            Clipboard.SetImage(FormScreenShot);
            var date = DateTime.Now.ToString();
            date = date.Replace(':', ' ');
            FormScreenShot.Save($@"C:\1\{date}.jpeg", ImageFormat.Jpeg);
            SetWallpaper(paths[random.Next(0, paths.Length - 1)], 0, 0);
        }

        private void SetWallpaper(string WallpaperLocation, int WallpaperStyle, int TileWallpaper)
        {
            // Sets the actual wallpaper
            SystemParametersInfo(20, 0, WallpaperLocation, 0x01 | 0x02);
            // Set the wallpaper style to streched (can be changed to tile, center, maintain aspect ratio, etc.
            RegistryKey rkWallPaper = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            // Sets the wallpaper style
            rkWallPaper.SetValue("WallpaperStyle", WallpaperStyle);
            // Whether or not this wallpaper will be displayed as a tile
            rkWallPaper.SetValue("TileWallpaper", TileWallpaper);
            rkWallPaper.Close();
        }
    }
}
