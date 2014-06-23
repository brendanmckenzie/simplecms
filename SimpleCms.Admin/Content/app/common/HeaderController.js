angular.module('SimpleCms.Common')

.controller('HeaderController', ['$scope', 'Page', 'AuthService', function ($scope, Page, AuthService) {
    $scope.Page = Page;
    $scope.AuthService = AuthService;
}]);