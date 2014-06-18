angular.module('SimpleCms.Page', []).factory('Page', function () {
    var prefix = 'SimpleCms';
    var title = prefix;
    
    return {
        title: function () { return title; },
        setTitle: function (text) {
            if (text) {
                title = text + ' - ' + prefix;
            }
            else {
                title = prefix;
            }
        }
    }
});