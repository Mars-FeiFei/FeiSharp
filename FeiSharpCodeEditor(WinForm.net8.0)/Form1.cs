using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeiSharpStudio
{

    public class Item : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // A simple collection (e.g., List of strings)


            BindingList<Item> items = new BindingList<Item> { new Item() { Name="App"} };
            listBox1.DisplayMember = "Name";

            // Set the DataSource of the ListBox to the List
            listBox1.DataSource = items;

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            //listBox1.DrawItem += LineNumberListBox_DrawItem;
            //listBox1.MouseWheel += LineNumberListBox_VScroll;
        }
    }
}
