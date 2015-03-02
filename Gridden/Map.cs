using System.Collections.Generic;

namespace Gridden
{
    /// <summary>
    /// Internal representation of the map data itself: its name and a matrix of letters corresponding
    /// to which tiles go where in the generated text.
    /// </summary>
    public class Map
    {
        private char[][] _map;
        private Dictionary<char, string> _sprites;

        /// <summary>
        /// Constructor.
        /// Intantiates a new Map with the given name and dimensions (how many tiles wide/tall).
        /// </summary>
        public Map(string name, int w, int h)
        {
            _sprites = new Dictionary<char, string>();

            // blank space means empty tile.
            _map = new char[w][];
            for (int i = 0; i < w; i ++)
            {
                _map[i] = new char[h];
                for (int j = 0; j < h; j++)
                {
                    _map[i][j] = ' ';
                }
            }

            _name = name;
            _mapWidth = w;
            _mapHeight = h;
        }

        #region Public properties
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private int _mapWidth;
        public int MapWidth
        {
            get
            {
                return _mapWidth;
            }
            set
            {
                _mapWidth = value;
            }
        }

        private int _mapHeight;
        public int MapHeight
        {
            get
            {
                return _mapHeight;
            }
            set
            {
                _mapHeight = value;
            }
        }

        #endregion

        /// <summary>
        /// Sets the tile in the given (x, y) position to character c.
        /// </summary>
        public void SetTile(int x, int y, char c)
        {
            _map[x][y] = c;
        }

        /// <summary>
        /// Returns the character matrix that represents the map.
        /// </summary>
        public char[][] GetCharMap()
        {
            return _map;
        }

        /// <summary>
        /// Adds an image with the given fileName to the available sprites for this map
        /// and assigns the given character c to represent that image.
        /// </summary>
        public void AddSprite(char c, string fileName)
        {
            _sprites.Add(c, fileName);
        }

        /// <summary>
        /// Return the character -> fileName map of images for tiles.
        /// </summary>
        public Dictionary<char, string> GetSprites()
        {
            return _sprites;
        }

        /// <summary>
        /// ToString override to format the map visually as depicted in the grid editor
        /// using the assigned characters to represent each tile.
        /// </summary>
        public override string ToString()
        {
            string retVal = "";

            for (int i = 0; i < _map[0].Length; i++)
            {
                for (int j = 0; j < _map.Length; j++)
                {
                    retVal += _map[j][i].ToString();
                }
                retVal += "\r\n";
            }

            return retVal;
        }
    }
}
