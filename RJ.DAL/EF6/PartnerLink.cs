//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RJ.DAL.EF6
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartnerLink
    {
        public int LinkId { get; set; }
        public string DisaplyName { get; set; }
        public string Url { get; set; }
        public int PartnerId { get; set; }
    
        public Partner Partner { get; set; }
    }
}