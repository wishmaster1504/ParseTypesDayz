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


        public string CategoryToString()
        {
            string tmpStr = string.Empty;
             

            foreach (Category item in categories)
            {
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    tmpStr += ", ";
                }
                
                tmpStr += item.name;
            }
            
             
            return tmpStr;
        }

        public string UsagesToString()
        {
             
            string tmpStr = string.Empty;


            foreach (var item in usages)
            {
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    tmpStr += ", ";
                }
                 
                tmpStr += item.name;
            }


            return tmpStr;
        }

        public string ValuesToString() {

            string tmpStr = string.Empty;


            foreach (var item in values)
            {
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    tmpStr += ", ";
                }
                 
                tmpStr += item.name;
            }


            return tmpStr;
        }

        public string LootTypeToString()
        {
            return $"{name}; {nominal}; {lifetime}; {restock}; {min}; {quantmin}; {quantmax}; {cost}; {flags.FlagsToString()}; {CategoryToString()}; {UsagesToString()}; {ValuesToString()};";
        }
    }


}
