//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dieta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DD_GrupoOcupacional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DD_GrupoOcupacional()
        {
            this.DD_Beneficiarios = new HashSet<DD_Beneficiarios>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int DESAYUNO { get; set; }
        public int ALMUERZO { get; set; }
        public int CENA { get; set; }
        public int HOSPEDAJE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DD_Beneficiarios> DD_Beneficiarios { get; set; }
    }
}
