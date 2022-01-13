namespace WpfApp2.Model
{
    public partial class Abonent
    {
        public string GetFullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                value = GetFullName;
            }
        }
    }
}
