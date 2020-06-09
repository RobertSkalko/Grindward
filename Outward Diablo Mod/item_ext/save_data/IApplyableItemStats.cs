using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.item_ext.save_data
{
    public enum StatChangeType
    {
        ADD, REMOVE
    }
    public interface IApplyableItemStats
    {      

        void ChangeItemStats(Equipment item , StatChangeType type);
               
    }
}
