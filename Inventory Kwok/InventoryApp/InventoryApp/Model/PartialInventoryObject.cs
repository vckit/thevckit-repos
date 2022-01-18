using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model
{
    public partial class InventoryObject
    {
        public string GetFullTitle
        {
            get
            {
                return $"{Title}, {Amount} руб., Тип: {Type.Title} Номер: {InventoryNumber}";
            }
        }
    }
}
