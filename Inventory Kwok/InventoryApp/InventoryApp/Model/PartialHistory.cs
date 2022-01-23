using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model
{
    public partial class History
    {
        public string GetDate
        {
            get
            {
                return Date.ToString("d");
            }
        }
    }
}
