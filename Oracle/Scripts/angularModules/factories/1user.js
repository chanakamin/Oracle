(function () {
    function fact(resourcesFactory, $location) {
        function User(name, password, email, manager) {
            this.name = name;
            this.password = password;
            this.email = email;
            this.user_or_manager = manager | false;
        }
        var user;
        User.prototype.verify = function () {
           return  resourcesFactory.action({
                method: 'post',
                data: { name: this.name, password: this.password, email: this.email },
                url: "Login/existUser",
            }).then(function (data) {
                return data;
            })
        }
        User.prototype.add = function () {
            return resourcesFactory.action({
                method: 'post',
                data: { user: this },
                url: "Login/addUser",
            }).then(function (data) {
                this.id = data.id;
                return true;
            });            
        };
        User.prototype.register = function () {
            return resourcesFactory.action({
                method: 'post',
                data: { user: this },
                url: "Login/register",
            }).then(function (data) {
                user = this;
            });
        }
        return {
            getUser: function () {
                return user;
            },
            addUser: function (name, password, email, navigate) {
                var u = new User(name, password, email);
                return u.verify().then(function (data) {
                    if (data.can) {
                        user = u;
                        return user.add();
                     }
                    else {
                        return data.reason;
                    }
                });
            },
            addManager: function (name, password, email) {

            },
            login: function (name, password) {
                u = new User(name, password);
                return u.verify().then(function (data) {
                    if (data.exist) {
                        u.email = data.user.email;
                        u.user_or_manager = data.user.user_or_manager;
                        u.id = data.user.id;
                        u.register();
                        if (!u.user_or_manager)
                            return true;
                        else {
                            return 'manager';
                        }
                    }
                    else {
                        return data.reason;
                    }
                });
            },
            guest: function () {
                user = { id: 0, name: 'guest' };
            },
        };
    }
    angular.module('factoryModule').factory('userFactory',['resourcesFactory','$location',fact]);
})();