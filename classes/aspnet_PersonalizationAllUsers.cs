//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class aspnet_PersonalizationAllUsers
    {
        public System.Guid PathId { get; set; }
        public byte[] PageSettings { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
    
        public virtual aspnet_Paths aspnet_Paths { get; set; }
    }
}
