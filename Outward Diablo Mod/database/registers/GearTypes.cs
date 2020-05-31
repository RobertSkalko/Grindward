using outward_diablo.database.gear_types;
using outward_diablo.database.gear_types.weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.registers
{
    public class GearTypes
    {
        public static GearTypes Instance;

        public GearTypes()
        {
            armors = new List<GearType>{ helmet,chest, boots };
            weapons = new List<GearType> { oneHandWeapon, twoHandWeapon };           
        }

           

        public GearType helmet = Registry.GearTypes.Register(new Helmet());
        public GearType chest = Registry.GearTypes.Register(new Chest());
        public GearType boots = Registry.GearTypes.Register(new Boots());
     
        public GearType oneHandWeapon = Registry.GearTypes.Register(new OneHandWeapon());
        public GearType twoHandWeapon = Registry.GearTypes.Register(new TwoHandWeapon());

        public List<GearType> armors;
        public List<GearType> weapons;


    }



}
