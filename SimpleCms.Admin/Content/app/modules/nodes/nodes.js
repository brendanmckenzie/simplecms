angular.module('SimpleCms.Modules.Nodes', [])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('nodes', {
        url: '/nodes',
        templateUrl: '/content/app/modules/nodes/nodes.html',
        controller: 'NodesController'
    });
}])

.factory('Nodes', ['$http' ,function ($http) {
    return {
        root: function () {
            return $http.get('/api/nodes');
        },
        get: function (id) {
            return $http.get('/api/nodes/' + id);
        }
    }
}])

.controller('NodesController', ['$scope', 'Page', 'Nodes', function ($scope, Page, Nodes) {
    Page.setTitle('Nodes');

    Nodes.root().success(function (data, status, headers, config) {
        $scope.rootNodes = data;
    });

    $scope.selectNode = function (node) {
        angular.forEach($scope.rootNodes, function (_node) {
            _node.isSelected = false;
        });
        node.isSelected = true;

        Nodes.get(node.id).success(function (data) {
            $scope.selectedNode = data;
        });
    };
}]);