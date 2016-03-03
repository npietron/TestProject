var app = angular.module('mainApp',
    [
        'app.config',
        'restangular'
    ])
    .config(function (RestangularProvider, apiPathConfig) {
        RestangularProvider.setBaseUrl(apiPathConfig.API_PATH);
    })