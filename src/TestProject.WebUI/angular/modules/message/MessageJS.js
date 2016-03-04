var messageModule = angular.module('message', ['app.config']);
messageModule
    .factory('MessageService', function (apiPathConfig, Restangular) {

        return {
            addMessage: addMessage,
            getMessagesByPostId: getMessagesByPostId,
            getMessagesByUserId: getMessagesByUserId
        };

        function addMessage(data) {
            var addMessagePackage = Restangular.all(apiPathConfig.addMessage);
            return addMessagePackage.post(data);
        }

        function getMessagesByPostId(id) {
            var messages = Restangular.one(apiPathConfig.getMessagesByPostId + '(PostId=' + id + ')');
            return messages.get();
        }

        function getMessagesByUserId(id) {
            var messages = Restangular.one(apiPathConfig.getMessagesByUserId + '(UserId=' + id + ')');
            return messages.get();
        }
    });
messageModule
    .controller('MessageController', function ($scope, MessageService) {
        $scope.getMessages = function (postId) {
            return MessageService.getMessagesByPostId(postId);
        }

        $scope.addMessage = function (messageDto) {
            return MessageService.addMessage(messageDto);
        }
    });