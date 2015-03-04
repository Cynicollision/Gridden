
using System;
using System.IO;
namespace Gridden
{
    /// <summary>
    /// Singleton utility for manipulating a single Map instance.
    /// </summary>
    public class MapEditor
    {
        // Singleton instance
        private static MapEditor _instance;
        public static MapEditor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapEditor();
                }
                return _instance;
            }
        }

        private MapEditor()
        {
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

        private int _selectedSpriteIndex;
        public int SelectedSpriteIndex
        {
            get
            {
                return _selectedSpriteIndex;
            }
            set
            {
                _selectedSpriteIndex = value;
            }
        }
        #endregion

        /// <summary>
        /// Sets the tile at position (x, y) in the current map to the given character c.
        /// </summary>
        public void SetMapTile(int x, int y, char c)
        {
            CurrentMap.SetCharAtPosition(x, y, c);
        }

        /// <summary>
        /// Clears the tile at position (x, y) in the current map (blank space).
        /// </summary>
        public void ClearMapTile(int x, int y)
        {
            CurrentMap.SetCharAtPosition(x, y, ' ');
        }

        /// <summary>
        /// Returns the character in the current map at position (x, y).
        /// </summary>
        public char GetMapCharAtPosition(int x, int y)
        {
            return CurrentMap.GetCharAtPosition(x, y);
        }

        /// <summary>
        /// Returns true if the character in the current map is empty (a blank space).
        /// </summary>
        public bool IsMapPositionFree(int x, int y)
        {
            return GetMapCharAtPosition(x, y) == ' ';
        }

        /// <summary>
        /// Menu command: Map -> Save
        /// Returns the name of the .txt file it saved as.
        /// </summary>
        public string SaveCurrentMapToFile()
        {
            string mapFileName = GetMapFileNameForSave(CurrentMap);

            string mapsDirectory = Path.Combine(Environment.CurrentDirectory, "maps");
            if (!Directory.Exists(mapsDirectory))
            {
                Directory.CreateDirectory(mapsDirectory);
            }

            string fullFileName = Path.Combine(mapsDirectory, mapFileName);
            File.WriteAllText(fullFileName, CurrentMap.Name + "\r\n" + CurrentMap.ToString());
            return mapFileName;
        }

        /// <summary>
        /// Returns the .txt file name to save the map as.
        /// </summary>
        private string GetMapFileNameForSave(Map map)
        {
            return map.Name.Replace(' ', '_') + ".txt";
        }
    }
}
