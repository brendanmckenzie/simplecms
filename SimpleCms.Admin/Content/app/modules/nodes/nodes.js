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
        $scope.selectedNode = node;
    };

    $scope.addChild = function (node) {
        node.children = node.children || [];

        var newNode = { Title: '<new>', Parent: node.Id, ParentNode: node };

        node.children.push(newNode);

        $scope.selectNode(newNode)
    }

    $scope.save = function (node) {
        if (node.Id) {
            Nodes.update(node.Id, node);
        }
        else {
            Nodes.create(node);
        }
    };

    $scope.getIcon = function (node) {
        if (node == $scope.selectedNode) {
            if (node.children) {
                return 'fa-folder-open-o';
            }
            else {
                return 'fa-file-text';
            }
        }
        else {
            if (node.children) {
                var hasChildSelected = function (node) {
                    var ret = false;
                    if (node.children) {
                        for (var i = 0; i < node.children.length; i++) {
                            var child = node.children[i];
                            if ($scope.selectedNode == child) {
                                ret = true;
                                break;
                            }
                            else {
                                ret = hasChildSelected(child);
                                if (ret) { break; }
                            }
                        }
                    }
                    return ret;
                };

                if (hasChildSelected(node)) {
                    return 'fa-folder-open-o';
                }
                else {
                    return 'fa-folder-o';
                }
            }
            else {
                return 'fa-file-text-o';
            }
        }
    }
}]);