using System.Collections.Generic;
using System.Drawing;

namespace Gridden
{
    class MapEditor
    {
        private Values _currentMap;

        public Values CurrentMap
        {
            get
            {
                return _currentMap;
            }
        }

        public void SetNewMap(int w, int h)
        {
            _currentMap = new Values(w, h);
        }

        public void SaveToFile()
        {
            // TODO: write .txt file to \maps\<name>.txt
        }

        public void LoadFromFile()
        {
            // load from the given text file
        }

        public void AddSprite(char c, string fileName)
        {
            // add the sprite to the current map
            _currentMap.AddSprite(c, fileName);
        }

        public Dictionary<char, Image> GetSprites()
        {
            Dictionary<char, Image> ret = new Dictionary<char, Image>();
            foreach (KeyValuePair<char, string> pair in _currentMap.Sprites)
            {
                ret.Add(pair.Key, Image.FromFile(pair.Value));
            }
            return ret;
        }

        public void SetTile(int x, int y, char c)
        {
            _currentMap.SetTile(x, y, c);
        }

        public void ClearTile(int x, int y)
        {
            _currentMap.SetTile(x, y, ' ');
        }

        public bool IsPositionFree(int x, int y)
        {
            return _currentMap.CharMap[x][y] == ' ';
        }

        public char GetCharacterAtPosition(int x, int y)
        {
            return _currentMap.CharMap[x][y];
        }

        public Image GetImageForCharacter(char c)
        {
            return GetSprites()[c];
        }
    }
}
