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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.VIAJE = new HashSet<VIAJE>();
        }
    
        public int ID { get; set; }
        public string CODIGO { get; set; }
        public string CLAVE { get; set; }
        public Nullable<short> TIPO { get; set; }
        public Nullable<bool> ESTADO { get; set; }
    
        public virtual TIPOUSUARIO TIPOUSUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIAJE> VIAJE { get; set; }
    }
}
