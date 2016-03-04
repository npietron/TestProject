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
            $location.path('/main');
        }

    });