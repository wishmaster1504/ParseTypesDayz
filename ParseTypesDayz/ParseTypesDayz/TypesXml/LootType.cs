using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTypesDayz.TypesXml
{
    public class LootType
    {
        public string name = string.Empty;
        public int nominal = 0;
        public int lifetime = 0;
        public int restock = 3600;
        public int min = 0;
        public int quantmin = 0;
        public int quantmax = 0;
        public int cost = 100;
        public Flags flags = new Flags();
        public List<Category> categories = new List<Category>();
        public List<Usage> usages = new List<Usage>();
        public List<Value> values = new List<Value>();

        public LootType() { }


    }
}
