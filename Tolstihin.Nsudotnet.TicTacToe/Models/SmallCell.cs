using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SmallCell : Cell
    {
        public SmallCell(int index)
        {
            Index = index;
        }
        private Boolean _available = true;
        public Boolean Available
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
            }
        }
    }
}
