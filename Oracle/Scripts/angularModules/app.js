﻿var app = angular.module('app', ['controllers', 'ngRoute', 'factoryModule', ]);
app.config(function ($routeProvider, $locationProvider)
{
    'use strict'
    $routeProvider
    .when('/newRecipe', {
        templateUrl: 'Recipe/newRecipe',
        controller: 'newRecipeCtrl'
    }).when('/addProduct', {
        templateUrl: 'Recipe/addProduct',
        controller: 'addProductCtrl'
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