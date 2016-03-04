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
    .config(function ($routeProvider) {
        $routeProvider.when('/login', {
            templateUrl: "views/userLogin.html"
        });
        $routeProvider.when('/main', {
            templateUrl: "views/main.html"
        });
        $routeProvider.when('/details', {
            templateUrl: "views/postDetails.html"
        });
        $routeProvider.otherwise('/details', {
            redirectTo: "/login"
        });
    });