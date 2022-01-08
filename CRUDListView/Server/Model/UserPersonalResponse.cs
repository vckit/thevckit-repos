using CRUDListView.Model;
using System;
using System.IO;

namespace Server.Model
{
    public class UserPersonalResponse
    {
        public UserPersonalResponse(UserPersonal userPersonal)
        {
            this.id = userPersonal.ID;
            this.FirstName = userPersonal.FirstName;
            this.LastName = userPersonal.LastName;
            this.Email = userPersonal.Email;
            this.DateOfBirth = userPersonal.DateOfBirth;
            this.Phone = userPersonal.Phone;
            this.Telegram = userPersonal.Telegram;
            this.Statuses = userPersonal.Status.Title;
            if (File.Exists($"{id}.jpg"))
            {
                this.Photo = Convert.ToBase64String(File.ReadAllBytes($"{id}.jpg"));
            }
        }

        public UserPersonalResponse() { }
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Telegram { get; set; }
        public string Statuses { get; set; }
        public string Photo { get; set; }
    }
}
