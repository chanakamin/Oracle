angular.module("controllers").controller("newRecipeCtrl", function ($scope, RecipesFactory, ProductsFactory) {
    $scope.text = {
        title: 'new Recipe'
    };
    $scope.existsProducts = ProductsFactory.getProducts();
    var r = $scope.recipe = {
        name: "",
        instructions: "",
        description: "",
        portions: "",
        preparation: "",
        tips: "",
        products: new Array(),
        equipments: []
    };
    $scope.texts = {
        recipe: {
            name: 'Title',
            description: 'Description',
            preparation: 'Preparation',
            portions: 'Serving',
            equipment: 'Add Special Equipment',
            instructions: 'Instructions',
            tips: 'Do you have some tips for us?'
        }
    };
    $scope.AddProduct = function () {
        $scope.showProduct = true;
    }
    $scope.showProduct = false;
    $scope.nonEmpty = function (sp) {
        return sp.equipment !== "";
    }
    $scope.addEquipment = function () {
        r.equipments.push({equipment:$scope.newEquipment});
        $scope.newEquipment = '';
    }
    $scope.SubmitRecipe = function () {
        angular.forEach(r.equipments, function (val, key) {
            r.equipments[key] = {
                special_equipment1: val.equipment
            };
        });
        r.products_in_recipe = r.products;
        r.products = null;
        debugger;
        RecipesFactory.addRecipe(r);
    }
});