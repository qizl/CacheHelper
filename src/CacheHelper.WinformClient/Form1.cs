using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.EnjoyCodes.CacheHelper.WinformClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string key = "a";
            object value = 123;
            CacheHelper.Insert(key, value);
            var result = CacheHelper.Get(key);
        }
    }
}
