using Gridden.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gridden
{
    /// <summary>
    /// Application-level commands, mostly driven from menu actions.
    /// </summary>
    public class MenuCommands
    {
        private const string SheetFileName = "sheets.xml";
        private const string SheetFileDirectory = "sheets";

        /// <summary>
        /// Menu command: Map -> New
        /// </summary>
        public static void SetNewMap()
        {
            var result = MessageBox.Show("Clear the map? Unsaved changes will be lost.", "New map", MessageBoxButtons.YesNo);
            if (result != DialogResult.No)
            {
                MapEditor.Instance.CurrentMap = MapFactory.BuildNew();
            }
        }

        /// <summary>
        /// Menu command: Map -> Save
        /// Returns the name of the .txt file it saved as.
        /// </summary>
        public static string SaveMapToFile(Map map)
        {
            string mapFileName = GetMapFileNameForSave(map);

            string mapsDirectory = Path.Combine(Environment.CurrentDirectory, "maps");
            if (!Directory.Exists(mapsDirectory))
            {
                Directory.CreateDirectory(mapsDirectory);
            }

            string fullFileName = Path.Combine(mapsDirectory, mapFileName);
            File.WriteAllText(fullFileName, map.Name + "\r\n" + map.ToString());
            return mapFileName;
        }

        /// <summary>
        /// Returns the .txt file name to save the map as.
        /// </summary>
        private static string GetMapFileNameForSave(Map map)
        {
           return map.Name.Replace(' ', '_') + ".txt";
        }

        /// <summary>
        /// Menu command: Map -> Load
        /// Prompts the user to browse for a .txt file to select to load as the map.
        /// </summary>
        public static Map LoadMapFromFile()
        {
            Map map = null;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Documents (*.txt)|*.txt";
                DialogResult dr = ofd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                    {
                        map = MapFactory.FromFile(ofd.FileName);
                    }
                    else
                    {
                        throw new Exception("Selected file does not exist!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return map;
        }

        /// <summary>
        /// Menu Command: Map -> Map Properties
        /// </summary>
        public static void ViewMapProperties()
        {
            int originalWidth = MapEditor.Instance.CurrentMap.MapWidth;
            int originalHeight = MapEditor.Instance.CurrentMap.MapHeight;

            MapInfoForm form = new MapInfoForm();
            form.Map = MapEditor.Instance.CurrentMap;
            form.ShowDialog();

            // check to see if the Map was resized.
            if (MapEditor.Instance.CurrentMap.MapWidth != originalWidth || MapEditor.Instance.CurrentMap.MapHeight != originalHeight)
            {
                MapEditor.Instance.CurrentMap = MapFactory.CopyWithNewSize(form.Map, form.Map.MapWidth, form.Map.MapHeight);
            }
        }

        /// <summary>
        /// Menu Command: Map -> View Text
        /// </summary>
        public static void ViewMapText()
        {
            MapTextViewer form = new MapTextViewer();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SetMapText(MapEditor.Instance.CurrentMap.ToString());
            form.ShowDialog();
        }

        /// <summary>
        /// Saves all sheets managed by the application to the .xml file.
        /// </summary>
        public static void SaveSheetsToFile()
        {
            try
            {
                // create the directory if it does not exist.
                string dir = Path.Combine(Environment.CurrentDirectory, SheetFileDirectory);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                XmlSerializer xml = new XmlSerializer(typeof(List<Sheet>));
                TextWriter fs = new StreamWriter(Path.Combine(dir, SheetFileName));
                xml.Serialize(fs, SheetEditor.Instance.Sheets);
                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Failed saving sheets to .xml!", e);
            }
        }
    }
}
