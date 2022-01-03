using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDListView.Model
{
    public partial class UserPersonal
    {
        public string GetPhoto
        {
            get
            {
                return Environment.CurrentDirectory + "\\photos\\" + Photo;
            }
            set
            {
                Photo = value;
            }
        }
    }
}
