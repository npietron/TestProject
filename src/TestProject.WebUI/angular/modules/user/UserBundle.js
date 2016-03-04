userModule
    .controller('UserController', function ($scope, $location, UserService) {

        $scope.performLogin = function (userName) {
            var userExists = UserService.doesUserExists(userName);

            if (!userExists) {
                var userDto = {
                    UserName: userName
                };

                UserService.addUser(userDto);
            }
            $location.path('/home');
        }

    });
userModule
    .factory('UserService', function (apiPathConfig, Restangular) {
        var addUserPackage = Restangular.all(apiPathConfig.addUser);

        return {
            addUser: addUser,
            getUserById: getUserById,
            doesUserExists: doesUserExists
        };

        function addUser(data) {
            return addUserPackage.post(data);
        }

        function getUserById(id) {
            var users = Restangular.one(apiPathConfig.getUserById + '(UserId=' + id + ')');
            return users.get();
        }

        function doesUserExists(userName) {
            var users = Restangular.one(apiPathConfig.doesUserExists + '(Nick=\'' + userName + '\')');
            return users.get();
        }

    });
var userModule = angular.module('user', ['app.config']);