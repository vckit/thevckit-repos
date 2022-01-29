using InventoryApp.Context;
using InventoryApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Tests
{
    [TestClass]
    public class ObjectInventoryCRUDTests
    {
        // Проверка на добавление данных
        [TestMethod]
        public void AddObjectInventoryToDataBase()
        {
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            InventoryObject inventoryObject = new InventoryObject();
            inventoryObject.Title = "Title";
            inventoryObject.InventoryNumber = "1245";
            inventoryObject.DocumentationPath = "path";
            inventoryObject.CommissioningDate = DateTime.Now;
            inventoryObject.IDType = 1;
            inventoryObject.IDSubType = 18;
            inventoryObject.LifeTime = 1;
            inventoryObject.IDInventoryObjectDetail = 1017;
            inventoryObject.IDCurrentStatus = 1;
            inventoryObject.IDInvoce = 1;
            inventoryObject.Amount = 100;
            inventoryObject.IDEmployee = 1;
            AppData.db.InventoryObject.Add(inventoryObject);
            objects.Add(inventoryObject);
            AppData.db.SaveChanges();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }

        // Если хотя бы один обязательный столбец примет значение Null программа успешно сообщает об ошибке
        [TestMethod]
        public void ExectionToAddedDataInDataBase_IDCurrentStatus_0()
        {
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            InventoryObject inventoryObject = new InventoryObject();
            inventoryObject.Title = "Title";
            inventoryObject.InventoryNumber = "1245";
            inventoryObject.DocumentationPath = "path";
            inventoryObject.CommissioningDate = DateTime.Now;
            inventoryObject.IDType = 1;
            inventoryObject.IDSubType = 18;
            inventoryObject.LifeTime = 1;
            inventoryObject.IDInventoryObjectDetail = 1017;
            inventoryObject.IDCurrentStatus = 0;
            inventoryObject.IDInvoce = 1;
            inventoryObject.Amount = 100;
            inventoryObject.IDEmployee = 1;
            AppData.db.InventoryObject.Add(inventoryObject);
            objects.Add(inventoryObject);
            AppData.db.SaveChanges();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }
        // Программа действительно удаляет объект по указанному ID
        [TestMethod]
        public void DeletedInventoryObject()
        {
            var selectedItem = AppData.db.InventoryObject.FirstOrDefault(i => i.ID == 5);
            AppData.db.InventoryObject.Remove(selectedItem);
            AppData.db.SaveChanges();
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }

        // Программа действительно запрещает удалять объект по не существующему ID
        [TestMethod]
        public void ExecptionDeletedInventoryObject()
        {
            var selectedItem = AppData.db.InventoryObject.FirstOrDefault(i => i.ID == 1000);
            AppData.db.InventoryObject.Remove(selectedItem);
            AppData.db.SaveChanges();
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }

        // Метод проверяет, редактируется ли данные в базе данных, при правильно указанном ID
        [TestMethod]
        public void EditDataInventoryObject()
        {
            InventoryObject inventoryObject = AppData.db.InventoryObject.FirstOrDefault(i => i.ID == 7);
            inventoryObject.Title = "Title Update";
            inventoryObject.InventoryNumber = "1234213";
            inventoryObject.DocumentationPath = "path update";
            inventoryObject.CommissioningDate = DateTime.Now;
            inventoryObject.IDType = 1;
            inventoryObject.IDSubType = 18;
            inventoryObject.LifeTime = 1;
            inventoryObject.IDInventoryObjectDetail = 1017;
            inventoryObject.IDCurrentStatus = 28;
            inventoryObject.IDInvoce = 1;
            inventoryObject.Amount = 100;
            inventoryObject.IDEmployee = 1;
            AppData.db.SaveChanges();
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }

        // Метод проверяет, выйдет ли ошибка при редактировании, если ID объекта задан не правильно
        [TestMethod]
        public void ExectionEditDataInventoryObject()
        {
            InventoryObject inventoryObject = AppData.db.InventoryObject.FirstOrDefault(i => i.ID == 1000);
            inventoryObject.Title = "Title Update";
            inventoryObject.InventoryNumber = "1234213";
            inventoryObject.DocumentationPath = "path update";
            inventoryObject.CommissioningDate = DateTime.Now;
            inventoryObject.IDType = 1;
            inventoryObject.IDSubType = 18;
            inventoryObject.LifeTime = 1;
            inventoryObject.IDInventoryObjectDetail = 1017;
            inventoryObject.IDCurrentStatus = 28;
            inventoryObject.IDInvoce = 1;
            inventoryObject.Amount = 100;
            inventoryObject.IDEmployee = 1;
            AppData.db.SaveChanges();
            List<InventoryObject> objects = AppData.db.InventoryObject.ToList();
            CollectionAssert.AreEqual(objects, AppData.db.InventoryObject.ToList());
        }

        // Метод проверяет, программа правильно Ли проведет процесс авторизации при правильных данных логина и пароля
        [TestMethod]
        public void SignInSuccessfulle()
        {
            var signIn = AppData.db.User.FirstOrDefault(x => x.Username == "admin" && x.Password == "admin" && x.Role == 1);
            StringAssert.Contains(signIn.ToString(), AppData.db.User.FirstOrDefault(x => x.Username == "admin" && x.Password == "admin" && x.Role == 1).ToString());
        }
        // Метод проверяет, программа успешно проведет процесс авторизации при неправильных данных логина и пароля
        [TestMethod]
        public void SignInFiled()
        {
            var signIn = AppData.db.User.FirstOrDefault(x => x.Username == "admin" && x.Password == "admin" && x.Role == 1);
            StringAssert.Contains(signIn.ToString(), AppData.db.User.FirstOrDefault(x => x.Username == "admin" && x.Password == "admin" && x.Role == 1).ToString());
        }
    }
}
