using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
namespace Battleship
{
        public class HelpScreen : IScreens
        {
            private bool _isActive;
            private readonly GameController _window;
            private int _textureHelp;
            private int texture;


        //
        private MenuItem _closeButton;

            public HelpScreen(GameController window)
            {
                _window = window;
                _closeButton = new MenuItem(160, 40, new Font(FontFamily.GenericSerif, 24), new Font(FontFamily.GenericSerif, 25, FontStyle.Bold),
                    Brushes.Red, Brushes.Red, _window);
                Off();
            }

            public MenuItem CloseButton
            {
                get { return _closeButton; }
                set { _closeButton = value; }
            }

            public int TextureHelp
            {
                get { return _textureHelp; }
                set { _textureHelp = value; }
            }


        public void MouseButtonsDown(object sender, MouseButtonEventArgs e)
            {
                _closeButton.ButtonDown(sender, e);
            }
            public void OnLoad()
            {
                _textureHelp = TextureLoader.Load("textures/sea.png");
                 texture = TextureLoader.Load("textures/background.jpg");

            }

            public void OnResize()
            {
                if (_isActive)
                {

                }
            }


        public void OnUpdateFrame()
            {

            }

            public void OnRenderFrame()
            {
                if (_isActive)
                {
                GL.Clear(ClearBufferMask.ColorBufferBit);

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, texture);

                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-900.0f, -600.0f);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(900.0f, -600.0f);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(900.0f, 600.0f);
                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-900.0f, 600.0f);

                GL.End();
                GL.BindTexture(TextureTarget.Texture2D, _textureHelp);
                    GL.PushMatrix();
                //GL.Color3(Color.Gray);
                    GL.Begin(BeginMode.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-600, -400);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(600, -400);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(600, 400);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-600, 400);
                    GL.End();
                    _closeButton.Draw("✖", _window.Width, _window.Height, new PointF(700, 110));
                    GL.PopMatrix();
                GL.Color3(Color.Transparent);
                    //
                }
            }

            public void Off()
            {
                _isActive = false;
                _window.Mouse.ButtonDown -= MouseButtonsDown;
            }

            public void On()
            {
                _isActive = true;
                _window.Mouse.ButtonDown += MouseButtonsDown;
            }
    }
}
