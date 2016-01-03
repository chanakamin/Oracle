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
    
    public partial class product
    {
        public product()
        {
            this.products_in_nutritional_value = new HashSet<products_in_nutritional_value>();
            this.products_in_recipe = new HashSet<products_in_recipe>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int measurements_id_volume { get; set; }
        public int measurements_id_weight { get; set; }
        public double amount_weight_in_volume { get; set; }
        public int user_id { get; set; }
        public bool approved { get; set; }
    
        public virtual measurement measurementVolume { get; set; }
        public virtual measurement measurementWeight { get; set; }
        public virtual ICollection<products_in_nutritional_value> products_in_nutritional_value { get; set; }
        public virtual ICollection<products_in_recipe> products_in_recipe { get; set; }
        public virtual user user { get; set; }
    }
}
