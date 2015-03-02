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
    public class MapEditor
    {
        private static MapEditor instance;

        private MapEditor()
        {
            _currentSheet = SheetFactory.GetBlank();
        }

        public static MapEditor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapEditor();
                }
                return instance;
            }
        }

        #region Public properties

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

        #endregion

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
            CurrentMap.SetCharAtPosition(x, y, c);
        }

        public void ClearMapTile(int x, int y)
        {
            CurrentMap.SetCharAtPosition(x, y, ' ');
        }

        public char GetMapCharAtPosition(int x, int y)
        {
            return CurrentMap.GetCharAtPosition(x, y);
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
