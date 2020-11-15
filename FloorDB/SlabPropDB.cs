using Floor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.FloorDB
{
    class SlabPropDB
    {
        private List<SlabProp> slabProps;

        public List<SlabProp> SlabProps { get => slabProps; set => slabProps = value; }

        public SlabPropDB(List<SlabProp> slabProps)
        {
            SlabProps = slabProps;
        }

        public SlabPropDB()
        {
        }
        public SlabProp GetSlabPropByText(string text)
        {
            SlabProp SlabProp = new SlabProp();
            foreach(SlabProp slab in SlabProps)
            {
                try
                {
                    if (slab.Area.Equals(text)) SlabProp = slab;
                }
                catch(Exception e) {  }
            }
          
            return SlabProp;
        }
      
    }
}
