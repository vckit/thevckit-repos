//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ATC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ATC()
        {
            this.SimATCAbonent1 = new HashSet<SimATCAbonent>();
        }
    
        public int Code { get; set; }
        public int IDDistrict { get; set; }
        public string CountNumber { get; set; }
    
        public virtual CityDisctict CityDisctict { get; set; }
        public virtual SimATCAbonent SimATCAbonent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SimATCAbonent> SimATCAbonent1 { get; set; }
    }
}