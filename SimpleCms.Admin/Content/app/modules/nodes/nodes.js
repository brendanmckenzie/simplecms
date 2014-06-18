angular.module('SimpleCms.Modules.Nodes', [])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('nodes', {
        url: '/nodes',
        templateUrl: '/content/app/modules/nodes/nodes.html',
        controller: 'NodesController'
    });
}])

.factory('Nodes', ['$http', function ($http) {
    return {
        all: function () {
            return $http.get('/api/nodes');
        },
        get: function (id) {
            return $http.get('/api/nodes/' + id);
        },
        create: function (node) {
            return $http.post('/api/nodes', node);
        },
        update: function (id, node) {
            return $http.put('/api/nodes/' + id, node);
        }
    }
}])

.controller('NodesController', ['$scope', 'Page', 'Nodes', function ($scope, Page, Nodes) {
    Page.setTitle('Nodes');

    $scope.refresh = function () {
        Nodes.all().success(function (data, status, headers, config) {
            $scope.rootNodes = data;
        });
    }

    $scope.refresh();

    $scope.selectNode = function (node) {
        angular.forEach($scope.rootNodes, function (_node) {
            _node.isSelected = false;
        });
        node.isSelected = true;

        Nodes.get(node.Id).success(function (data) {
            $scope.selectedNode = data;
        });
    };

    $scope.addChild = function (node) {
        node.children = node.children || [];

        node.children.push({ title: 'new child' });
    }

    $scope.createNode = {};

    $scope.save = function (node) {
        if (node.Id) {
            Nodes.update(node.Id, node);
        }
        else {
            Nodes.create(node);
        }
    };
}]);