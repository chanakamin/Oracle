(function () {
    /* Fuctory to save all functions of recipe */
    angular.module('factoryModule').factory('RecipesFactory', function ($http, $location, resourcesFactory, DetailsFactory, ProductsFactory) {
        var current = 0;
        var recipes = [];
        // inner functions in factory
        //function to create new recipe
        function Recipe(name ,description,  preparation, portions, instructions, tips) {
            this.name = name;
            this.description = description;
            this.user_id = DetailsFactory.userId();
            this.preparation = preparation;
            this.time = time;
            this.tips = tips;
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
        // function to add recipe to db
        function addRecipeToDb(recipe) {
            var config = {
                recipe: recipe,
                equipments: recipe.equipments,
                products_in_recipe: recipe.products_in_recipe
            };
            recipe.equipments = recipe.products_in_recipe = null;
            resourcesFactory.addResource('addRecipe', config)
                .then(function (data) {
                    var r = data.data.recipe;
                    recipe.id = r.id;
                    recipes.push(r);
                    $location.path('/showRecipe/' + r.id);
                });
        }

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
            // function to get recipe upon id
            getRecipe: function (id) {
                var r = recipes.filter(function (r) {
                    return r.id === id;
                });
                if (r.length == 0)
                    r = recipes[0];
                else
                    r = r[0];
                return r;
            },
            // function to create recipe, and add it to list
            createRecipe: function (name, user_id, preparation, time, portions, tips, comments, photo) {
                var r = new Recipe(name, user_id, preparation, time, portions, tips, comments, photo);
            },
            addRecipe: function (recipe) {
                var userId = DetailsFactory.userId();
                if (userId > 0) {
                    recipe.user_id = userId;
                    addRecipeToDb(recipe);
                }
            },
            setCurrent: function (cur) {
                current = cur;
            },
            getCurrentRecipe: function () {
                var l = $location.path().split('/');
                l = l.pop();
                if (!isNaN(parseInt(l)))
                    current = parseInt(l);
                if (current == 0)
                    current = recipes[0].id;
                return this.getRecipe(current);
            },
            // set product & measurement for any product in recipe
            setObjects: function (r) {
                angular.forEach(r.products, function (val) {
                    val.product = ProductsFactory.getProduct(val.product_id);
                    val.measurement = DetailsFactory.getMeasurement(val.measurements_id);
                })
            }
        };
    });
})();