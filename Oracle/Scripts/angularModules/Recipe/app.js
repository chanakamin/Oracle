var app = angular.module('app', ['controllers', 'ngRoute', 'factoryModule', ]);
app.config(function ($routeProvider, $locationProvider)
{
    'use strict'
    $routeProvider
    .when('/recipes', {
        templateUrl: 'Recipe/allRecipes',
        controller: 'recipesListCtrl'
    }).when('/new', {
        templateUrl: 'Recipe/newRecipe',
        controller: 'newRecipeCtrl'
    }).when('/newproduct', {
        templateUrl: 'Recipe/addProduct',
        controller: 'addProductCtrl'
    }).when('/addRecipeForProduct', {
        templateUrl: 'Recipe/addRecipeForProduct',
        controller: 'productRecipeCtrl'
    }).when('/nutritionalValues', {
        templateUrl: 'Recipe/nutritionalValues',
        controller: 'nutritionalsRecipeCtrl'
    }).when('/recipe/:id', {
        templateUrl: 'Recipe/showRecipe/0',
        controller: 'showRecipeCtrl'
    }).when('/', {
        templateUrl: 'Recipe/Welcome',
    }).otherwise({
        redirectTo: '/',
    });
    //$locationProvider.html5Mode(true);
});
// when app runs, all factories are being initialize.
app.run(function ($location, $rootScope, ProductsFactory, DetailsFactory, RecipesFactory, resourcesFactory, userFactory) {
    userFactory.setUser(id, name, manager);
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