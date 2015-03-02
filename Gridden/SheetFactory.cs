using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridden
{
    public static class SheetFactory
    {
        public static Sheet GetBlank()
        {
            return new Sheet(new List<Sprite>());
        }
    }
}
