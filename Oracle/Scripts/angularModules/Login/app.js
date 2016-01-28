var app = angular.module('LoginApp', ['ngRoute']);
app.config(function( $locationProvider,$routeProvider)
{
    'use strict'
    $routeProvider
    .when('/', {
        templateUrl: 'Login/Welcome'
    }).when('/signin', {
        templateUrl: 'Login/SignIn'
    }).when('/signup', {
        templateUrl: 'Login/Signup'
    }).when('/logout', {
        templateUrl: 'Login/Logout'
    }).otherwise({
        redirectTo: '/',
    });

});
app.run(function ($location, $rootScope, $http) {
    $http.get('Login/user').then(function (data) {
        var d = data.data;
        if (d.status == 1)
        {
            window.location.hash = '';
            window.location.pathname = 'Recipe';
        }
    });
    $rootScope.history = [];
    $rootScope.$on('$routeChangeSuccess', function (event, routeData) {
        $rootScope.history.push($location.$$path);
    });
});