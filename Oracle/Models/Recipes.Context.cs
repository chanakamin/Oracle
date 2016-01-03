﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class recipeEntities : DbContext
    {
        public recipeEntities()
            : base("name=recipeEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<equipment_in_recipe> equipment_in_recipe { get; set; }
        public DbSet<measure_type> measure_type { get; set; }
        public DbSet<measurement> measurements { get; set; }
        public DbSet<nutritional_value> nutritional_value { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<products_in_nutritional_value> products_in_nutritional_value { get; set; }
        public DbSet<products_in_recipe> products_in_recipe { get; set; }
        public DbSet<recipe> recipes { get; set; }
        public DbSet<recipe_for_user> recipe_for_user { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<measurement_with_type> measurement_with_type { get; set; }
        public DbSet<nutritional_value_details> nutritional_value_details { get; set; }
    
        public virtual int add_company(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_company", nameParameter);
        }
    
        public virtual int add_equipment_in_recipe(Nullable<int> recipe_id, Nullable<int> equipment_id)
        {
            var recipe_idParameter = recipe_id.HasValue ?
                new ObjectParameter("recipe_id", recipe_id) :
                new ObjectParameter("recipe_id", typeof(int));
    
            var equipment_idParameter = equipment_id.HasValue ?
                new ObjectParameter("equipment_id", equipment_id) :
                new ObjectParameter("equipment_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_equipment_in_recipe", recipe_idParameter, equipment_idParameter);
        }
    
        public virtual int add_measure_type(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_measure_type", nameParameter);
        }
    
        public virtual int add_measurements(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_measurements", nameParameter);
        }
    
        public virtual int add_nutritional_value(string name, Nullable<int> measure_type_id)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var measure_type_idParameter = measure_type_id.HasValue ?
                new ObjectParameter("measure_type_id", measure_type_id) :
                new ObjectParameter("measure_type_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_nutritional_value", nameParameter, measure_type_idParameter);
        }
    
        public virtual int add_product(string name, string description, Nullable<int> user_id)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_product", nameParameter, descriptionParameter, user_idParameter);
        }
    
        public virtual int add_product_in_company(Nullable<int> product_id, Nullable<int> company_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var company_idParameter = company_id.HasValue ?
                new ObjectParameter("company_id", company_id) :
                new ObjectParameter("company_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_product_in_company", product_idParameter, company_idParameter);
        }
    
        public virtual int add_products_in_nutritional_value(Nullable<int> product_id, Nullable<int> nutritional_value_id, Nullable<double> amount_per_100)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var nutritional_value_idParameter = nutritional_value_id.HasValue ?
                new ObjectParameter("nutritional_value_id", nutritional_value_id) :
                new ObjectParameter("nutritional_value_id", typeof(int));
    
            var amount_per_100Parameter = amount_per_100.HasValue ?
                new ObjectParameter("amount_per_100", amount_per_100) :
                new ObjectParameter("amount_per_100", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_products_in_nutritional_value", product_idParameter, nutritional_value_idParameter, amount_per_100Parameter);
        }
    
        public virtual int add_products_in_recipe(Nullable<int> recipe_id, Nullable<int> product_id, Nullable<int> measurements_id, Nullable<double> amount)
        {
            var recipe_idParameter = recipe_id.HasValue ?
                new ObjectParameter("recipe_id", recipe_id) :
                new ObjectParameter("recipe_id", typeof(int));
    
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var measurements_idParameter = measurements_id.HasValue ?
                new ObjectParameter("measurements_id", measurements_id) :
                new ObjectParameter("measurements_id", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_products_in_recipe", recipe_idParameter, product_idParameter, measurements_idParameter, amountParameter);
        }
    
        public virtual int add_products_per_measurement(Nullable<int> measurements_id, Nullable<int> product_id, Nullable<double> amount)
        {
            var measurements_idParameter = measurements_id.HasValue ?
                new ObjectParameter("measurements_id", measurements_id) :
                new ObjectParameter("measurements_id", typeof(int));
    
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_products_per_measurement", measurements_idParameter, product_idParameter, amountParameter);
        }
    
        public virtual int add_products_per_measuremnts(Nullable<int> measurements_id, Nullable<int> product_id, Nullable<double> amount)
        {
            var measurements_idParameter = measurements_id.HasValue ?
                new ObjectParameter("measurements_id", measurements_id) :
                new ObjectParameter("measurements_id", typeof(int));
    
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_products_per_measuremnts", measurements_idParameter, product_idParameter, amountParameter);
        }
    
        public virtual int add_recipe(string name, Nullable<int> user_id, string preparation, Nullable<System.TimeSpan> time, Nullable<int> portion, string tips, string comments, byte[] photo)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            var preparationParameter = preparation != null ?
                new ObjectParameter("preparation", preparation) :
                new ObjectParameter("preparation", typeof(string));
    
            var timeParameter = time.HasValue ?
                new ObjectParameter("time", time) :
                new ObjectParameter("time", typeof(System.TimeSpan));
    
            var portionParameter = portion.HasValue ?
                new ObjectParameter("portion", portion) :
                new ObjectParameter("portion", typeof(int));
    
            var tipsParameter = tips != null ?
                new ObjectParameter("tips", tips) :
                new ObjectParameter("tips", typeof(string));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("comments", comments) :
                new ObjectParameter("comments", typeof(string));
    
            var photoParameter = photo != null ?
                new ObjectParameter("photo", photo) :
                new ObjectParameter("photo", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_recipe", nameParameter, user_idParameter, preparationParameter, timeParameter, portionParameter, tipsParameter, commentsParameter, photoParameter);
        }
    
        public virtual int add_recipe_for_user(Nullable<int> recipe_id, Nullable<int> user_id)
        {
            var recipe_idParameter = recipe_id.HasValue ?
                new ObjectParameter("recipe_id", recipe_id) :
                new ObjectParameter("recipe_id", typeof(int));
    
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_recipe_for_user", recipe_idParameter, user_idParameter);
        }
    
        public virtual int add_special_equipment(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_special_equipment", nameParameter);
        }
    
        public virtual int add_user(string name, string password, string email)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_user", nameParameter, passwordParameter, emailParameter);
        }
    
        public virtual int delete_company(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_company", idParameter);
        }
    
        public virtual int delete_equipment_in_recipe(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_equipment_in_recipe", idParameter);
        }
    
        public virtual int delete_measure_types(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_measure_types", idParameter);
        }
    
        public virtual int delete_measurements(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_measurements", idParameter);
        }
    
        public virtual int delete_nutritional_value(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_nutritional_value", idParameter);
        }
    
        public virtual int delete_product(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_product", idParameter);
        }
    
        public virtual int delete_product_in_company(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_product_in_company", idParameter);
        }
    
        public virtual int delete_product_in_recipe(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_product_in_recipe", idParameter);
        }
    
        public virtual int delete_products_in_nutritional_value(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_products_in_nutritional_value", idParameter);
        }
    
        public virtual int delete_products_in_recipe(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_products_in_recipe", idParameter);
        }
    
        public virtual int delete_recipe(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_recipe", idParameter);
        }
    
        public virtual int delete_recipe_for_user(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_recipe_for_user", idParameter);
        }
    
        public virtual int delete_special_equipment(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_special_equipment", idParameter);
        }
    
        public virtual int delete_user(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_user", idParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int update_recipe(Nullable<int> id, Nullable<System.TimeSpan> time, Nullable<int> portions, string tips, string comments, byte[] photo)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var timeParameter = time.HasValue ?
                new ObjectParameter("time", time) :
                new ObjectParameter("time", typeof(System.TimeSpan));
    
            var portionsParameter = portions.HasValue ?
                new ObjectParameter("portions", portions) :
                new ObjectParameter("portions", typeof(int));
    
            var tipsParameter = tips != null ?
                new ObjectParameter("tips", tips) :
                new ObjectParameter("tips", typeof(string));
    
            var commentsParameter = comments != null ?
                new ObjectParameter("comments", comments) :
                new ObjectParameter("comments", typeof(string));
    
            var photoParameter = photo != null ?
                new ObjectParameter("photo", photo) :
                new ObjectParameter("photo", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_recipe", idParameter, timeParameter, portionsParameter, tipsParameter, commentsParameter, photoParameter);
        }
    
        public virtual int update_special_equipment(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_special_equipment", idParameter, nameParameter);
        }
    
        public virtual int update_user(Nullable<int> id, string name, string password, string email)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_user", idParameter, nameParameter, passwordParameter, emailParameter);
        }
    
        public virtual int insert_nutritional_Value(string name, string alias)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var aliasParameter = alias != null ?
                new ObjectParameter("alias", alias) :
                new ObjectParameter("alias", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_nutritional_Value", nameParameter, aliasParameter);
        }
    
        public virtual ObjectResult<nutritionalForProduct_Result> nutritionalForProduct(Nullable<int> product_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<nutritionalForProduct_Result>("nutritionalForProduct", product_idParameter);
        }
    }
}
