var userModule = angular.module('user', ['app.config']);
userModule
    .factory('UserService', function (apiPathConfig, Restangular) {
        var addUserPackage = Restangular.all(apiPathConfig.addUser);
        var currentUser;

        return {
            addUser: addUser,
            getUserById: getUserById,
            getUserIdByUserName: getUserIdByUserName,
            doesUserExists: doesUserExists,
            getCurrentUser: getCurrentUser,
            setCurrentUser : setCurrentUser
        };

        function addUser(data) {
            return addUserPackage.post(data);
        }

        function getUserById(id) {
            var users = Restangular.one(apiPathConfig.getUserById + '(UserId=' + id + ')');
            return users.get();
        }

        function getUserIdByUserName(userName) {
            var users = Restangular.one(apiPathConfig.getUserById + '(UserName=' + userName + ')');
            return users.get();
        }

        function doesUserExists(userName) {
            var users = Restangular.one(apiPathConfig.doesUserExists + '(UserName=\'' + userName + '\')');
            return users.get();
        }

        function getCurrentUser() {
            return currentUser;
        }

        function setCurrentUser(userId) {
            currentUser = userId;
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
    .controller('UserController', function ($scope, $location, $http ,apiPathConfig, routePathConfig, UserService, UserObjectComposer) {

        $scope.performLogin = function (userName) {

            var doesUserExists;
            
            var params = '(UserName=\'' + userName + '\')';

            $http({
                method: 'GET',
                url: apiPathConfig.API_PATH + '/' + apiPathConfig.doesUserExists + params
            }).then(function successCallback(response) {
                if (response.data.value) {
                    UserService.getUserIdByUserName(userName).then(function (response) {
                        var userId = response.value;

                        UserService.setCurrentUser(userId);
                    });
                } else {
                    var userDto = {
                        UserId: 0,
                        UserName: userName
                    };

                    var userObject = UserObjectComposer.generateUserObject(userDto);

                    userDto = UserService.addUser(userObject);
                }
            });

            $location.path(routePathConfig.home);
        }
    });