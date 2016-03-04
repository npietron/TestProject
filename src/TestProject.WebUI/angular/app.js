var app = angular.module('mainApp',
    [
        'restangular',
        "ngRoute",
        'app.config',
        'user',
        'post',
        'message'
    ])
    .config(function (RestangularProvider, apiPathConfig) {
        RestangularProvider.setBaseUrl(apiPathConfig.API_PATH);
    })
    .config(function ($routeProvider, routePathConfig) {
        $routeProvider.when(routePathConfig.login, {
            templateUrl: "views/userLogin.html",
            controller: "UserController"
        });
        $routeProvider.when(routePathConfig.home, {
            templateUrl: "views/home.html",
            controller: "PostController"
        });
        $routeProvider.when(routePathConfig.details, {
            templateUrl: "views/postDetails.html",
            controller: "MessageController"
        });
        $routeProvider.otherwise(routePathConfig.details, {
            redirectTo: routePathConfig.login
        }); 
    });