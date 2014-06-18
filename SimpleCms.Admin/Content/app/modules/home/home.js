angular.module('SimpleCms.Modules.Home', [])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('home', {
        url: '/',
        templateUrl: '/content/app/modules/home/home.html',
        controller: 'HomeController'
    });
}])

.controller('HomeController', ['$scope', 'Page', function ($scope, Page) {
    Page.setTitle();
}]);