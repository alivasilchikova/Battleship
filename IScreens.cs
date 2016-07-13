using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public interface IScreens
    {
        void OnLoad();
        void OnResize();
        void OnUpdateFrame();
        void OnRenderFrame();
        //void On();
        //void Off();
    }
}
