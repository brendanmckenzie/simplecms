angular.module('SimpleCms.Services')

.service('Session', function () {
    this.create = function (token, user) {
        this.user = user;
    };
    this.destroy = function () {
        this.user = null;
    };
    return this;
})