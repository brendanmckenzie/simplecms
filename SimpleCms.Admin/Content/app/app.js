var app = angular.module('SimpleCms',
    [
        'ui.router',
        'SimpleCms.Modules.Home',
        'SimpleCms.Modules.Nodes',
        'SimpleCms.Common.HeaderController',
        'SimpleCms.Common.NavigationController',
        'SimpleCms.Page']);

app.config(['$urlRouterProvider', '$locationProvider', function ($urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');

    $locationProvider.html5Mode(true);
}]);