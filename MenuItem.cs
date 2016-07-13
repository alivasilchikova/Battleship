using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace Battleship
{

    public class MenuItem
    {
        private TextRenderer _text;
        private bool _isUnderCursor;
        //
        private readonly Font _normalFont;
        private readonly Font _specialFont;
        private readonly Brush _normalColor;
        private readonly Brush _specialColor;
        //
        private readonly GameController _window;
        //
        public delegate void MethodContainer();
        public event MethodContainer OnClick;

        public TextRenderer Text
        { get {return _text; } set { _text = value; } }

        public MenuItem(int width, int height, Font normalFont, Font specialFont, Brush normalColor, Brush specialColor, GameController window)
        {
            _normalFont = normalFont;
            _specialFont = specialFont;
            _normalColor = normalColor;
            _specialColor = specialColor;
            _text = new TextRenderer(width, height);
            _window = window;
            _isUnderCursor = IsUnderCursor();
        }

        public bool IsUnderCursor()
        {
#pragma warning disable 618
            if (_window.Mouse.X > _text.Position.X && _window.Mouse.X < _text.Position.X + _text.Region.Width
                && _window.Mouse.Y > _text.Position.Y && _window.Mouse.Y < _text.Position.Y + _text.Region.Height)
#pragma warning restore 618
            {
                return true;
            }
            return false;
        }

        public void Draw(string printedString, float screenWidth, float screenHeight, PointF position)
        {
            _isUnderCursor = IsUnderCursor();
            if (!_isUnderCursor)
                _text.PrintOnScreen(printedString, _normalFont, screenWidth, screenHeight, position, _normalColor);
            else
            {
                _text.PrintOnScreen(printedString, _specialFont, screenWidth, screenHeight, position, _specialColor);
            }
        }

        public void ButtonDown(object sender, MouseButtonEventArgs mouse)
        {
            if (mouse.Button == MouseButton.Left && _isUnderCursor && OnClick != null)
            {
                OnClick();
            }
        }

        public void TurnOnBackground(Color normalColor, Color specialColor)
        {
            if (!_isUnderCursor)
            {
                _text.TurnOffBelnding(normalColor);
            }
            else
            {
                _text.TurnOffBelnding(specialColor);
            }

        }
    }
}
