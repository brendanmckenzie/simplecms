angular.module('SimpleCms.Common.HeaderController', [])

.controller('HeaderController', ['$scope', 'Page', function ($scope, Page) {
    $scope.Page = Page;
}]);