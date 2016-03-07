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