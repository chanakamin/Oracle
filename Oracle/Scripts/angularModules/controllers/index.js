(function () {
    // controller for index page
    function ctrl($scope, $location, $rootScope, resourcesFactory, uiFactory) {
        //  objects for different parts of application
        function Part(name, title, part) {
            this.name = name;
            this.title = title;
            this.part = part;
        }
        // function to change current part
        Part.prototype.change = function () {
            $scope.title = this.title;
            $scope.part = this.part;
        }
        var parts = [
            new Part('Login', 'Welcome', 1),
            new Part('Recipe', 'Recipes', 2),
            new Part('Manager','Recipe Admin',3),
        ];
        parts.get = function () {
            return this[this.cur];
        }
        parts.set = function (part) {
            this.cur = part;
            this.get().change();
        }
        //parts.cur = 0;
        $scope.link = function (page) {
            $location.path('/' +parts.get().name + '/' + page);
        };
        
        $scope.changePart = function (part) {           
            $location.path('/' + parts[part].name);
            //resourcesFactory.action({
            //    method: 'GET',
            //    url: parts.get().name + '/changePart?part=' + parts[part].name,
            //}).then(function (data) {
            //    angular.element('#container').html(data);
            //    parts.set(part);
            //});
            parts.set(part);
        }
        parts.set(0);
        
    }
    angular.module("controllers").controller("indexCtrl", ['$scope', '$location', '$rootScope', 'resourcesFactory', 'uiFactory', ctrl]);
})();

