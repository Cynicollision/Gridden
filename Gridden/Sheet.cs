using System;
using System.Collections.Generic;
using System.IO;

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

        private string _dir;
        public string Directory
        {
            get
            {
                _dir = Path.Combine(Environment.CurrentDirectory, "sheets", _name.Replace(' ', '_'));
                return _dir;
            }
            set
            {
                _dir = value;
            }
        }

        private int _currentIdx;
        private int NextIndex
        {
            get
            {
                return _currentIdx++;
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
            set
            {
                _currentIdx = 0;
                _sprites = value;

                // set indices.
                foreach (Sprite s in _sprites)
                {
                    s.Index = NextIndex;
                }
            }
        }

        #endregion

    }
}
