(function () {
    function ctrl($scope, $locatoin, userFactory) {
        $scope.link = function (dest) {
            $locatoin.path(dest);
        };
        function Message(header, context) {
            this.header = header;
            this.context = context;
        }
        $scope.messages = [
            new Message('guest','Are you sure you want to login as a guest?')
        ];
    }
    angular.module('LoginApp').controller('loginCtrl', ['$scope','$location','userFactory',ctrl]);
})();