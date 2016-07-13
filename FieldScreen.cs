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
using System.Windows.Forms;


namespace Battleship
{
    class FieldScreen 
    {
        Bitmap bitmap = new Bitmap("textures/background.jpg");
        Bitmap field = new Bitmap("textures/field.jpg");
        int texture;
        int textureField;
        private bool _isActive;
        private readonly GameController _window;
        private MenuItem _fourDeck;
        private MenuItem _threeDeck;
        private MenuItem _twoDeck;
        private MenuItem _oneDeck;
        private MenuItem _clearNavyPlayer;
        private GameEngine A;
        

        public FieldScreen(GameController window)
        {
            
            _window = window;
            A = new GameEngine(_window);
            _window.KeyDown += A.SpecialKeys;
            _window.KeyDown += A.Rotate;
            _window.KeyDown += A.Keyboard;
            
            
            _window.MouseDown += MouseButtonsDown;
            _fourDeck = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 14), new Font(FontFamily.GenericSerif, 14, FontStyle.Bold),
                Brushes.White, Brushes.Goldenrod, _window);
            _fourDeck.OnClick += A.SelectFourDeck;
            
            _threeDeck = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 14), new Font(FontFamily.GenericSerif, 14, FontStyle.Bold),
                Brushes.White, Brushes.Goldenrod, _window);
            _threeDeck.OnClick += A.SelectThreeDeck;
            _twoDeck = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 14), new Font(FontFamily.GenericSerif, 14, FontStyle.Bold),
                Brushes.White, Brushes.Goldenrod, _window);
            _twoDeck.OnClick += A.SelectTwoDeck;
            _oneDeck = new MenuItem(175, 40, new Font(FontFamily.GenericSerif, 14), new Font(FontFamily.GenericSerif, 14, FontStyle.Bold),
                Brushes.White, Brushes.Goldenrod, _window);
            _oneDeck.OnClick += A.SelectOneDeck;

            _clearNavyPlayer = new MenuItem(210, 40, new Font(FontFamily.GenericSerif, 20), new Font(FontFamily.GenericSerif, 21, FontStyle.Bold),
    Brushes.White, Brushes.Goldenrod, _window);
            _clearNavyPlayer.OnClick += A.Player.ClearFlot;
        }

        public void MouseButtonsDown(object sender, MouseButtonEventArgs e)
        {
            _fourDeck.ButtonDown(sender, e);
            _threeDeck.ButtonDown(sender, e);
            _twoDeck.ButtonDown(sender, e);
            _oneDeck.ButtonDown(sender, e);
            _clearNavyPlayer.ButtonDown(sender, e);
        }

        public MenuItem FourDeck
        {
            get { return _fourDeck; }
            set { _fourDeck = value; }
        }

        public MenuItem ThreeDeck
        {
            get { return _threeDeck; }
            set { _threeDeck = value; }
        }

        public MenuItem TwoDeck
        {
            get { return _twoDeck; }
            set { _twoDeck = value; }
        }

        public MenuItem OneDeck
        {
            get { return _oneDeck; }
            set { _oneDeck = value; }
        }


        #region OnLoad

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        public void OnLoad()
        {
            texture = TextureLoader.Load("textures/background.jpg");
            textureField = TextureLoader.Load("textures/field.jpg");
        }

        #endregion

        #region OnUnload

        public void OnUnload()
        {
            GL.DeleteTextures(1, ref texture);
            GL.DeleteTextures(1, ref textureField);
        }

        #endregion

        #region OnResize

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        public void OnResize()
        {
            //GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-900.0, 900.0, -600.0, 600.0, 0.0, 4.0);
        }

        #endregion

        #region OnUpdateFrame

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        public void OnUpdateFrame()
        {
            //var keyboard = OpenTK.Input.Keyboard.GetState();
            //if (keyboard[OpenTK.Input.Key.Escape])
            //    this.Exit();
        }

        #endregion

        #region OnRenderFrame

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
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

                GL.BindTexture(TextureTarget.Texture2D, textureField);

                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-900.0f, -400.0f);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(900.0f, -400.0f);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(900.0f, 400.0f);
                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-900.0f, 400.0f);

                GL.End();
                _fourDeck.Draw("4-x палубный", _window.Width, _window.Height, new PointF(100, 50 ));
                _threeDeck.Draw("3-x палубный", _window.Width, _window.Height, new PointF(300, 50));
                _twoDeck.Draw("2-x палубный", _window.Width, _window.Height, new PointF(500, 50));
                _oneDeck.Draw("1-о палубный", _window.Width, _window.Height, new PointF(700, 50));
                _clearNavyPlayer.Draw("Очистить флот", _window.Width, _window.Height, new PointF(100, 525));

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Black);
                GL.LineWidth(50);
                for (int y = -250; y < (300); y += 50)
                {
                    GL.Vertex2(100.0, y);
                    GL.Vertex2(600.0, y);
                }
                for (int x = 100; x < (650); x += 50)
                {
                    GL.Vertex2(x, -250);
                    GL.Vertex2(x, 250);
                }
                for (int y = -250; y < (300); y += 50)
                {
                    GL.Vertex2(-600.0, y);
                    GL.Vertex2(-100.0, y);
                }
                for (int x = -600; x < (-50); x += 50)
                {
                    GL.Vertex2(x, -250);
                    GL.Vertex2(x, 250);
                }

                GL.End();
                GL.Color3(Color.Transparent);
                A.GameMenu();
                //A.Ris(4, false);
                //DrawingShips A = new DrawingShips();
                //A.ComputerNavy();
                //FourDeck.OnClick += A.MenuCheck(4);

            }

        }



        #endregion

        public void Off()
        {
            _isActive = false;
            //OffControl();
        }

        public void On()
        {
            _isActive = true;
            //OnControl();
            OnResize();
        }

    }
}