//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAF.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public Document()
        {
            this.ApplicationDocuments = new HashSet<ApplicationDocument>();
        }
    
        public long ID { get; set; }
        public string Title { get; set; }
        public string DocumentPath { get; set; }
    
        public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
    }
}
