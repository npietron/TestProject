angular.module('app.config', [])
    .constant('apiPathConfig', {
        API_PATH: '/TEST_Service/api',
        users: '/User',
        messages: '/Message',
        posts: '/Post',
        addUser: '/AddUser',
        addPost: '/AddPost',
        addMessage: '/AddMessage',
        userById: '/GetUserById',
        postById: '/GetPostById',
        postsByUserId: '/GetPostsByUserId',
        messagesByUserId: '/GetMessagesByUserId',
        messagesByPostId: '/GetMessagesByPostId'
    })