using Gridden.View;
using System;
using System.IO;
using System.Windows.Forms;

namespace Gridden
{
    /// <summary>
    /// Application-level commands driven from menu actions.
    /// </summary>
    public class MenuCommands
    {
        /// <summary>
        /// Menu command: New
        /// </summary>
        public static void SetNewMap()
        {
            var result = MessageBox.Show("Clear the map? Unsaved changes will be lost.", "New map", MessageBoxButtons.YesNo);
            if (result != DialogResult.No)
            {
                MapEditor.Instance.CurrentMap = MapFactory.BuildNew();
                ViewMapProperties();
            }
        }

        /// <summary>
        /// Menu command: Load
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
        /// Menu Command: Save
        /// </summary>
        public static string SaveCurrentMapToFile()
        {
            return MapEditor.Instance.SaveCurrentMapToFile();
        }

        /// <summary>
        /// Menu Command: Map -> Add image
        /// </summary>
        public static void AddImageToSheet()
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                DialogResult dr = ofd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                    {
                        // prompt for single character to use to represent the Sprite.
                        NewSpriteForm form = new NewSpriteForm();
                        form.FileName = ofd.FileName;
                        form.ShowDialog();
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
        }

        /// <summary>
        /// Menu Command: Map Properties
        /// </summary>
        public static void ViewMapProperties()
        {
            int originalWidth = MapEditor.Instance.CurrentMap.MapWidth;
            int originalHeight = MapEditor.Instance.CurrentMap.MapHeight;

            MapPropertiesForm form = new MapPropertiesForm();
            form.Map = MapEditor.Instance.CurrentMap;
            form.ShowDialog();

            // check to see if the Map was resized.
            if (MapEditor.Instance.CurrentMap.MapWidth != originalWidth || MapEditor.Instance.CurrentMap.MapHeight != originalHeight)
            {
                MapEditor.Instance.CurrentMap = MapFactory.CopyWithNewSize(form.Map, form.Map.MapWidth, form.Map.MapHeight);
            }
        }

        /// <summary>
        /// Menu Command: View Text
        /// </summary>
        public static void ViewMapText()
        {
            MapTextViewer form = new MapTextViewer();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SetMapText(MapEditor.Instance.CurrentMap.ToString());
            form.ShowDialog();
        }
    }
}
