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
    
    public partial class COMPRA2
    {
        public long ID { get; set; }
        public System.DateTime FECHA { get; set; }
        public string NOFACTURA { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public string NIT { get; set; }
        public string PROVEEDOR { get; set; }
        public string CUENTACONTABLE { get; set; }
        public Nullable<decimal> GALONAJE { get; set; }
        public string IDP { get; set; }
        public Nullable<decimal> TOTALFACTURA { get; set; }
        public Nullable<decimal> PRECIONETO { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
    }
}