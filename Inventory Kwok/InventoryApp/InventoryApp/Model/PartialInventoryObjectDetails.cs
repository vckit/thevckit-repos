namespace InventoryApp.Model
{
    public partial class InventoryObjectDetails
    {
        public string GetTitle
        {
            get
            {
                return $"{Title}, {SeriaNumber}";
            }
        }
    }
}
