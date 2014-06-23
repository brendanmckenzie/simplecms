angular.module('SimpleCms.Services')

.service('Page', function () {
    this.__prefix = 'SimpleCms';
    this._title = this.__prefix;

    this.title = function () { return this._title; }

    this.setTitle = function (text) {
        if (text) {
            this._title = text + ' - ' + this.__prefix;
        }
        else {
            this._title = this.__prefix;
        }
    }    
});