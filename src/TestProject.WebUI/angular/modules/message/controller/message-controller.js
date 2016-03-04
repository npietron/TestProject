messageModule
    .controller('MessageController', function ($scope, MessageService) {
        $scope.getMessages = function (postId) {
            return MessageService.getMessagesByPostId(postId);
        }

        $scope.addMessage = function (messageDto) {
            return MessageService.addMessage(messageDto);
        }
    });