(function () {
    function ctrl($scope, RecipesFactory) {
        var r = RecipesFactory.getCurrentRecipe();
        RecipesFactory.setObjects(r);
        $scope.recipe = r
    }
    angular.module('controllers').controller('showRecipeCtrl', ['$scope', 'RecipesFactory', ctrl]);
})();

//approved: true
//description: "try something"
//equipment_in_recipe: Array[0]
//equipments: Array[1]
//0: "mixer"
//length: 1
//__proto__: Array[0]
//id: 9
//instructions: "Not really nead mixer"
//name: "trial"
//photo: null
//portions: 5
//preparation: "1 minutes"
//products: Array[1]
//0: Object
//amount: 8
//id: 9
//measurement: null
//measurements_id: 3
//product: null
//product_id: 1
//recipe: null
//recipe_id: 9
//__proto__: Object
//length: 1
//__proto__: Array[0]
//products_in_recipe: Array[0]
//recipe_for_user: Array[0]
//tips: "No No no"
//user_id: 0