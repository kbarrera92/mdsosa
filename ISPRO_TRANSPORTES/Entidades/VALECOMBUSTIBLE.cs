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
    
    public partial class VALECOMBUSTIBLE
    {
        public long CORRELATIVO { get; set; }
        public Nullable<long> NOVALE { get; set; }
        public System.DateTime FECHA { get; set; }
        public Nullable<decimal> MONTO { get; set; }
        public Nullable<long> VIAJE { get; set; }
        public Nullable<bool> LOCALIDAD { get; set; }
    
        public virtual VIAJE VIAJE1 { get; set; }
    }
}
