using System;
using System.IO;

namespace Gridden
{
    /// <summary>
    /// Factoray class that provides various ways of generating new Map objects.
    /// </summary>
    public static class MapFactory
    {
        private const string DefaultMapTitle = "New map";
        private const int DefaultMapWidth = 12;
        private const int DefaultMapHeight = 8;

        /// <summary>
        /// Builds and returns a new Map objects with the application defaults (hard-coded).
        /// </summary>
        public static Map BuildNew()
        {
            return new Map(DefaultMapTitle, DefaultMapWidth, DefaultMapHeight);
        }

        /// <summary>
        /// Builds and returns a new Map objects as specified.
        /// </summary>
        public static Map BuildNew(string name, int w, int h)
        {
            return new Map(name, w, h);
        }

        /// <summary>
        /// Builds and returns a new Map object generated from the given .txt file (full file name).
        /// Throws an exception if the file can't be read!
        /// </summary>
        public static Map FromFile(string fileName)
        {
            try
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                string[] lines = File.ReadAllLines(fileName);
                
                // making assumption that the name is on line 0, map starts on line 1, and map rows are the same length (a box).
                Map map = BuildNew(lines[0], lines[1].Length, lines.Length - 1);
                for (int i = 1; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        map.SetCharAtPosition(j, i - 1, lines[i][j]);
                    }
                }

                return map;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Map CopyWithNewSize(Map original, int newWidth, int newHeight)
        {
            char[][] originalCharMap = original.CharMap;

            Map copy = new Map(original.Name, newWidth, newHeight);
            copy.CharMap = new char[newWidth][];
            for (int i = 0; i < newWidth; i++)
            {
                copy.CharMap[i] = new char[newHeight];
                for (int j = 0; j < newHeight; j++)
                {
                    if (i < originalCharMap.Length && j < originalCharMap[i].Length)
                    {
                        copy.CharMap[i][j] = originalCharMap[i][j];
                    }
                    else
                    {
                        copy.CharMap[i][j] = ' ';
                    }
                }
            }

            return copy;
        }
    }
}
