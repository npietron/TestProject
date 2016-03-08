postModule
    .factory('PostObjectComposer', function () {

        return {
            generatePostObject: generatePostObject
        };

        function generatePostObject(data) {
            return {
                Request: {
                    PostId: data.UserId,
                    Content: data.Content
                }
            }
        }

    });