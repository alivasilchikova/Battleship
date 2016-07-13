using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Battleship
{

    public class TextRenderer : IDisposable
    {
        private readonly int _textureId;
        //
        private readonly Bitmap _bmp;
        private readonly Graphics _gfx;
        private Rectangle _region;
        private bool _isDisposed;
        private PointF _position;
        //
        private Color _clearColor;
        private bool _isBlending;

        #region Constructors

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="width">The width of the backing store in pixels.</param>
        /// <param name="height">The height of the backing store in pixels.</param>
        public TextRenderer(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");
            if (GraphicsContext.CurrentContext == null)
                throw new InvalidOperationException("No GraphicsContext is current on the calling thread.");

            _bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            _gfx = Graphics.FromImage(_bmp);
            _gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            _textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0,
                PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            //
            _clearColor = Color.Transparent;
            _isBlending = false;
        }

        #endregion

        #region Properties

        public PointF Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Rectangle Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public int Texture
        {
            get
            {
                UploadBitmap();
                return _textureId;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Clears the backing store to the specified color.
        /// </summary>
        /// <param name="color">A <see cref="System.Drawing.Color"/>.</param>
        public void Clear(Color color)
        {
            _gfx.Clear(color);
            _region = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
        }

        /// <summary>
        /// Draws the specified string to the backing store.
        /// </summary>
        /// <param name="text">The <see cref="System.String"/> to draw.</param>
        /// <param name="font">The <see cref="System.Drawing.Font"/> that will be used.</param>
        /// <param name="brush">The <see cref="System.Drawing.Brush"/> that will be used.</param>
        /// <param name="point">The location of the text on the backing store, in 2d pixel coordinates.
        /// The origin (0, 0) lies at the top-left corner of the backing store.</param>
        public void DrawString(string text, Font font, Brush brush, PointF point)
        {
            _gfx.DrawString(text, font, brush, point);

            SizeF size = _gfx.MeasureString(text, font);
            _region = Rectangle.Round(RectangleF.Union(_region, new RectangleF(point, size)));
            _region = Rectangle.Intersect(_region, new Rectangle(0, 0, _bmp.Width, _bmp.Height));
        }

        /// <summary>
        /// Gets a <see cref="System.Int32"/> that represents an OpenGL 2d texture handle.
        /// The texture contains a copy of the backing store. Bind this texture to TextureTarget.Texture2d
        /// in order to render the drawn text on screen.
        /// </summary>

        public void PrintOnScreen(string printedString, Font font, float screenWidth, float screenHeight, PointF position, Brush color)
        {
            _position = position;
            GL.PushMatrix();
            GL.LoadIdentity();
            //
            var orthoProjection = Matrix4.CreateOrthographicOffCenter(0, screenWidth, screenHeight, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Projection);
            //
            GL.PushMatrix();
            GL.LoadMatrix(ref orthoProjection);
            //
            if (!_isBlending)
            {
                GL.Enable(EnableCap.Blend);
            }
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Texture);
            //
            Clear(_clearColor);
            //
            GL.FrontFace(FrontFaceDirection.Cw);
            //
#pragma warning disable 618
            GL.Begin(BeginMode.Quads);
#pragma warning restore 618
            GL.TexCoord2(0, 0); GL.Vertex2(_position.X, _position.Y);
            GL.TexCoord2(1, 0); GL.Vertex2(_position.X + _region.Width, _position.Y);
            GL.TexCoord2(1, 1); GL.Vertex2(_position.X + _region.Width, _position.Y + _region.Height);
            GL.TexCoord2(0, 1); GL.Vertex2(_position.X, _position.Y + _region.Height);
            GL.End();
            //
            GL.FrontFace(FrontFaceDirection.Ccw);
            //
            DrawString(printedString, font, color, PointF.Empty);
            GL.PopMatrix();
            //
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            //
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }

        public void TurnOffBelnding(Color clearColor)
        {
            _clearColor = clearColor;
            _isBlending = true;
        }

        #endregion

        #region Private Members

        // Uploads the dirty regions of the backing store to the OpenGL texture.
        public void UploadBitmap()
        {
            if (_region != RectangleF.Empty)
            {
                System.Drawing.Imaging.BitmapData data = _bmp.LockBits(_region,
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.BindTexture(TextureTarget.Texture2D, _textureId);
                GL.TexSubImage2D(TextureTarget.Texture2D, 0,
                    _region.X, _region.Y, _region.Width, _region.Height,
                    PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                _bmp.UnlockBits(data);

                _region = Rectangle.Empty;
            }
        }

        #endregion

        #region IDisposable Members

        void Dispose(bool manual)
        {
            if (!_isDisposed)
            {
                if (manual)
                {
                    _bmp.Dispose();
                    _gfx.Dispose();
                    if (GraphicsContext.CurrentContext != null)
                        GL.DeleteTexture(_textureId);
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TextRenderer()
        {
            Console.WriteLine(@"Warning Resource leaked: {0}.", typeof(TextRenderer));
        }

        #endregion
    }
}
