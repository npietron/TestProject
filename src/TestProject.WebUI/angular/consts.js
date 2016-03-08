angular.module('app.config', [])
    .constant('apiPathConfig', {
        API_PATH: 'http://localhost\:5200/TEST_Service/api',
        users: 'User',
        messages: 'Message',
        posts: 'Post',
        addUser: 'AddUser',
        addPost: 'AddPost',
        addMessage: 'AddMessage',
        userById: 'GetUserById',
        userIdByUserName: 'GetUserIdByUserName',
        postById: 'GetPostById',
        postsByUserId: 'GetPostsByUserId',
        messagesByUserId: 'GetMessagesByUserId',
        messagesByPostId: 'GetMessagesByPostId',
        doesUserExists: 'DoesUserExists'
    })
    .constant('routePathConfig', {
        login: '/login',
        home: '/home',
        details: '/details'
    })
    .constant('states', {
        home: 'home',
        login: 'login',
        details: 'details'
    });