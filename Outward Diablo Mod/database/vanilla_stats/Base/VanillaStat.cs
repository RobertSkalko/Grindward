using grindward.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace grindward.database
{
    public abstract class VanillaStat : RegistryEntry , IComparable<VanillaStat>
    {
      
        string id;
        int place;

        public Type StatType;


        public VanillaStat(String id, int place, Type StatType)
        {
            this.id = id;
            this.place = place;
            this.StatType =  StatType;
        }

        public int GetPlace()
        {
            return place;
        }     
        

        public abstract void SetStat(Equipment item, float val);
        public abstract float GetStat(Equipment item);
        public  string GetId()
        {
            return id;
        }

        public int CompareTo(VanillaStat other)
        {
            return GetPlace().CompareTo(other.GetPlace());
        }

        public void TestIfWorks(Equipment item)
        {
            try
            {
                //Log.Debug(GetId() + " starting test on " + item.Name);

                int num = 32;

                //Log.Debug(GetId() + " setting");

                SetStat(item, num);

                //Log.Debug(GetId() + " getting");

                int after = (int)GetStat(item);

                if (num != after)
                {
                    Log.Print("[ERROR] " + GetId() + " stat doesn't appear to correctly get or set values!");
                }
                else
                {
                    Log.Debug(GetId() + " stat works fine");
                }
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        public enum Type
        {
           WeaponStat, ArmorStat, GearStat
        }
    }
}
