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
        //Field field = new Field();

        //public Game() : base(900, 600) { }

        //#region OnLoad

        ///// <summary>
        ///// Setup OpenGL and load resources here.
        ///// </summary>
        ///// <param name="e">Not used.</param>
        //protected override void OnLoad(EventArgs e)
        //{
        //    field.LoadTexture();
        //}

        //#endregion

        //#region OnUnload

        //protected override void OnUnload(EventArgs e)
        //{
        //    field.UnloadTexture();
        //}

        //#endregion

        //#region OnResize

        ///// <summary>
        ///// Respond to resize events here.
        ///// </summary>
        ///// <param name="e">Contains information on the new GameWindow size.</param>
        ///// <remarks>There is no need to call the base implementation.</remarks>
        //protected override void OnResize(EventArgs e)
        //{
        //    GL.Viewport(0, 0, Width, Height);

        //    GL.MatrixMode(MatrixMode.Projection);
        //    GL.LoadIdentity();
        //    GL.Ortho(-900.0, 900.0, -600.0, 600.0, 0.0, 4.0);
        //}

        //#endregion

        //#region OnUpdateFrame

        ///// <summary>
        ///// Add your game logic here.
        ///// </summary>
        ///// <param name="e">Contains timing information.</param>
        ///// <remarks>There is no need to call the base implementation.</remarks>
        //protected override void OnUpdateFrame(FrameEventArgs e)
        //{
        //    var keyboard = OpenTK.Input.Keyboard.GetState();
        //    if (keyboard[OpenTK.Input.Key.Escape])
        //        this.Exit();
        //}

        //#endregion

        //#region OnRenderFrame

        ///// <summary>
        ///// Add your game rendering code here.
        ///// </summary>
        ///// <param name="e">Contains timing information.</param>
        ///// <remarks>There is no need to call the base implementation.</remarks>
        //protected override void OnRenderFrame(FrameEventArgs e)
        //{
        //    GL.Clear(ClearBufferMask.ColorBufferBit);

        //    GL.MatrixMode(MatrixMode.Modelview);
        //    GL.LoadIdentity();
        //    field.SetSizesTexture();
        //    field.DrawField();

        //    SwapBuffers();
        //}

        //#endregion

        //#region public static void Main()

        ///// <summary>
        ///// Entry point of this example.
        ///// </summary>
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
