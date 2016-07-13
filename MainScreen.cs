using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace Battleship
{
    class MainScreen : IScreens
    {
        private int _textureId;
        private bool _isActive;
        private readonly GameController _window;
        //
        private MenuItem _newGameItem;
        private MenuItem _helpItem;
        private MenuItem _exitItem;
        //
        public MainScreen(GameController window)
        {
            _window = window;
            On();
            _newGameItem = new MenuItem(200, 40, new Font(FontFamily.GenericSerif, 28), new Font(FontFamily.GenericSerif, 29, FontStyle.Underline),
                Brushes.White, Brushes.White, _window);
            _helpItem = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 28), new Font(FontFamily.GenericSerif, 29, FontStyle.Underline),
                Brushes.White, Brushes.White, _window);
            _exitItem = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 28), new Font(FontFamily.GenericSerif, 29, FontStyle.Underline),
                Brushes.White, Brushes.White, _window);
        }

        public MenuItem NewGameItem
        {
            get { return _newGameItem; }
            set { _newGameItem = value; }
        }

        public MenuItem ExitItem
        {
            get { return _exitItem; }
            set { _exitItem = value; }
        }

        public MenuItem HelpItem
        {
            get { return _helpItem; }
            set { _helpItem = value; }
        }

        private void MouseButtonsDown(object sender, MouseButtonEventArgs e)
        {
            _newGameItem.ButtonDown(sender, e);
            _helpItem.ButtonDown(sender, e);
            _exitItem.ButtonDown(sender, e);
        }

        private void KeyboardDown(object sender, KeyboardKeyEventArgs e)
        {
            //if (e.Key == Key.Escape)
            //Exit();
        }

        public void Off()
        {
            _isActive = false;
            OffControl();
        }

        public void On()
        {
            _isActive = true;
            OnControl();
            OnResize();
        }

        public void OffControl()
        {
            _window.KeyDown -= KeyboardDown;
            _window.Mouse.ButtonDown -= MouseButtonsDown;
        }

        public void OnControl()
        {
            _window.KeyDown += KeyboardDown;
            _window.Mouse.ButtonDown += MouseButtonsDown;
        }


        public void OnLoad()
        {
            _textureId = TextureLoader.Load("textures/background.jpg");
        }

        public void OnResize()
        {

            if (_isActive)
            {
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-900.0, 900.0, -600.0, 600.0, 0.0, 4.0);
               // Предотвращает деление на нуль
                if (_window.Height == 0)
                    _window.Height = 1;
                GL.Viewport(0, 0, _window.Width, _window.Height);
                var fAspect = _window.Width / (float)_window.Height;
                Matrix4 orthoProjection = Matrix4.CreateOrthographicOffCenter(0, _window.Width, _window.Height, 0, -1, 1);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.LoadMatrix(ref orthoProjection);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
            }
        }

        public void OnUpdateFrame()
        {

        }

        public void OnRenderFrame()
        {
            if (_isActive)
            {
                GL.Color3(Color.AliceBlue);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, _textureId);
#pragma warning disable 618
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-900.0f, -600.0f);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(900.0f, -600.0f);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(900.0f, 600.0f);
                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-900.0f, 600.0f);

                GL.End();

                _newGameItem.Draw("Новая игра", _window.Width, _window.Height, new PointF(350, 200));
                _helpItem.Draw("Справка", _window.Width, _window.Height, new PointF(370, 270));
                _exitItem.Draw("Выход", _window.Width, _window.Height, new PointF(380, 340));
                //
            }


        }
    }
}
