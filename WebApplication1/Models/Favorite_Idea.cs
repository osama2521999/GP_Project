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
    
    public partial class Favorite_Idea
    {
        public int Id { get; set; }
        public Nullable<int> Student_id { get; set; }
        public Nullable<int> Project_id { get; set; }
    
        public virtual History History { get; set; }
        public virtual Student Student { get; set; }
    }
}
