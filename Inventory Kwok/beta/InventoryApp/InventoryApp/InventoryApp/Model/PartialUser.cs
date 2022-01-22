namespace InventoryApp.Model
{
    public partial class User
    {
        public string GetRoleText
        {
            get
            {
                if (Role == 1) return "Администратор";
                else if (Role == 2) return "Пользователь";
                else return "";
            }
        }
    }
}
