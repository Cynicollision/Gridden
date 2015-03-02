using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Gridden
{
    /// <summary>
    /// Utility for manipulating a single Sheet containing images and a Map to put those images on.
    /// </summary>
    public class Editor
    {
        public Editor()
        {
            _currentSheet = SheetFactory.GetBlank();
        }

        private Map _currentMap;
        public Map CurrentMap
        {
            get
            {
                return _currentMap;
            }
            set
            {
                _currentMap = value;
            }
        }

        private Sheet _currentSheet;
        public Sheet CurrentSheet
        {
            get
            {
                return _currentSheet;
            }
            set
            {
                _currentSheet = value;
            }
        }

        /// <summary>
        /// Builds and returns a map of characters to actual drawable Image objects
        /// created from the file names in the current Map.
        /// </summary>
        public List<Sprite> GetSprites()
        {
            return CurrentSheet.Sprites;
        }

        public void SetMapTile(int x, int y, char c)
        {
            _currentMap.SetTile(x, y, c);
        }

        public void ClearMapTile(int x, int y)
        {
            _currentMap.SetTile(x, y, ' ');
        }

        public char GetMapCharAtPosition(int x, int y)
        {
            return _currentMap.GetCharAtPosition(x, y);
        }

        public bool IsMapPositionFree(int x, int y)
        {
            return GetMapCharAtPosition(x, y) == ' ';
        }

        public Image GetImageForCharacter(char c)
        {
            return CurrentSheet.Sprites.Where(r => r.Char == c).First().Image;
        }
    }
}
