using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Input;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace Battleship
{
    class GameEngine
    {
        int xst = 50, yst = 50;
        int rx = 0, ry = 0;
        int hrx = 0, hry = 0;
        Navy player = new Navy(false);
        Navy computer = new Navy(true);
        int size = 0, ran; //0-мимо 1-ранен 2-убит
        bool position = false, choise = false;
        private readonly GameController _window;
        Shoting obj;
        int _textureFire = TextureLoader.Load("textures/fire.png");
        int _ship4 = TextureLoader.Load("textures/Ship4Rotate.png");
        int _ship3 = TextureLoader.Load("textures/Ship3Rotate.png");
        int _ship2 = TextureLoader.Load("textures/Ship2Rotate.png");
        int _ship1 = TextureLoader.Load("textures/Ship1.png");
        int _ship4Rotate = TextureLoader.Load("textures/Ship4.png");
        int _ship3Rotate = TextureLoader.Load("textures/Ship3.png");
        int _ship2Rotate = TextureLoader.Load("textures/Ship2.png");

        public GameEngine(GameController window)
        {
            _window = window;
            obj = new Shoting(_window);

        }

        Ships ship = new Ships();
        //Ships ThreeDeckShip = new Ships();
        //Ships TwoDeckShip = new Ships();
        Square k4 = new Square();
        int status = 0;



        public Navy Player { get { return player; } set { player = value; } }


        public void ComputerNavy()
        {
            int x, y;
            bool position;
            bool b = false;
            while (b == false)
            {
                Random x1 = new Random();
                x = x1.Next(0, 9);
                Random y1 = new Random();
                y = y1.Next(0, 9);
                Random p1 = new Random();
                int p2 = p1.Next(0, 1);
                if (p2 == 0)
                { position = false; }
                else
                { position = true; };
                Ships A1 = new Ships();
                A1.CreateFourShip(x * 50 + 100, y * 50 + 50, position);
                if (computer.CountOfShips(4))
                    if (computer.CorrectCoordinateInField(A1))
                        if (computer.CorrectCoordinateOfNeighbourousSquare(A1))
                        { computer.AddShip(A1);
                            b = true; }
            }

            for (int i = 0; i < 2; i++)
            {
                bool c = false;
                while (c == false)
                {
                    Random x1 = new Random();
                    x = x1.Next(0, 9);
                    Random y1 = new Random();
                    y = y1.Next(-9, 0);
                    Random p1 = new Random();
                    int p2 = p1.Next(0, 1);
                    if (p2 == 0)
                    { position = false; }
                    else
                    { position = true; };
                    Ships A1 = new Ships();
                    A1.CreateThreeShip(x * 50 + 100, y * 50 + 200, position);
                    if (computer.CountOfShips(3))
                        if (computer.CorrectCoordinateInField(A1))
                            if (computer.CorrectCoordinateOfNeighbourousSquare(A1))
                            { computer.AddShip(A1);
                                c = true; }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                bool v = false;
                while (v == false)
                {
                    Random x1 = new Random();
                    x = x1.Next(0, 9);
                    Random y1 = new Random();
                    y = y1.Next(-9, 0);
                    Random p1 = new Random();
                    int p2 = p1.Next(0, 1);
                    if (p2 == 0)
                    { position = false; }
                    else
                    { position = true; };
                    Ships A1 = new Ships();
                    A1.CreateTwoShip(x * 50 + 100, y * 50 + 200, position);
                    if (computer.CountOfShips(2))
                        if (computer.CorrectCoordinateInField(A1))
                            if (computer.CorrectCoordinateOfNeighbourousSquare(A1))
                            { computer.AddShip(A1);
                                v = true; }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                bool g = false;
                while (g == false)
                {
                    Random x1 = new Random();
                    x = x1.Next(0, 9);
                    Random y1 = new Random();
                    y = y1.Next(-9, 0);
                    Random p1 = new Random();
                    int p2 = p1.Next(0, 1);
                    if (p2 == 0)
                    { position = false; }
                    else
                    { position = true; };
                    Ships A1 = new Ships();
                    A1.CreateOneShip(x * 50 + 100, y * 50 + 200, position);
                    if (computer.CountOfShips(1))
                        if (computer.CorrectCoordinateInField(A1))
                            if (computer.CorrectCoordinateOfNeighbourousSquare(A1))
                            { computer.AddShip(A1);
                                g = true; }
                }
            }
        }

        public void DrawingRanking(int size, bool pol)
        {
            GL.Color3(Color.Transparent);
            if (pol == false)
            {
                if (size == 4)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship4);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 50);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 200, yst + 50);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 200, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }
                if (size == 3)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship3);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 50);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 150, yst + 50);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 150, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);
                }

                if (size == 2)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship2);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 50);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 100, yst + 50);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 100, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }

                if (size == 1)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship1);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 50);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 50, yst + 50);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 50, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }
                //for (int i = 0; i < size; i++)
                //{
                //    GL.Rect((0 + xst) + 50 * i, (0 + yst), (50 + xst) + i * 50, (50 + yst));
                //}
            }
            else
            {
                if (size == 4)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship4Rotate);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 200);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 50, yst + 200);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 50, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);
                    

                }
                if (size == 3)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship3Rotate);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 150);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 50, yst + 150);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 50, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }

                if (size == 2)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship2Rotate);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 100);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 50, yst + 100);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 50, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }

                if (size == 1)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, _ship1);
                    GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(xst, yst);
                    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(xst, yst + 50);
                    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(xst + 50, yst + 50);
                    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(xst + 50, yst);
                    GL.End();
                    GL.Disable(EnableCap.Blend);

                }
            }
            //for (int i = 0; i < size; i++)
            //    {
            //        GL.Rect((0 + xst), (0 + yst) + 50 * i, (50 + xst), (50 + yst) + 50 * i);
            //    }
            GL.Color3(Color.Transparent);
        }



        public void Fire(float x, float y)
        {
            //GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, _textureFire);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x, y + 50);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + 50, y + 50);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x + 50, y);
            GL.End();
            GL.Disable(EnableCap.Blend);
            GL.Color3(Color.Transparent);
            //GL.Color3(Color.Red);
            //GL.Rect(x, y, x + 50, y + 50);
            //GL.Color3(Color.Black);
            //GL.Begin(PrimitiveType.Lines);
            //GL.Vertex2(x, y);
            //GL.Vertex2(x + 50, y + 50);
            //GL.End();
            //GL.Begin(PrimitiveType.Lines);
            //GL.Vertex2(x + 50, y);
            //GL.Vertex2(x, y + 50);
            //GL.End();
        }

        public void DrawingPast(float x, float y)
        {
            GL.PointSize(5);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Black);
            GL.Vertex2(x + 25, y + 25);
            GL.End();
            GL.Color3(Color.Transparent);
        }

        public void DrawingPastRoundSunkingShip()
        {
            for (int i = 0; i < Shoting.past.Count; i++)
                if (((Shoting.past[i].X >= -600 && Shoting.past[i].X <= -150) && (Shoting.past[i].Y >= -250 && Shoting.past[i].Y < 200)) || ((Shoting.past[i].X > 50 && Shoting.past[i].X < 600) && (Shoting.past[i].Y > -300 && Shoting.past[i].Y < 250)))
                    DrawingPast(Shoting.past[i].X, Shoting.past[i].Y);
            GL.Color3(Color.Transparent);
        }

        public void DrawingPlacedShip(Ships K)
        {
            GL.Color3(Color.Transparent);
            if (K.Position == false)
            {
                switch (K.Size)
                {
                    case 4:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship4);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 200, K.Deck[0].Y + 50);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 200, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                    case 3:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship3);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 150, K.Deck[0].Y + 50);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 150, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                    case 2:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship2);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 100, K.Deck[0].Y + 50);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 100, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;
                    case 1:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship1);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 50);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                }
            }
            else
            {
                switch (K.Size)
                {
                    case 4:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship4Rotate);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 200);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 200);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                    case 3:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship3Rotate);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 150);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 150);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                    case 2:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship2Rotate);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 100);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 100);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;
                    case 1:
                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();
                        GL.Enable(EnableCap.Blend);
                        GL.BlendFunc(BlendingFactorSrc.DstAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, _ship1);
                        GL.Begin(PrimitiveType.Quads);
                        GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
                        GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
                        GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 50);
                        GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
                        GL.End();
                        GL.Disable(EnableCap.Blend);
                        break;

                }
            }
            //if (size == 4)
            //{

            //    GL.MatrixMode(MatrixMode.Modelview);
            //    GL.LoadIdentity();
            //    GL.Enable(EnableCap.Texture2D);
            //    GL.BindTexture(TextureTarget.Texture2D, _ship4);
            //    GL.Begin(PrimitiveType.Quads);
            //    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
            //    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
            //    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 200, K.Deck[0].Y + 50);
            //    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 200, K.Deck[0].Y);
            //    GL.End();

            //}
            //if (size == 3)
            //{
            //    GL.MatrixMode(MatrixMode.Modelview);
            //    GL.LoadIdentity();
            //    GL.Enable(EnableCap.Texture2D);
            //    GL.BindTexture(TextureTarget.Texture2D, _ship3);
            //    GL.Begin(PrimitiveType.Quads);
            //    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
            //    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
            //    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 150, K.Deck[0].Y + 50);
            //    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 150, K.Deck[0].Y);
            //    GL.End();

            //}

            //if (size == 2)
            //{
            //    GL.MatrixMode(MatrixMode.Modelview);
            //    GL.LoadIdentity();
            //    GL.Enable(EnableCap.Texture2D);
            //    GL.BindTexture(TextureTarget.Texture2D, _ship2);
            //    GL.Begin(PrimitiveType.Quads);
            //    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
            //    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
            //    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 100, K.Deck[0].Y + 50);
            //    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 100, K.Deck[0].Y);
            //    GL.End();

            //}

            //if (size == 1)
            //{
            //    GL.MatrixMode(MatrixMode.Modelview);
            //    GL.LoadIdentity();
            //    GL.Enable(EnableCap.Texture2D);
            //    GL.BindTexture(TextureTarget.Texture2D, _ship1);
            //    GL.Begin(PrimitiveType.Quads);
            //    GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y);
            //    GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(K.Deck[0].X, K.Deck[0].Y + 50);
            //    GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y + 50);
            //    GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(K.Deck[0].X + 50, K.Deck[0].Y);
            //    GL.End();

            //}
            GL.Color3(Color.Transparent);
        }
        //GL.Color3(Color.Red);
        //for (int i = 0; i < K.Size; i++)
        //    GL.Rect(K.Deck[i].X, K.Deck[i].Y, K.Deck[i].X + 50, K.Deck[i].Y + 50);
        //GL.Color3(Color.Transparent);


        public void DrawNavy(Navy F)
        {
            for (int i = 0; i < F.NavyList.Count; i++)
                DrawingPlacedShip(F.NavyList[i]);
            GL.Color3(Color.Transparent);

        }

        public void DrawSunkingNavy(Navy F)
        {
            //GL.Color3(Color.Black);
            for (int i = 0; i < F.NavyList.Count; i++)
                for (int j = 0; j < F.NavyList[i].Size; j++)
                    if (F.NavyList[i].Deck[j].IsShot) Fire(F.NavyList[i].Deck[j].X, F.NavyList[i].Deck[j].Y);
            GL.Color3(Color.Transparent);

        }

        public void GameMenu()
        {
            switch (status)
            {
                case 0:

                    Shoting.past.Clear();
                    computer.ClearFlot();
                    ComputerNavy();
                    player.ClearFlot();
                    status = 1;
                    xst = -600; yst = 200;
                    break;
                case 1:
                    DrawNavy(player);
                    if (choise) DrawingRanking(size, position);

                    break;

                case 2:
                    _window.IncludeNavyFormed();
                    status = 3;
                    xst = 100; yst = 200;
                    break;

                case 3:
                    DrawingPastRoundSunkingShip();
                    DrawNavy(player);
                    GL.Color3(Color.Pink);
                    GL.Rect(0 + xst, 0 + yst, 50 + xst, 50 + yst);
                    //DrawingPastRoundSunkingShip();
                    DrawSunkingNavy(computer);
                    DrawSunkingNavy(player);
                    GL.Color3(Color.Transparent);

                    break;

                case 4:
                    DrawingPastRoundSunkingShip();
                    DrawNavy(player);
                    //DrawingPastRoundSunkingShip();
                    DrawSunkingNavy(computer);
                    DrawSunkingNavy(player);
                    k4 = obj.ComputerShooting(player, ref ran, ref hrx, ref hry);
                    
                    if (k4.X != null && k4.X != 0) { Shoting.past.Add(k4); status = 3; } else status = 4;
                    if (k4.X != null && k4.X != 0) status = 3; else status = 4; //!!!
                    break;

                case 5:
                    //_winScreen.OnLoad();
                    //_winScreen.OnRenderFrame();
                    _window.IncludeWinScreen();
                    //MessageBox.Show("Вы выиграли!", "Играем еще раз?", MessageBoxButtons.YesNoCancel);
                    status = 0;
                    break;

                case 6:
                    _window.IncludeDefeatScreen();
                    //MessageBox.Show("Вы програли", "Играем еще раз?", MessageBoxButtons.YesNoCancel);
                    status = 0;
                    break;
            }
            GL.Flush();
        }

        public void SpecialKeys(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Up)
                if (yst < 200)
                    yst += 50;

            if (e.Key == Key.Down)
                if (yst > -250)
                    yst -= 50;

            if (e.Key == Key.Left)
                if (status == 1)
                { if (xst > -600) xst -= 50; }
                else if (xst > 100) xst -= 50;

            if (e.Key == Key.Right)
                if (status == 1)
                { if (xst < -150) xst += 50; }
                else if (xst < 550) xst += 50;

        }

        public void Keyboard(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (status == 1)
                {
                    rx = xst; ry = yst;
                    Ships A = new Ships();
                    switch (size)
                    {
                        case 4:
                            if (player.CountOfShips(4))
                            {
                                A.CreateFourShip(rx, ry, position);
                                if (player.CorrectCoordinateInField(A))
                                    if (player.CorrectCoordinateOfNeighbourousSquare(A))
                                        player.AddShip(A);
                                    else MessageBox.Show("Корабли не должны стоять рядом!", "Ошибка", MessageBoxButtons.OK);
                                else MessageBox.Show("Нельзя ставить корабли вне поля !", "Ошибка ", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Кораблей такого типа достаточно!", "Ошибка", MessageBoxButtons.OK);
                            if (player.IsFlotFull()) status = 2;
                            break;
                        case 3:
                            if (player.CountOfShips(3))
                            {
                                A.CreateThreeShip(rx, ry, position);
                                if (player.CorrectCoordinateInField(A))
                                    if (player.CorrectCoordinateOfNeighbourousSquare(A))
                                        player.AddShip(A);
                                    else MessageBox.Show("Корабли не должны стоять рядом!", "Ошибка", MessageBoxButtons.OK);
                                else MessageBox.Show("Нельзя ставить корабли вне поля!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Кораблей такого типа достаточно!", "Ошибка", MessageBoxButtons.OK);
                            if (player.IsFlotFull()) status = 2;
                            break;
                        case 2:
                            if (player.CountOfShips(2))
                            {
                                A.CreateTwoShip(rx, ry, position);
                                if (player.CorrectCoordinateInField(A))
                                    if (player.CorrectCoordinateOfNeighbourousSquare(A))
                                        player.AddShip(A);
                                    else MessageBox.Show("Корабли не должны стоять рядом", "Ошибка", MessageBoxButtons.OK);
                                else MessageBox.Show("Нельзя ставить корабли вне поля!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Кораблей такого типа достаточно!", "Ошибка", MessageBoxButtons.OK);
                            if (player.IsFlotFull()) status = 2;
                            break;
                        case 1:
                            if (player.CountOfShips(1))
                            {
                                A.CreateOneShip(rx, ry, position);
                                if (player.CorrectCoordinateInField(A))
                                    if (player.CorrectCoordinateOfNeighbourousSquare(A))
                                        player.AddShip(A);
                                    else MessageBox.Show("Корабли не должны стоять рядом!", "Ошибка", MessageBoxButtons.OK);
                                else MessageBox.Show("Нельзя ставить корабли вне поля!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Кораблей такого типа достаточно!", "Ошибка", MessageBoxButtons.OK);
                            if (player.IsFlotFull()) status = 2;
                            break;
                    }

                }
                if (status == 3)
                {
                    int s = 0;
                    rx = xst; ry = yst;
                    int v = obj.Shot(computer, rx, ry, ref s);
                    Square k1 = new Square(rx, ry);
                    if (v == 0) Shoting.past.Add(k1);
                    if (computer.StatusOfWin()) status = 5;
                    else if (player.StatusOfWin()) status = 6;
                    else
                    if (v == 0) status = 4; else status = 3; //!!!!
                }
            }
        }

        public void SelectFourDeck()
        {
            if (player.CountOfShips(4))
            {
                choise = true;
                //pol = false;
                //if (e.Key == Key.X)
                //{ pol = true; }
                size = 4;
            }
            //else MessageBox.Show("Нельзя!", "Ошибка", MessageBoxButtons.OK);
        }

        public void SelectThreeDeck()
        {
            if (player.CountOfShips(3))
            {
                choise = true;
                //pol = false;
                //if (e.Key == Key.X)
                //{ pol = true; }
                size = 3;
            }
           // else MessageBox.Show("Нельзя!", "Ошибка", MessageBoxButtons.OK);
        }

        public void SelectTwoDeck()
        {
            if (player.CountOfShips(2))
            {
                choise = true;
                //pol = false;
                
                //if (e.Key == Key.X)
                //{ pol = true; }
                size = 2;
            }
           // else MessageBox.Show("Нельзя!", "Ошибка", MessageBoxButtons.OK);
        }

        public void SelectOneDeck()
        {
            if (player.CountOfShips(1))
            {
                choise = true;
                //pol =  true;
                //if (e.Key == Key.X)
                //{ pol = true; }
                size = 1;
            }
           // else MessageBox.Show("Нельзя!", "Ошибка", MessageBoxButtons.OK);
        }

        public void Rotate(object sender, KeyboardKeyEventArgs  e)
        {
            if (e.Key == Key.X)
            {
                position = !position;
                //return pol;
            }

        }

        //public bool Pol { get {return pol; } set {pol = value; } }






    }
}
