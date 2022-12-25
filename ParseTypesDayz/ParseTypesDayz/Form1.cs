using ParseTypesDayz.TypesXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ParseTypesDayz
{
    public partial class Form1 : Form
    {
        public string fileName;
        List<LootType> types = new List<LootType>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Выбор xml файла types";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fileName= openFileDialog1.FileName;

                listBox1.Items.Add($"Выбран файл: {fileName}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ParseXml(fileName);
        }

        //-------------------
        public void ParseXml(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if(xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach(XmlElement node in xRoot.ChildNodes) {

                    LootType lootType= new LootType();

                    XmlNode attr = node.Attributes.GetNamedItem("name");
                    //listBox1.Items.Add($"name: { attr.Value}");
                    lootType.name = attr.Value;

                    foreach (XmlNode childnode in node.ChildNodes) {

                        if (childnode.Name == "nominal")
                        {
                            //listBox1.Items.Add($"nominal: {childnode.InnerText}");
                            lootType.nominal = int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "lifetime")
                        {
                            //listBox1.Items.Add($"lifetime: {childnode.InnerText}");
                            lootType.lifetime= int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "restock")
                        {
                            //listBox1.Items.Add($"restock: {childnode.InnerText}");
                            lootType.restock= int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "min")
                        {
                            //listBox1.Items.Add($"min: {childnode.InnerText}");
                            lootType.min= int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "quantmin")
                        {
                            //listBox1.Items.Add($"quantmin: {childnode.InnerText}");
                            lootType.quantmin= int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "quantmax")
                        {
                            //listBox1.Items.Add($"quantmax: {childnode.InnerText}");
                            lootType.quantmax= int.Parse(childnode.InnerText);
                        }

                        if (childnode.Name == "cost")
                        {
                            //listBox1.Items.Add($"cost: {childnode.InnerText}");
                            lootType.cost= int.Parse(childnode.InnerText);
                        }


                        // flags
                        if (childnode.Name == "flags")
                        {
                            //listBox1.Items.Add($"flags:");

                            Flags flag = new Flags();

                            XmlNode flags = childnode.Attributes.GetNamedItem("count_in_cargo");
                            //listBox1.Items.Add($"count_in_cargo: {flags.Value}");
                            flag.count_in_cargo = int.Parse(flags.Value);

                            flags = childnode.Attributes.GetNamedItem("count_in_hoarder");
                            //listBox1.Items.Add($"count_in_hoarder: {flags.Value}");
                            flag.count_in_hoarder = int.Parse(flags.Value);

                            flags = childnode.Attributes.GetNamedItem("count_in_map");
                            //listBox1.Items.Add($"count_in_map: {flags.Value}");
                            flag.count_in_map = int.Parse(flags.Value);

                            flags = childnode.Attributes.GetNamedItem("count_in_player");
                            //listBox1.Items.Add($"count_in_player: {flags.Value}");
                            flag.count_in_player = int.Parse(flags.Value);

                            flags = childnode.Attributes.GetNamedItem("crafted");
                            //listBox1.Items.Add($"crafted: {flags.Value}");
                            flag.crafted= int.Parse(flags.Value);

                            flags = childnode.Attributes.GetNamedItem("deloot");
                            //listBox1.Items.Add($"deloot: {flags.Value}");
                            flag.deloot= int.Parse(flags.Value);

                            lootType.flags = flag;
                        }
                          
                        if (childnode.Name == "category")
                        { 
                            XmlNode categ = childnode.Attributes.GetNamedItem("name");
                            //listBox1.Items.Add($"category: {categ.Value}");

                            Category category = new Category(categ.Value);
                            lootType.categories.Add(category);
                        }

                        if (childnode.Name == "usage")
                        {
                            XmlNode usage = childnode.Attributes.GetNamedItem("name");
                            //listBox1.Items.Add($"usage: {usage.Value}");

                            Usage usagetmp= new Usage(usage.Value);
                            lootType.usages.Add(usagetmp);
                        }

                        if (childnode.Name == "value")
                        {
                            XmlNode val = childnode.Attributes.GetNamedItem("name");
                            //listBox1.Items.Add($"value: {val.Value}");

                            Value valtmp = new Value(val.Value);
                            lootType.values.Add(valtmp);

                        }

                    }


                    types.Add(lootType);

                }


                // вывод списка
                listBox1.Items.Add($"Всего элементов: {types.Count}");

                listBox1.Items.Add("---------------");
                 

                // выведем список всех объектов
                foreach (var item in types)
                {
                    listBox1.Items.Add(item.name);

                }

            } // if(xRoot != null)
        }

    }
}
