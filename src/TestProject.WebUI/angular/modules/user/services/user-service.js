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