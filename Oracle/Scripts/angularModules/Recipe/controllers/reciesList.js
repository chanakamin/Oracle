/// <reference path="../factories/recipeFactory.js" />
(function () {
    function ctrl($scope, $location, RecipesFactory) {
        function Recipe(r) {
            this.id = r.id;
            this.name = r.name;
            this.description = r.description;
            this.category = r.category || r.category1.id;
        }
        Recipe.prototype.show = function () {
            if (angular.isObject(event))
                event.preventDefault();
            $location.path('/recipe/' + this.id);
            RecipesFactory.setCurrent(this.id);
        };
        var recipes = {
            all: RecipesFactory.getRecipes(),
            orginzed: (function (list) {
                var arr = [];
                angular.forEach(list, function (r) {
                    arr.push(new Recipe(r));
                });
                return arr;
            })(RecipesFactory.getRecipes()),
            categories: RecipesFactory.getCategories().getCopy(),
            change: function () {
                if (recipes.cat.id === 0)
                    this.shown = this.orginzedCat;
                else {
                    this.shown = this.orginzedCat.filter(function (c) {
                        return c.category.id === recipes.cat.id;
                    })
                }
            },            
        };
        recipes.orginzedCat = recipes.shown = RecipesFactory.orginizedByCategories(recipes.orginzed);
        recipes.cat = { id: 0, name: 'all' };
        recipes.categories.unshift(recipes.cat);
        recipes.search = recipes.all;
        $scope.recipes = recipes;
        $scope.$on('search_ended', function () {
            recipes.shown = recipes.search;
        });
    }
    angular.module('controllers').controller('recipesListCtrl', ['$scope','$location','RecipesFactory', ctrl]);
})();