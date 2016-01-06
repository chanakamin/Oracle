var app = angular.module('app', ['controllers', 'ngRoute', 'factoryModule', ]);
app.config(function ($routeProvider, $locationProvider)
{    'use strict'
    $routeProvider
    .when('/allRecipes', {
        templateUrl: 'Recipe/allRecipes',
        controller: 'recipesListCtrl'
    }).when('/newRecipe', {
        templateUrl: 'Recipe/newRecipe',
        controller: 'newRecipeCtrl'
    }).when('/addProduct', {
        templateUrl: 'Recipe/addProduct',
        controller: 'addProductCtrl'
    }).when('/addRecipeForProduct', {
        templateUrl: 'Recipe/addRecipeForProduct',
        controller: 'productRecipeCtrl'
    }).when('/nutritionalValues', {
        templateUrl: 'Recipe/nutritionalValues',
        controller: 'nutritionalsRecipeCtrl'
    }).when('/showRecipe/:id', {
        templateUrl: 'Recipe/showRecipe/0',
        controller: 'showRecipeCtrl'
    });
});
// when app runs, all factories are being initialize.
app.run(function ($location, $rootScope, ProductsFactory, DetailsFactory, RecipesFactory, resourcesFactory) {
    resourcesFactory.initResources().then(function (data) {
        ProductsFactory.initProducts();
        RecipesFactory.initRecipes();
        DetailsFactory.init();
    }); 
    $rootScope.history = [];
    $rootScope.$on('$routeChangeSuccess', function (event, routeData) {
            $rootScope.history.push($location.$$path);
    });
});