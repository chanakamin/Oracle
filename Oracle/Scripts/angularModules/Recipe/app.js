var app = angular.module('app', ['controllers', 'ngRoute', 'factoryModule', ]);
app.config(function ($routeProvider, $locationProvider)
{
    'use strict'
    $routeProvider
    .when('/Recipe/allRecipes', {
        templateUrl: 'Recipe/allRecipes',
        controller: 'recipesListCtrl'
    }).when('/Recipe/newRecipe', {
        templateUrl: 'Recipe/newRecipe',
        controller: 'newRecipeCtrl'
    }).when('/Recipe/addProduct', {
        templateUrl: 'Recipe/addProduct',
        controller: 'addProductCtrl'
    }).when('/Recipe/addRecipeForProduct', {
        templateUrl: 'Recipe/addRecipeForProduct',
        controller: 'productRecipeCtrl'
    }).when('/Recipe/nutritionalValues', {
        templateUrl: 'Recipe/nutritionalValues',
        controller: 'nutritionalsRecipeCtrl'
    }).when('/Recipe/showRecipe/:id', {
        templateUrl: 'Recipe/showRecipe/0',
        controller: 'showRecipeCtrl'
    }).when('/Login', {
        templateUrl: 'Login/Login',
        controller: 'loginCtrl',
    }).when('/Recipe', {
        templateUrl: 'Recipe/Index' + '?partial=true',
    }).otherwise({
        redirectTo: '/Login',
       // controller: 'loginCtrl',
    });
    //$locationProvider.html5Mode(true);
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