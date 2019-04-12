using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Utility
{
    public class QrCodeHelper
    {
        public static void CreateQrCode(string qrContent, string logoPicture, string targetPicture)
        {
            Bitmap bmp = CreateQrCode(qrContent, logoPicture);

            string dir = System.IO.Path.GetDirectoryName(targetPicture);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            bmp.Save(targetPicture);
        }

        public static Bitmap CreateQrCode(string qrContent, string logoPicture)
        {
            ThoughtWorks.QRCode.Codec.QRCodeEncoder encoder = new ThoughtWorks.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeScale = 5;
            encoder.QRCodeVersion = 6;
            Bitmap bmp = encoder.Encode(qrContent, System.Text.Encoding.UTF8);

            Graphics g = Graphics.FromImage(bmp);
            if (!string.IsNullOrEmpty(logoPicture) && System.IO.File.Exists(logoPicture))
            {
                Image logo = Image.FromFile(logoPicture);
                g.DrawImage(logo, (bmp.Width - logo.Width) / 2, (bmp.Height - logo.Height) / 2, logo.Width, logo.Height);
            }
            return bmp;
        }
    }
}
