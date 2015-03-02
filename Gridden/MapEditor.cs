using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Gridden
{
    /// <summary>
    /// Utility for manipulating a single (current) Map instance at a time.
    /// </summary>
    public class MapEditor
    {
        private Map _currentMap;
        public Map CurrentMap
        {
            get
            {
                return _currentMap;
            }
        }

        /// <summary>
        /// Creates a new Map with the given name, width, and height (in tiles wide/tall).
        /// </summary>
        public void SetNewMap(string name, int w, int h)
        {
            _currentMap = new Map(name, w, h);
        }

        /// <summary>
        /// Saves the current Map to a .txt file with its name.
        /// </summary>
        public void SaveToFile()
        {
            // TODO: write .txt file to \maps\<name>.txt
        }

        /// <summary>
        /// Sets the current map to one built from the given .txt file.
        /// Throws an exception if the file is misformed.
        /// </summary>
        public void LoadFromFile(string fileName)
        {
            // load from the given text file
        }

        /// <summary>
        /// Adds an image with the given fileName to the available sprites for this Map
        /// and assigns the given character c to represent that image.
        /// </summary>
        public void AddSprite(char c, string fileName)
        {
            // add the sprite to the current map
            _currentMap.AddSprite(c, fileName);
        }

        /// <summary>
        /// Builds and returns a map of characters to actual drawable Image objects
        /// created from the file names in the current Map.
        /// </summary>
        public Dictionary<char, Image> GetSprites()
        {
            Dictionary<char, Image> ret = new Dictionary<char, Image>();
            foreach (KeyValuePair<char, string> pair in _currentMap.GetSprites())
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
            return _currentMap.GetCharMap()[x][y] == ' ';
        }

        public char GetCharacterAtPosition(int x, int y)
        {
            return _currentMap.GetCharMap()[x][y];
        }

        public Image GetImageForCharacter(char c)
        {
            return GetSprites()[c];
        }
    }
}
