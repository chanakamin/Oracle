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
    
    public partial class measurement_with_type
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public int measure_type_id { get; set; }
        public Nullable<int> measurement_id { get; set; }
        public Nullable<double> amount { get; set; }
        public string measure_type { get; set; }
    }
}