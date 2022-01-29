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

        public InventoryObject(string title, string inventoryNumber, string documentationPath, DateTime commissioningDate, int idType, int idSubType, int lifeTime, int idInvoce, int idCurrentStatus, decimal amount, int idEmployee, int idInventoryObjectDetails)
        {
            this.Title = title;
            this.InventoryNumber = inventoryNumber;
            this.DocumentationPath = documentationPath;
            this.CommissioningDate = commissioningDate;
            this.IDType = idType;
            this.IDSubType = idSubType;
            this.LifeTime = lifeTime;
            this.IDInvoce = idInvoce;
            this.IDCurrentStatus = idCurrentStatus;
            this.IDEmployee = idEmployee;
            this.Amount = amount;
            this.IDInventoryObjectDetail = idInventoryObjectDetails;
        }
    }
}
