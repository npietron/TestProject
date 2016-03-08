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