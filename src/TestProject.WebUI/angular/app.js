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
            templateUrl: "angular/views/userLogin.html",
            controller: "UserController"
        })
        .when(routePathConfig.home, {
            templateUrl: "angular/views/home.html",
            controller: "PostController"
        })
        .when(routePathConfig.details, {
            templateUrl: "angular/views/postDetails.html",
            controller: "MessageController"
        })
        .otherwise({
            redirectTo: routePathConfig.login
        }); 
    });