angular.module("directives")
    .directive('addProduct', function () {
    return {
        restrict: 'EA',
        templateUrl: 'Recipe/addProduct',
        controller:'addProductCtrl'
    };
});