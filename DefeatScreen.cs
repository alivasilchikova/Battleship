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
    class DefeatScreen:IScreens
    {
        private bool _isActive;
        private readonly GameController _window;
        private int _textureWin;
        private int texture;


        //
        private MenuItem _closeButton;
        private MenuItem _yesButton;
        private MenuItem _noButton;

        public DefeatScreen(GameController window)
        {
            _window = window;
            _closeButton = new MenuItem(160, 40, new Font(FontFamily.GenericSerif, 24), new Font(FontFamily.GenericSerif, 25, FontStyle.Bold),
                Brushes.Red, Brushes.Red, _window);
            _yesButton = new MenuItem(75, 37, new Font(FontFamily.GenericSerif, 24), new Font(FontFamily.GenericSerif, 25, FontStyle.Bold),
                Brushes.Black, Brushes.Black, _window);
            _noButton = new MenuItem(75, 37, new Font(FontFamily.GenericSerif, 24), new Font(FontFamily.GenericSerif, 25, FontStyle.Bold),
                Brushes.Black, Brushes.Black, _window);
            Off();
        }

        public DefeatScreen()
        {

        }
        public MenuItem CloseButton
        {
            get { return _closeButton; }
            set { _closeButton = value; }
        }

        public MenuItem YesButton
        {
            get { return _yesButton; }
            set { _yesButton = value; }
        }

        public MenuItem NoButton
        {
            get { return _noButton; }
            set { _noButton = value; }
        }

        public int TextureHelp
        {
            get { return _textureWin; }
            set { _textureWin = value; }
        }


        public void MouseButtonsDown(object sender, MouseButtonEventArgs e)
        {
            _closeButton.ButtonDown(sender, e);
            _yesButton.ButtonDown(sender, e);
            _noButton.ButtonDown(sender, e);

        }

        public void OnLoad()
        {
            _textureWin = TextureLoader.Load("textures/defeat.jpg");
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
                GL.BindTexture(TextureTarget.Texture2D, _textureWin);
                GL.PushMatrix();
                //GL.Color3(Color.Gray);
                GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-600, -400);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(600, -400);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(600, 400);
                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-600, 400);
                GL.End();
                GL.Color3(Color.Transparent);
                _closeButton.Draw("✖", _window.Width, _window.Height, new PointF(700, 110));
                _yesButton.TurnOnBackground(Color.Peru, Color.Chocolate);
                _yesButton.Draw("Да", _window.Width, _window.Height, new PointF(250, 420));
                _noButton.TurnOnBackground(Color.Peru, Color.Chocolate);
                _noButton.Draw("Нет", _window.Width, _window.Height, new PointF(550, 420));
                GL.PopMatrix();

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
