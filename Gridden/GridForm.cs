using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gridden
{
    public partial class GridForm : Form
    {
        private int _spriteSize = 32;
        private int _selectedSprite = 0;
        private MapEditor _mapEditor;

        public GridForm()
        {
            InitializeComponent();

            // default values:
            _tileSize = 64;
            _spriteSize = 32;

            _mapEditor = new MapEditor();
            _mapEditor.SetNewMap("test map", 16, 12);
            _mapEditor.AddSprite('s', "sun.jpg");
            _mapEditor.AddSprite('e', "enemy.png");
            _mapEditor.AddSprite('f', "flag.png");
            _mapEditor.AddSprite('w', "stone.png");

            // setup
            SetFormTitle(_mapEditor.CurrentMap.Name);
            SetGridDimensions(16, 12);
        }

        #region Public properties

        private int _gridWidth;
        public int GridWidth
        {
            get
            {
                return _gridWidth;
            }
            set
            {
                _gridWidth = value;
            }
        }

        private int _gridHeight;
        public int GridHeight
        {
            get
            {
                return _gridHeight;
            }
            set
            {
                _gridHeight = value;
            }
        }

        private int _tileSize;
        public int TileSize
        {
            get
            {
                return _tileSize;
            }
        }

        #endregion

        #region Mouse event handlers

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _mapEditor.SaveToFile();
        }

        private void viewTextToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MapTextViewer viewerForm = new MapTextViewer();
            viewerForm.SetText(_mapEditor.CurrentMap.ToString());
            viewerForm.ShowDialog();
        }

        private void spritePanel_MouseClick(object sender, MouseEventArgs e)
        {
            // set the selected sprite to the one that was clicked on.
            for (int i = 0; i < _mapEditor.GetSprites().Count; i++)
            {
                int baseX = 2;
                int baseY = 2;
                if (e.X > baseX + (i * (_spriteSize + 2)) && e.X < baseX + (_spriteSize + (i * (_spriteSize + 2))) && e.Y > baseY && e.Y < baseY + _spriteSize)
                {
                    _selectedSprite = i;
                    this.spritePanel.Invalidate();
                }
            }
        }

        private void paintPanel_Click(object sender, MouseEventArgs e)
        {
            int tileX = e.X / _tileSize;
            int tileY = e.Y / _tileSize;

            if (_mapEditor.IsPositionFree(tileX, tileY))
            {
                char c = _mapEditor.GetSprites().ElementAt(_selectedSprite).Key;
                _mapEditor.SetTile(tileX, tileY, c);
            }
            else
            {
                _mapEditor.ClearTile(tileX, tileY);
            }

            this.paintPanel.Invalidate();
        }

        #endregion

        #region Paint event handlers

        private void spritePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var sprites = _mapEditor.GetSprites();

            // draw the tile selector.
            SolidBrush brush = new SolidBrush(Color.Blue);
            Rectangle r = new Rectangle(_selectedSprite * (_spriteSize + 2), 0, _spriteSize + 4, _spriteSize + 4);
            g.FillRectangle(brush, r);

            int baseX = 2;
            int baseY = 2;
            for (int i = 0; i < sprites.Values.Count; i++)
            {
                // set scale and opacity.
                Image img = ImageEditor.ScaleImage(sprites.ElementAt(i).Value, _spriteSize, _spriteSize);
                if (i != _selectedSprite)
                {
                    img = ImageEditor.SetImageOpacity(img, 0.5f);
                }

                g.DrawImage(img, new Point(baseX + i * (_spriteSize + 2), baseY));
            }
        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            var sprites = _mapEditor.GetSprites();
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // draw grid lines
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < _gridWidth; i++)
            {
                g.DrawLine(p, new Point(i * _tileSize, 0), new Point(i * _tileSize, _tileSize * _gridHeight));
                for (int j = 0; j < _gridHeight; j++)
                {
                    g.DrawLine(p, new Point(0, j * _tileSize), new Point(_tileSize * _gridWidth, j * _tileSize));
                }
            }

            // draw the map
            for (int i = 0; i < _gridWidth; i++)
            {
                for (int j = 0; j < _gridHeight; j++)
                {

                    if (!_mapEditor.IsPositionFree(i, j))
                    {
                        char c = _mapEditor.GetCharacterAtPosition(i, j);
                        g.DrawImage(ImageEditor.ScaleImage(_mapEditor.GetImageForCharacter(c), _tileSize, _tileSize), i * _tileSize, j * _tileSize);
                    }
                }
            }
        }

        #endregion

        public void SetGridDimensions(int tilesWide, int tilesTall)
        {
            _gridWidth = tilesWide;
            _gridHeight = tilesTall;
            this.paintPanel.Size = new Size(_gridWidth * _tileSize, _gridHeight * _tileSize);
        }

        public void SetFormTitle(string title)
        {
            this.Text = "Gridden: " + title;
        }

        public void SetFormStatusText(string text)
        {
            this.toolStripStatusLabel.Text = text;
        }

        private void paintPanel_MouseHover(object sender, System.EventArgs e)
        {
            Point point = this.paintPanel.PointToClient(Cursor.Position);
            SetFormStatusText(point.ToString());
            
        }
    }
}
