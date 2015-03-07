using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gridden
{
    /// <summary>
    /// A named collection of Sprite instances.
    /// </summary>
    public class Sheet
    {
        #region Public properties

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private List<Sprite> _sprites;
        public List<Sprite> Sprites
        {
            get
            {
                if (_sprites == null)
                {
                    _sprites = new List<Sprite>();
                }
                return _sprites;
            }
        }

        #endregion

        /// <summary>
        /// Adds a new Sprite to the collection with the given character c and source file name.
        /// </summary>
        public void AddNewSprite(char c, string fileName)
        {
            Sprite newSprite = new Sprite(c, fileName);
            newSprite.Index = _sprites.Count;
            _sprites.Add(newSprite);
        }

        /// <summary>
        /// Reassigns all Sprite's indices starting at 0.
        /// </summary>
        private void ReassignSpriteIndices()
        {
            int currentIdx = 0;
            foreach (Sprite s in _sprites)
            {
                s.Index = currentIdx++;
                s.UpdateFileName();
            }
        }

        /// <summary>
        /// Removes the given Sprite object from the collection.
        /// </summary>
        public void RemoveSprite(int index)
        {
            Sprite toDelete = _sprites.Where(r => r.Index == index).First();

            // remove from Sprite collection
            _sprites.Remove(toDelete);
            toDelete.Image.Dispose();

            if (File.Exists(toDelete.FileName))
            {
                File.Delete(toDelete.FileName);
            }

            ReassignSpriteIndices();
        }
    }
}
