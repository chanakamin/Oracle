(function () {
    /* Fuctory to save all functions of recipe */
    angular.module('factoryModule').factory('RecipesFactory', function ($http, resourcesFactory, DetailsFactory) {
        var recipes = [];
        // inner functions in factory
        //function to create new recipe
        function Recipe(name, user_id, preparation, time, portions, tips, comments) {
            this.name = name;
            this.user_id = user_id;
            this.preparation = preparation;
            this.time = time;
            this.tips = tips;
            this.commnts = comments;
        }

        // function to orginized list of recipes, get list from ajax request
        var orginizedList = function (recipesList, add) {
            if(!add)
                recipes = [];
            recipes = recipesList;
        };

        // This function get products from db, using ajax call
        var initRecipesFromDb = function () {
            resourcesFactory.initResource('getRecipes','recipes')
                    .success(function (data) {
                        console.log('in init recipes');
                        console.log(data);
                        orginizedList(data);
                    })
                    .error(function (e) {
                        console.log('init recipes failed. ' + e);
                    });
        };

        // Function for use with the factory
        return {
            // function to initialize list of recipes
            initRecipes: function (init) {
                if (init)
                    initRecipesFromDb();
                else
                {
                    var r = resourcesFactory.getResource('recipes');
                    orginizedList(r);
                }
            },
            // function to get list of recipes
            getRecipes: function () {
                if (recipes.length === 0) {
                    this.initRecipes();
                }                    
                return recipes;
            },
            // function to create recipe, and add it to list
            createRecipe: function (name, user_id, preparation, time, portions, tips, comments, photo) {
                var r = new Recipe(name, user_id, preparation, time, portions, tips, comments, photo);
            },
        };
    });
})();