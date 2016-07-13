using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;


namespace Battleship
{
        class Game
    {
        [STAThread]
        public static void Main()
        {
            using (var Game = new GameController())
            {
                Game.Run();
            }
        }
    }
}
