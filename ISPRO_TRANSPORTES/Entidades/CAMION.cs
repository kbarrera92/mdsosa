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
    
    public partial class CAMION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAMION()
        {
            this.SERVICIO = new HashSet<SERVICIO>();
            this.VIAJE = new HashSet<VIAJE>();
        }
    
        public int ID { get; set; }
        public string PLACA { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        public Nullable<int> PILOTO { get; set; }
    
        public virtual PILOTO PILOTO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO> SERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIAJE> VIAJE { get; set; }
    }
}
