(function () {
    function ctrl($scope, $location, RecipesFactory) {
        var recipes = RecipesFactory.getRecipes();
        function Recipe(r) {
            this.id = r.id;
            this.name = r.name;
            this.description = r.description;
        }
        var basePage = 'Recipe';
        Recipe.prototype.show = function () {            
            $location.path('/showRecipe/' + this.id); debugger;
            RecipesFactory.setCurrent(this.id); 
        };
        $scope.recipes = [];
        angular.forEach(recipes, function (r) {
            $scope.recipes.push(new Recipe(r));
        });
    }
    angular.module('controllers').controller('recipesListCtrl', ['$scope','$location','RecipesFactory', ctrl]);
})();