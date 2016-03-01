(function () {
    var ctrl = function ($scope, DetailsFactory, ProductsFactory) {
        $scope.nutritional = DetailsFactory.calcNutrition($scope.products, ProductsFactory);
    };
    angular.module('controllers').controller('nutritionalRecipeCtrl', ['$scope', 'DetailsFactory','ProductsFactory', ctrl]);
})();