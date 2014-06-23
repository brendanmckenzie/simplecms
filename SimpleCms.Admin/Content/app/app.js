var app = angular.module('SimpleCms',
    [
        'ui.router',
        'SimpleCms.Modules.Home',
        'SimpleCms.Modules.Nodes',
        'SimpleCms.Common',
        'SimpleCms.Services']);

app.config(['$urlRouterProvider', '$locationProvider', function ($urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');

    $locationProvider.html5Mode(true);
}]);