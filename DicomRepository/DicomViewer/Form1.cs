using Dicom;
using Dicom.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicomViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = new DicomImage(@"C:\XYL\SGP\DICOM\dicom pic\0000005820\MULTI.416.dcm");
            var frameCount = image.NumberOfFrames;
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < frameCount; i++)
                {
                    pictureBox1.Image = image.RenderImage(i).AsBitmap();
                    Invoke(new Action<PictureBox>((p) => { p.Refresh(); }), pictureBox1);
                    Thread.Sleep(1000);
                }
            });
        }



    }
}
