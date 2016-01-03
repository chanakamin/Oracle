
angular.module("controllers").controller("indexCtrl", function ($scope, $location,$rootScope, ProductsFactory) {
    $scope.msg = "hello";
   // alert($rootScope.companies);
    
    $scope.initList = function () {
        $scope.products = ProductsFactory.getProducts();
      //  console.log($rootScope.products);
     //   CompaniesFactory.addCompany("Visotzki");
    };
        $scope.link = function (page) {
            var basePage = 'Recipe'
            $location.path('/' + page);
            // $location.path("Recipe/addProduct");
        };
    });
