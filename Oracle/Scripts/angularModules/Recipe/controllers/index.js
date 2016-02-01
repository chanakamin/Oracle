(function () {
    // controller for index page
    function ctrl($scope, $location, $rootScope, resourcesFactory) {
        $scope.link = function (page) {
            if (angular.isObject(event))
                event.preventDefault();
            $location.path(page);
            $scope.title = $scope.words[page];
        };
        $scope.logout = function () {
            window.location.href = '/Login/Logout?view=true';
        }
        $scope.changePart = function (part) {  
        }
        $scope.words = {
            logout: 'Log Out',
            newres: 'New Recipe',
            reslist: 'Recipes List',
            recipes: 'Recipes',
            'new': 'New Recipe',
        };
        
        
    }
    angular.module("controllers").controller("indexCtrl", ['$scope', '$location', '$rootScope', 'resourcesFactory', ctrl]);
})();

