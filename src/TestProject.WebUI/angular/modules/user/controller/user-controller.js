userModule
    .controller('UserController', function ($scope, $location, UserService, UserObjectComposer) {

        $scope.performLogin = function (userName) {
            var userExists = UserService.doesUserExists(userName);

            if (!userExists.restangularCollection) {
                var userDto = {
                    UserId: 0,
                    UserName: userName
                };

                UserService.addUser(UserObjectComposer.generateUserObject(userDto));
            }
            $location.path('/home');
        }
    });