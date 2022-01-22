using InventoryApp.Context;
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
        public string GetCabinet
        {
            get
            {
                var cabinetInventoryObject = AppData.db.CabinetInventoryObject.FirstOrDefault(item => item.IDInventoryObject == ID);
                if (cabinetInventoryObject != null)
                    return AppData.db.Cabinet.FirstOrDefault(item => item.ID == cabinetInventoryObject.IDCabinet).Number;
                else return "Нет кабинета";
            }
        }
        public string AllData
        {
            get
            {
                return CommissioningDate.ToString("d");
            }
            set
            {
                value = CommissioningDate.ToString("d");
            }
        }
    }
}
