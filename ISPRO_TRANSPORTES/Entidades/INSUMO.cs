//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class INSUMO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSUMO()
        {
            this.COMPRADETA = new HashSet<COMPRADETA>();
            this.SALIDAINSUMODETA = new HashSet<SALIDAINSUMODETA>();
        }
    
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal COSTO { get; set; }
        public decimal PRECIO { get; set; }
        public Nullable<short> CATEGORIA { get; set; }
        public Nullable<decimal> EXISTENCIA { get; set; }
        public Nullable<bool> ESTADO { get; set; }
    
        public virtual CATEGORIA CATEGORIA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRADETA> COMPRADETA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALIDAINSUMODETA> SALIDAINSUMODETA { get; set; }
    }
}