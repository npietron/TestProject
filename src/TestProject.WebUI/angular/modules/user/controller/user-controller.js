userModule
    .controller('UserController', function ($scope, $location,routePathConfig, UserService, UserObjectComposer) {

        $scope.performLogin = function (userName) {
            var doesUserExists;

            UserService.doesUserExists(userName).then(function (response) {
                doesUserExists = response.Value;
            });

            if (!doesUserExists) {
                var userDto = {
                    UserId: 0,
                    UserName: userName
                };

                var userObject = UserObjectComposer.generateUserObject(userDto);

                userDto = UserService.addUser(userObject);

                UserService.setCurrentUser(userDto.UserId);
            } else {
                UserService.setCurrentUser(UserService.getUserIdByUserName(userName));
            }
            $location.path(routePathConfig.home);
        }
    });