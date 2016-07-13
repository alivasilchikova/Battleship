using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Navy
    {
        private List<Ships> _navyList = new List<Ships>();
        private bool _definitionPlayer; 
        private Square _staringCoordinate = new Square();

        public Navy(bool definitionPlayer)
        {
            _definitionPlayer = definitionPlayer;
            if (definitionPlayer)
            { _staringCoordinate.X = 100; _staringCoordinate.Y = 200; }
            else
            { _staringCoordinate.X = -600; _staringCoordinate.Y = 200; }
        }



        public List<Ships> NavyList
        {
            get { return _navyList; }
            set { _navyList = value; }
        }

        public bool DefinitionPlayer
        {
            get { return _definitionPlayer; }
            set { _definitionPlayer = value; }
        }

        public Square StartingCoordinate
        {
            get { return _staringCoordinate; }
            set { _staringCoordinate = value; }
        }

        public void AddShip(Ships ship)
        {
            _navyList.Add(ship);
        }

        public bool FindSquare(float x1, float y1)
        {
            int size = _navyList.Count;
            bool f = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < _navyList[i].Size; j++)
                {
                    if ((_navyList[i].Deck[j].X == x1) && (_navyList[i].Deck[j].Y == y1))
                        f = true; 
                }
            }
            return f;
        }
        /// <summary>
        /// ПРОБЛЕМЫ С ВОЗВРАЩАЕМЫМ ЗНАЧЕНИЕМ K
        /// </summary>


        //public Square FindK(float x1, float y1)
        //{
        //    int size = _navyList.Count;
        //    //Square K;
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < _navyList[i].Size; j++)
        //            if ((_navyList[i].Deck[j].X == x1) && (_navyList[i].Deck[j].Y == y1))
        //                return _navyList[i].Deck[j];
        //    }
        //    return null;
        //}

        //public Ships FindKorab(Square Kl)
        //{
        //    int size = _navyList.Count;
        //    //Ships K = _navy[0];
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < _navyList[i].Size; j++)
        //            if (_navyList[i].Deck[j] == Kl)
        //               return  _navyList[i];
        //    }
        //    return null;
        //}

        public bool CountOfShips(int size)
        {
            int count = 0;
            if (_navyList.Count == 10) return false;
            else
            {
                for (int i = 0; i < _navyList.Count; i++)
                {
                    if (_navyList[i].Size == size) count++;
                }
                if (size == 4 && count == 1) return false;
                else
                {
                    if (size == 3 && count == 2) return false;
                    else
                    {
                        if (size == 2 && count == 3) return false;
                        else
                        {
                            if (size == 1 && count == 4) return false;
                            else return true;
                        }
                    }
                }
            }

        }

        public bool IsFlotFull()
        {
            if (_navyList.Count == 10) return true;
            else return false;
        }

        public bool CorrectCoordinateInField(Ships K)
        {
            for (int i = 0; i < K.Size; i++)
            {
                if (K.Deck[i].X < _staringCoordinate.X || K.Deck[i].X >= (_staringCoordinate.X + 500) || K.Deck[i].Y > _staringCoordinate.Y || K.Deck[i].Y <= (_staringCoordinate.Y - 500))
                    return false;
            }
            return true;
        }

        public bool CorrectCoordinateOfNeighbourousSquare(Ships K)
        {
            for (int i = 0; i < K.Size; i++)
            {
                if (FindSquare(K.Deck[i].X, K.Deck[i].Y) || FindSquare(K.Deck[i].X - 50, K.Deck[i].Y) || FindSquare(K.Deck[i].X + 50, K.Deck[i].Y) || FindSquare(K.Deck[i].X, K.Deck[i].Y - 50) || FindSquare(K.Deck[i].X, K.Deck[i].Y + 50) || FindSquare(K.Deck[i].X - 50, K.Deck[i].Y - 50) || FindSquare(K.Deck[i].X + 50, K.Deck[i].Y + 50) || FindSquare(K.Deck[i].X + 50, K.Deck[i].Y - 50) || FindSquare(K.Deck[i].X - 50, K.Deck[i].Y + 50))
                    return false;
            }
            return true;
        }

        public bool StatusOfWin()
        {
            int k = 0;
            for (int i = 0; i < _navyList.Count; i++)
                if (_navyList[i].Status == 2) k++;
            if (k == _navyList.Count) return true;
            else return false;
        }

        public void ClearFlot()
        {
            _navyList.Clear();
        }


    }
}
