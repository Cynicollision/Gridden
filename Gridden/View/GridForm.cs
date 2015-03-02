using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gridden
{
    public partial class GridForm : Form
    {
        private int _selectedSprite = 0; // TODO: map editor property?
        private MapEditor _editor = MapEditor.Instance;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GridForm()
        {
            InitializeComponent();

            // an empty map.
            _editor.CurrentMap = MapFactory.BuildNew();

            // testing only... SheetFactory.GetBlank(); for no sprites
            //_editor.CurrentSheet = SheetFactory.GetBlank();
            _editor.CurrentSheet = SheetFactory.BuildFromSpriteList(new List<Sprite> {
                new Sprite('s', "sun.jpg"),
                new Sprite('e', "enemy.png"),
                new Sprite('f', "flag.png"),
                new Sprite('w', "stone.png")
            });

            // setup form components
            RefreshDisplay();
        }

        #region Properties

        private int GridWidth
        {
            get
            {
                return _editor.CurrentMap.MapWidth;
            }
        }

        private int GridHeight
        {
            get
            {
                return _editor.CurrentMap.MapHeight;
            }
        }

        #endregion

        #region Menu event handlers

        // Map -> New
        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MenuCommands.SetNewMap();
            RefreshDisplay();
        }

        // Map -> Save
        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string fileName = MenuCommands.SaveMapToFile(_editor.CurrentMap);
            SetFormStatusText(String.Format("Saved successfully as {0}!", fileName));
        }

        // Map -> Load
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // loadedMap is null if user clicks "Cancel" in open dialog.
            Map loadedMap = MenuCommands.LoadMapFromFile();
            if (loadedMap != null)
            {
                _editor.CurrentMap = loadedMap;
                RefreshDisplay();
            }
        }

        // Map -> Map Properties
        private void mapPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuCommands.ViewMapProperties();
            RefreshDisplay();
        }

        // Map -> View Text
        private void viewTextToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MenuCommands.ViewMapText();

        }

        #endregion

        #region Mouse event handlers



        private void spritePanel_MouseClick(object sender, MouseEventArgs e)
        {
            // set the selected sprite to the one that was clicked on.
            for (int i = 0; i < _editor.GetSprites().Count; i++)
            {
                int baseX = 2;
                int baseY = 2;
                if (e.X > baseX + (i * (Sprite.Size + 2)) && e.X < baseX + (Sprite.Size + (i * (Sprite.Size + 2))) && e.Y > baseY && e.Y < baseY + Sprite.Size)
                {
                    _selectedSprite = i;
                    this.spritePanel.Invalidate();
                }
            }
        }

        private void paintPanel_Click(object sender, MouseEventArgs e)
        {
            if (_selectedSprite >= 0)
            {
                int tileX = e.X / Map.TileSize;
                int tileY = e.Y / Map.TileSize;

                if (e.Button == MouseButtons.Left)
                {
                    char c = _editor.GetSprites().Where(r => r.Index == _selectedSprite).First().Char;
                    _editor.SetMapTile(tileX, tileY, c);
                }
                else
                {
                    if (!_editor.IsMapPositionFree(tileX, tileY))
                    {
                        _editor.ClearMapTile(tileX, tileY);
                    }
                }

                RefreshDisplay();
            }
        }

        /// <summary>
        /// Hovering over the paint panel.
        /// </summary>
        private void paintPanel_MouseHover(object sender, System.EventArgs e)
        {
            Point point = this.paintPanel.PointToClient(Cursor.Position);
            SetFormStatusText(point.ToString());
            // TODO:
        }

        #endregion

        #region Paint event handlers

        private void spritePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            List<Sprite> sprites = _editor.GetSprites();

            if (sprites.Count > 0)
            {
                // draw the tile selector.
                SolidBrush brush = new SolidBrush(Color.Blue);
                Rectangle r = new Rectangle(_selectedSprite * (Sprite.Size + 2), 0, Sprite.Size + 4, Sprite.Size + 4);
                g.FillRectangle(brush, r);

                int baseX = 2;
                int baseY = 2;
                for (int i = 0; i < sprites.Count; i++)
                {
                    // set scale and opacity.
                    Image img = ImageEditor.ScaleImage(sprites[i].Image, Sprite.Size, Sprite.Size);
                    if (i != _selectedSprite)
                    {
                        img = ImageEditor.SetImageOpacity(img, 0.5f);
                    }

                    g.DrawImage(img, new Point(baseX + i * (Sprite.Size + 2), baseY));
                }
            }
        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // draw grid lines
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < GridWidth; i++)
            {
                g.DrawLine(p, new Point(i * Map.TileSize, 0), new Point(i * Map.TileSize, Map.TileSize * GridHeight));
                for (int j = 0; j < GridHeight; j++)
                {
                    g.DrawLine(p, new Point(0, j * Map.TileSize), new Point(Map.TileSize * GridWidth, j * Map.TileSize));
                }
            }

            // draw the map
            for (int i = 0; i < GridWidth; i++)
            {
                for (int j = 0; j < GridHeight; j++)
                {

                    if (!_editor.IsMapPositionFree(i, j))
                    {
                        char c = _editor.GetMapCharAtPosition(i, j);
                        g.DrawImage(ImageEditor.ScaleImage(_editor.GetImageForCharacter(c), Map.TileSize, Map.TileSize), i * Map.TileSize, j * Map.TileSize);
                    }
                }
            }
        }

        #endregion

        private void RefreshDisplay()
        {
            Map currentMap = MapEditor.Instance.CurrentMap;

            // update the form title.
            this.Text = "Gridden: " + currentMap.Name;

            // resize and redraw the map editor.
            this.paintPanel.Size = new Size(currentMap.MapWidth * Map.TileSize, currentMap.MapHeight * Map.TileSize);
            this.paintPanel.Invalidate();
        }


    
        public void SetFormStatusText(string text)
        {
            this.toolStripStatusLabel.Text = text;
        }
    }
}
