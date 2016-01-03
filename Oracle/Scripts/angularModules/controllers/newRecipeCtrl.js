angular.module("controllers").controller("newRecipeCtrl", function ($scope, RecipesFactory, ProductsFactory) {
    $scope.text = {
        title: 'new Recipe'
    };
    var existsProducts = ProductsFactory.getProducts();
    var r = $scope.recipe = {
        name: "",
        instructions: "",
        portions: 0,
        preparation: 0.0,
        tips: "",
        comments: "",
        products: existsProducts,
        equipments: []
    };
    $scope.produc = {
        show: false,
        add: function () {
            this.show = true;
        }
    }
});