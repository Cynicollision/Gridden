using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Gridden
{
    /// <summary>
    /// Utility for manipulating a single (current) Map instance at a time.
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
        }

        private Sheet _currentSheet;
        public Sheet CurrentSheet
        {
            get
            {
                return _currentSheet;
            }
        }

        public void SetSheet(Sheet s)
        {
            _currentSheet = s;
        }

        public void SetMap(Map m)
        {
            _currentMap = m;
        }



        /// <summary>
        /// Builds and returns a map of characters to actual drawable Image objects
        /// created from the file names in the current Map.
        /// </summary>
        public List<Sprite> GetSprites()
        {
            return CurrentSheet.Sprites;
        }

        public void SetTile(int x, int y, char c)
        {
            _currentMap.SetTile(x, y, c);
        }

        public void ClearTile(int x, int y)
        {
            _currentMap.SetTile(x, y, ' ');
        }

        public bool IsMapPositionFree(int x, int y)
        {
            return _currentMap.GetCharAtPosition(x, y) == ' ';
        }

        public char GetCharacterAtPosition(int x, int y)
        {
            return _currentMap.GetCharAtPosition(x, y);
        }

        public Image GetImageForCharacter(char c)
        {
            return CurrentSheet.Sprites.Where(r => r.Char == c).First().Image;
        }
    }
}
