//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dbo.[Rezervacija]")]
    public partial class Rezervacija
    {
        public int Id { get; set; }
        public int StoId { get; set; }
        public System.DateTime PocetakTermina { get; set; }
        public System.DateTime KrajTermina { get; set; }
    
        public virtual Sto Sto { get; set; }
    }
}
