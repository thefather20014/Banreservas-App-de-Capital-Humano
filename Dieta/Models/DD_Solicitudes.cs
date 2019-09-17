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
    
    public partial class DD_Solicitudes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DD_Solicitudes()
        {
            this.COSTOes = new HashSet<COSTO>();
            this.DISTANCIAs = new HashSet<DISTANCIA>();
            this.DD_Beneficiarios = new HashSet<DD_Beneficiarios>();
            this.DD_Cantidades = new HashSet<DD_Cantidades>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public System.DateTime FECHA { get; set; }
        public string CARGO { get; set; }
        public string DEPENDENCIA { get; set; }
        public string MOTIVO { get; set; }
        public System.DateTime F_ENTRADA { get; set; }
        public System.DateTime F_SALIDA { get; set; }
        public string TIPO { get; set; }
        public Nullable<decimal> Combustible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COSTO> COSTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISTANCIA> DISTANCIAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DD_Beneficiarios> DD_Beneficiarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DD_Cantidades> DD_Cantidades { get; set; }
    }
}