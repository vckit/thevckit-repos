using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public partial class CityDisctict
    {
        public string GetCityDisctict
        {
            get
            {
                return $"{Disctrict.Title} - {City.Title}";
            }
        }
    }
}
