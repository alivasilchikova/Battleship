using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;

namespace Battleship
{
    public class CursorLoader
    {
        public static MouseCursor Load(string filename)
        {
            using (var bitmap = new Bitmap(filename))
            {
                var data = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                  ImageLockMode.ReadOnly,
                                  PixelFormat.Format32bppPArgb);

                var cursor = new MouseCursor(
                    2, 21, data.Width, data.Height, data.Scan0);
                return cursor;
            }
        }
    }
}
