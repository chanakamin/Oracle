using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oracle.Models
{
    public partial class recipe
    {
        public List<string> equipments
        {
            get
            {
                return (new recipeEntities()).equipment_in_recipe.Where(eq => eq.recipe_id == this.id).Select(eq => eq.special_equipment1).ToList();
            }
        }
       
    }
}