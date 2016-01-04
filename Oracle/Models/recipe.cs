//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oracle.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class recipe
    {
        public recipe()
        {
            this.equipment_in_recipe = new HashSet<equipment_in_recipe>();
            this.products_in_recipe = new HashSet<products_in_recipe>();
            this.recipe_for_user = new HashSet<recipe_for_user>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int user_id { get; set; }
        public Nullable<int> portions { get; set; }
        public string tips { get; set; }
        public bool approved { get; set; }
        public byte[] photo { get; set; }
        public string instructions { get; set; }
        public string preparation { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<equipment_in_recipe> equipment_in_recipe { get; set; }
        public virtual ICollection<products_in_recipe> products_in_recipe { get; set; }
        public virtual ICollection<recipe_for_user> recipe_for_user { get; set; }
    }
}
