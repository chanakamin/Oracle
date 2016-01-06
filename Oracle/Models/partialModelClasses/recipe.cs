using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oracle.Models
{
    public partial class recipe
    {
        static private recipeEntities re;
        static recipe() 
        {
            re = new recipeEntities();
        }
        public List<string> equipments
        {
            get
            {
                return re.equipment_in_recipe.Where(eq => eq.recipe_id == this.id).Select(eq => eq.special_equipment).ToList();
            }
        }
        public List<products_in_recipe> products
        {
            get
            {
                return re.products_in_recipe.Where(pr => pr.recipe_id == this.id).ToList().Select(pr=>pr.getSerialize()).ToList();
            }
        }

        public bool isApproved() 
        {
            List<int> managers = re.users.Where(u => u.user_or_manager == true)
                .Select(u=>u.id).ToList();
            this.approved = managers.Any(id =>id == this.user_id);
            return this.approved;
        }
        public recipe getSerialize()
        {
            recipe r = new recipe() {
                id = this.id,
                name = this.name,
                portions = this.portions,
                tips = this.tips,
                approved = this.approved,
                instructions = this.instructions,
                preparation = this.preparation,
                description = this.description
            };
            return r;
        }
       
    }
}