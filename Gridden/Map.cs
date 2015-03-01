using System.Collections.Generic;

namespace Gridden
{
    public class Values
    {
        private string _name;
        private string _path;
        private char[][] _map;
        private int _mapWidth;
        private int _mapHeight;
        private Dictionary<char, string> _sprites;

        public Values(int w, int h)
        {
            _map = new char[w][];
            for (int i = 0; i < w; i ++)
            {
                _map[i] = new char[h];
                for (int j = 0; j < h; j++)
                {
                    _map[i][j] = ' ';
                }
            }

            _mapWidth = w;
            _mapHeight = h;
            _sprites = new Dictionary<char, string>();
        }

        #region Public properties

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

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public char[][] CharMap
        {
            get
            {
                return _map;
            }
        }

        public Dictionary<char, string> Sprites
        {
            get
            {
                return _sprites;
            }
        }

        #endregion

        public void SetTile(int x, int y, char c)
        {
            _map[x][y] = c;
        }

        public void AddSprite(char c, string fileName)
        {
            _sprites.Add(c, fileName);
        }


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
