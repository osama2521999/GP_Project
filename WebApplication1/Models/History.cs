//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public History()
        {
            this.Favorite_Idea = new HashSet<Favorite_Idea>();
        }
    
        public int Project_id { get; set; }
        public string Title { get; set; }
        public byte[] Decument { get; set; }
        public string Name { get; set; }
        public string Awards { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public Nullable<int> Doctor_id { get; set; }
        public Nullable<int> Team_id { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite_Idea> Favorite_Idea { get; set; }
        public virtual Team Team { get; set; }
    }
}