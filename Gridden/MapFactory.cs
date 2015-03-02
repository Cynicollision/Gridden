using System;
using System.IO;

namespace Gridden
{
    public static class MapFactory
    {
        public static Map BuildNew(string name, int w, int h)
        {
            return new Map(name, w, h);
        }

        public static Map FromFile(string fileName)
        {
            try
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                string[] lines = File.ReadAllLines(fileName);
                
                // validation
                if (Validate(name, lines))
                {
                    Map map = BuildNew(name, lines[0].Length, lines.Length);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        for (int j = 0; j < lines[0].Length; j++)
                        {
                            map.SetTile(j, i, lines[i][j]);
                        }
                    }

                    return map;
                }
                else
                {
                    throw new Exception("Invalid map file!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool Validate(string name, string[] lines)
        {
            return true;
        }
    }
}
