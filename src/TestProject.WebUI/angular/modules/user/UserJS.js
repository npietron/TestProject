var userModule = angular.module('user', ['app.config']);
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
            var users = Restangular.one(apiPathConfig.doesUserExists + '(UserName=\'' + userName + '\')');
            return users.get();
        }

    });
userModule
    .factory('UserObjectComposer', function () {

        return {
            generateUserObject: generateUserObject
        };

        function generateUserObject(data) {
            return {
                Request: {
                    UserId: data.UserId,
                    UserName: data.UserName
                }
            }
        }

    });
userModule
    .controller('UserController', function ($scope, $location,routePathConfig, UserService, UserObjectComposer) {

        $scope.performLogin = function (userName) {
            var userExists = UserService.doesUserExists(userName);

            if (!userExists.restangularCollection) {
                var userDto = {
                    UserId: 0,
                    UserName: userName
                };

                UserService.addUser(UserObjectComposer.generateUserObject(userDto));
            }
            $location.path(routePathConfig.home);
        }
    });