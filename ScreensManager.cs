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
        public class GameController : GameWindow
    {
        private readonly MainScreen _mainscreen;
        private FieldScreen gamescreen;
        private HelpScreen _helpScreen;
        private WinScreen _winScreen;
        private DefeatScreen _defeatScreen;
        private NavyFormedScreen _navyFormed;
        private ShipSunkingScreen _shipSunking;
        public GameController() : base(900, 600)
        {
            //Основные параметры окна
            Title = "Battleship";
            //Icon = new Icon("resourses/icons/favicon.ico");
            Cursor = CursorLoader.Load("textures/cursor.png");
            VSync = VSyncMode.On;
            WindowBorder = WindowBorder.Fixed;
            //
            //Основные управляющие клавиши окна
            KeyDown += KeyboardDown;
            //
            //Инициализация всех игровых экранов
            _mainscreen = new MainScreen(this);
            gamescreen = new FieldScreen(this);
            _helpScreen = new HelpScreen(this);
            _winScreen = new WinScreen(this);
            _defeatScreen =new DefeatScreen(this);
            _navyFormed = new NavyFormedScreen(this);
            _shipSunking = new ShipSunkingScreen(this);
            //
            //Инициализация событий-переключений всех игровых экранов      
            _mainscreen.NewGameItem.OnClick += NewGame;
            _mainscreen.HelpItem.OnClick += Help;
            _mainscreen.ExitItem.OnClick += ExitGame;
            _helpScreen.CloseButton.OnClick += CloseHelpScreen;
            _winScreen.CloseButton.OnClick += ExitGame;
            _winScreen.NoButton.OnClick += ExitGame;
            _winScreen.YesButton.OnClick += NewGame;
            _defeatScreen.CloseButton.OnClick += ExitGame;
            _defeatScreen.NoButton.OnClick += ExitGame;
            _defeatScreen.YesButton.OnClick += NewGame;
            _navyFormed.YesButton.OnClick += NewGame;
            _shipSunking.YesButton.OnClick += NewGame;
            //
            // Mouse.ButtonDown += CursorDown;
            // Mouse.ButtonUp += CursorUp;  
        }

        private void KeyboardDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                gamescreen.Off();
                _mainscreen.On();        
            }
            if (e.Key == Key.F6)
            {
                _mainscreen.Off();
                gamescreen.On();
            }
            if (e.Key == Key.F11)
                if (WindowState == WindowState.Fullscreen)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Fullscreen;
        }

        #region Events
        public void NewGame()
        {
            _mainscreen.Off();
            _helpScreen.Off();
            gamescreen.On();
            _winScreen.Off();
            _defeatScreen.Off();
            _navyFormed.Off();
            _shipSunking.Off();
        }

        public void ExitGame()
        {
            Exit();
        }

        public void Help()
        {
            gamescreen.Off();
            _mainscreen.OffControl();
            _helpScreen.On();
        }

        public void CloseHelpScreen()
        {
            gamescreen.Off();
            _mainscreen.OnControl();
            _helpScreen.Off();
        }

        public void IncludeWinScreen()
        {
            gamescreen.Off();
            _mainscreen.Off();
            _helpScreen.Off();
            _winScreen.On();
        }

        public void IncludeDefeatScreen()
        {
            gamescreen.Off();
            _mainscreen.Off();
            _helpScreen.Off();
            _defeatScreen.On();
        }

        public void IncludeNavyFormed()
        {
            gamescreen.Off();
            _mainscreen.Off();
            _helpScreen.Off();
            _navyFormed.On();
        }

        public void IncludeShipSunkingScreen()
        {
            gamescreen.Off();
            _mainscreen.Off();
            _helpScreen.Off();
            _shipSunking.On();
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
           GL.ClearColor(Color.MidnightBlue);
           gamescreen.OnLoad();
           _mainscreen.OnLoad();
           _helpScreen.OnLoad();
            _winScreen.OnLoad();
            _defeatScreen.OnLoad();
            _navyFormed.OnLoad();
            _shipSunking.OnLoad();
        }

        protected override void OnResize(EventArgs e)
        {

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-900.0, 900.0, -600.0, 600.0, 0.0, 4.0);
            _mainscreen.OnResize();
           gamescreen.OnResize();
            _helpScreen.OnResize();
            _winScreen.OnResize();
            _defeatScreen.OnResize();
            _navyFormed.OnResize();
            _shipSunking.OnResize();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            _mainscreen.OnUpdateFrame();
           gamescreen.OnUpdateFrame();
            _helpScreen.OnUpdateFrame();
            _winScreen.OnUpdateFrame();
            _defeatScreen.OnUpdateFrame();
            _navyFormed.OnUpdateFrame();
            _shipSunking.OnUpdateFrame();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            _mainscreen.OnRenderFrame();
            gamescreen.OnRenderFrame();
            _helpScreen.OnRenderFrame();
            _winScreen.OnRenderFrame();
            _defeatScreen.OnRenderFrame();
            _navyFormed.OnRenderFrame();
            _shipSunking.OnRenderFrame();
            SwapBuffers();       
        }
    }
}
