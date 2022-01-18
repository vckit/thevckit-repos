namespace InventoryApp.Model
{
    public partial class Employe
    {
        public string FIO
        {
            get
            {
                return $"{FirstName} {LastName} {Patronymic}";
            }
            set
            {
                value = FIO;
            }
        }
    }
}
