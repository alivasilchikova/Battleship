using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    class Shoting
    {
        public static List<Square> past = new List<Square>();
        private readonly GameController _window;

        public Shoting(GameController window)
        {
            _window = window;
        }

        public static bool FindPastSquare( Square K)
        {
            for (int i = 0; i < past.Count; i++)
                if (past[i] == K) return true;
            return false;
        }

        public static void AddToPastSquareRoundSunkingShip(Square K)
        {
            Square Kl1 = new Square(K.X + 50, K.Y + 50); Kl1.IsShot = true;
            past.Add(Kl1);
            Square Kl2 = new Square(K.X + 50, K.Y - 50); Kl2.IsShot= true;
            past.Add(Kl2); 
            Square Kl3 = new Square(K.X - 50, K.Y + 50); Kl3.IsShot = true;
            past.Add(Kl3);
            Square Kl4 = new Square(K.X - 50, K.Y - 50); Kl4.IsShot = true;
            past.Add(Kl4);
            Square Kl5 = new Square(K.X, K.Y + 50); Kl5.IsShot = true;
            past.Add(Kl5);
            Square Kl6 = new Square(K.X, K.Y - 50); Kl6.IsShot = true;
            past.Add(Kl6);
            Square Kl7 = new Square(K.X - 50, K.Y); Kl7.IsShot = true;
            past.Add(Kl7);
            Square Kl8 = new Square(K.X + 50, K.Y); Kl8.IsShot = true;
            past.Add(Kl8);
        }

        public static void KillRound(Ships K)
        {
            for (int i = 0; i < K.Size; i++)
                AddToPastSquareRoundSunkingShip(K.Deck[i]);
        }

        public int Shot(Navy A, int x1, int y1, ref int state)  //1 есть и не стреляли, 0 мимо, 2 есть но стреляли, 3 убил 
        {
            int size = A.NavyList.Count;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < A.NavyList[i].Size; j++)
                    if ((A.NavyList[i].Deck[j].X == x1) && (A.NavyList[i].Deck[j].Y == y1))
                    {
                        if (A.NavyList[i].Deck[j].IsShot == false)
                        {
                            A.NavyList[i].Deck[j].AreFired();
                            A.NavyList[i].StatusOfShip();
                            //cout << "status" << A.flot[i].status << endl;
                            //if (A.NavyList[i].Status == 1) { state = 1; 
                            //if (A.DefinitionPlayer == false)
                             //return 1; }
                            if (A.NavyList[i].Status == 2) { state = 2; if (A.DefinitionPlayer == true)
                                    _window.IncludeShipSunkingScreen();
                                    //MessageBox.Show("Убит");
                                KillRound(A.NavyList[i]); return 3; }

                            return 1;
                        }
                        else  return 2;
                        //if (state == 2) return 2;
                    }
            }
            return 0;
        }

        public Square ComputerShooting(Navy My, ref int ran, ref int hrx, ref int hry )
         {
            int x = 0, y = 0;
            int b = 2;
            int state = 0;
            Square K = new Square (x, y);
            Square K0 = new Square(0, 0);

            if (ran == 2 || ran == 0)
            {
                while (b == 2)
                {
                    
                    Random x1 = new Random();
                    float a= x1.Next(-600, -100);
                    float v = a - a % 50;
                    float v1 = a + (50-a % 50);
                    //if (a % 50 == 0)
                    //{ x = (int)a; }
                    //else 
                        if (v >= -600 && v <= -150) { x = (int)v; }
                                    else if (v <= -150) { x = (int)v-50; }

                   
                    Random y1 = new Random();
                    float a1 = y1.Next(-300, 200);
                    float v2 = a1 - a1 % 50;
                    float v3 = a1 + (50-a1 % 50);
                    //if (a1 % 50 == 0)
                    //{ y = (int)a1; }
                    //else
                        if (v2 >= -250 && v2 <= 200) { y = (int)v2; }
                            else { y = (int)v3; }


                    K.X = x;
                    K.Y = y;

                    

                    while (FindPastSquare(K) == true)
                    {
                        
                        Random x2 = new Random();
                        float a2 = x2.Next(-600, -100);
                        float v4 = a2 - a2 % 50;
                        float v5 = a2 + (50-a2 % 50);
                        //if (a2 % 50 == 0)
                        //{ x = (int)a2; }
                        //else
                            if (v4 >= -600 && v4 <= -150) { x = (int)v4; }
                                else { x = (int)v4-50; }

                        
                        Random y2 = new Random();
                        float a3 = y2.Next(-300, 200);
                        float v6 = a3 - a3 % 50;
                        float v7 = a3 + (50 - a3 % 50);
                        if (a3 % 50 == 0)
                        { y = (int)a3; }
                        if (v6 >= -250 && v6 <= 200) { y = (int)v6; }
                        else { y = (int)v7; }
                        K.X = x;
                        K.Y = y;
                        //hrx=x; hry=y;
                    }
                    b = Shot(My, x, y, ref state);
                     hrx = x;
                    hry = y;
                    //if (Find(K) == false) break;
                    //return K0; //??????????????????????????????
                }
                if (b == 1) { ran = 1; return K0; }
                if (b == 3) { ran = 2; return K0; }
                if (b == 0) { return K; }
                return null;
            }
            else
            {
                int sch = 0;
                while (b == 2)
                {
                    //sch++;
                    //if (sch > 7)
                    //{ state = 0; return K0; }
                    Random zn1 = new Random();
                    int zn = zn1.Next(0, 1);
                    Random pol1 = new Random();
                    int pol = pol1.Next(0, 1);
                    if (ran == 1) zn = 0; else zn = 1; // добавила
                    //углы 
                    if ((hrx == -600) && (hry == -250)) { if (zn == 0) { x = hrx + 50; y = hry; } else { x = hrx; y = hry + 50; } }
                    else
                    {
                        if ((hrx == -600) && (hry == 200)) { if (zn == 0) { x = hrx + 50; y = hry; } else { x = hrx; y = hry - 50; } }
                        else
                        {
                            if ((hrx == -150) && (hry ==200 )) { if (zn == 0) { x = hrx - 50; y = hry; } else { x = hrx; y = hry - 50; } }
                            else
                            {
                                if ((hrx == -150) && (hry == -250)) if (zn == 0) { x = hrx - 50; y = hry; } else { x = hrx; y = hry + 50; }
                                else
                                //бока
                                {
                                    if (hrx == -600) { if (zn == 0) { x = hrx + 50; y = hry; } else { if (pol == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                    else
                                    {
                                        if (hrx == -150) { if (zn == 0) { x = hrx - 50; y = hry; } else { if (pol == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                        else
                                        {
                                            if (hry == -250) { if (zn == 0) { x = hrx; y = hry - 50; } else { if (pol == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                            else
                                            {
                                                if (hry == -250) { if (zn == 0) { x = hrx; y = hry - 50; } else { if (pol == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                                else
                                                {
                                                    if (hry == 200) { if (zn == 0) { x = hrx; y = hry + 50; } else { if (pol == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                                    else
                                                    // остальные
                                                    { if (zn == 0) { if (pol == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } else { if (pol == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //return K0;
                    }

                    K.X = x;
                    K.Y = y;
                    //hrx=x; hry=y;
                    while (FindPastSquare(K) == true)
                    {
                        Random znn1 = new Random();
                        int znn = znn1.Next(0, 1);
                        Random poln1 = new Random();
                        int poln = poln1.Next(0, 1);
                        //углы 
                        if ((hrx == -600) && (hry == -250)) { if (znn == 0) { x = hrx + 50; y = hry; } else { x = hrx; y = hry + 50; } }
                        else
                        {
                            if ((hrx == -600) && (hry == 200)) { if (znn == 0) { x = hrx + 50; y = hry; } else { x = hrx; y = hry - 50; } }
                            else
                            {
                                if ((hrx == -150) && (hry == 200)) { if (znn == 0) { x = hrx - 50; y = hry; } else { x = hrx; y = hry - 50; } }
                                else
                                {
                                    if ((hrx == -150) && (hry == -250)) if (znn == 0) { x = hrx - 50; y = hry; } else { x = hrx; y = hry + 50; }
                                    else
                                    //бока
                                    {
                                        if (hrx == -600) { if (znn == 0) { x = hrx + 50; y = hry; } else { if (poln == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                        else
                                        {
                                            if (hrx == -150) { if (znn == 0) { x = hrx - 50; y = hry; } else { if (poln == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                            else
                                            {
                                                if (hry == 200) { if (znn == 0) { x = hrx; y = hry - 50; } else { if (poln == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                                else
                                                {
                                                    if (hry == 200) { if (znn == 0) { x = hrx; y = hry - 50; } else { if (poln == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                                    else
                                                    {
                                                        if (hry == -250) { if (znn == 0) { x = hrx; y = hry + 50; } else { if (poln == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } }
                                                        else
                                                        // остальные
                                                        { if (znn == 0) { if (poln == 0) { x = hrx + 50; y = hry; } else { x = hrx - 50; y = hry; } } else { if (poln == 0) { x = hrx; y = hry + 50; } else { x = hrx; y = hry - 50; } } }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        K.X = x;
                        K.Y = y;
                        //return K0;

                    }
                    b = Shot(My, x, y, ref state);
                }
                if (b == 3) { ran = 2; return K0; }
                if (b == 1) { hrx = x; hry = y; ran = 1; return K0; }
                if (b == 0) { ran = 0;  return K; }
                return null;
            }

        }
    }
}
