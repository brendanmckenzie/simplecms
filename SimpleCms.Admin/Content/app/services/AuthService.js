angular.module('SimpleCms.Services')

.factory('AuthService', ['$http', 'Session', function ($http, Session) {
    return {
        login: function (credentials) {
            return $http
              .post('/api/login', credentials)
              .then(function (res) {
                  Session.create(res.token, res.user);
              });
        },

        isAuthenticated: function () {
            return !!Session.userId;
        }
    };
}])