(function () {
    var ctrl = function ($scope, DetailsFactory) {
        debugger;
        $scope.nut = DetailsFactory.calcNutrition($scope.products);
    };
    angular.module('controllers').controller('nutritionalRecipeCtrl', ['$scope', 'DetailsFactory', ctrl]);
})();