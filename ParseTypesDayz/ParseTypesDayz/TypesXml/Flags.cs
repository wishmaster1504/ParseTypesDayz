using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTypesDayz.TypesXml
{
    public class Flags
    {
        public int count_in_cargo = 0;
        public int count_in_hoarder = 0;
        public int count_in_map = 0;
        public int count_in_player = 0;
        public int crafted = 0;
        public int deloot = 0;

        public Flags() { }


        public string FlagsToString()
        {
            return $"count_in_cargo = {count_in_cargo}; count_in_hoarder = {count_in_hoarder}; count_in_map = {count_in_map}; count_in_player = {count_in_player}; crafted = {crafted}; deloot = {deloot}";
        }
    }
}
