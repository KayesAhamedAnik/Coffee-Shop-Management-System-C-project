using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.CoffeeShop.Gui
{
    public partial class ucHome : UserControl
    {
        public ucHome()
        {
            InitializeComponent();
        }
        private static ucHome _Instance;
        public static ucHome instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucHome();
                return _Instance;
            }
        }
    }
}
