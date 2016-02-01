(function () {
    function fact() {
        function User(id,name, manager) {
            this.name = name;
            this.id = id;
            this.user_or_manager = manager | false;
        }
        var user = new User();
        return {
            getUser: function () {
                return user;
            },
            setUser: function (id,name,manager) {
                user = new User(id, name, manager);
            },
            guest: function () {
                user = { id: 0, name: 'guest' };
            },
        };
    }
    angular.module('factoryModule').factory('userFactory',['resourcesFactory','$location',fact]);
})();