//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Site.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venda
    {
        public Venda()
        {
            this.ProdutoVendaItem = new HashSet<ProdutoVendaItem>();
        }
    
        public int Id { get; set; }
        public System.DateTime Data { get; set; }
        public double Total { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ProdutoVendaItem> ProdutoVendaItem { get; set; }
    }
}