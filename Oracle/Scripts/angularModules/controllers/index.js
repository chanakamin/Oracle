// controller for index page
angular.module("controllers").controller("indexCtrl", function ($scope, $location,$rootScope, ProductsFactory) {   
        $scope.link = function (page) {
            var basePage = 'Recipe'; 
            $location.path('/' + page);
            // $location.path("Recipe/addProduct");
        };
    });
