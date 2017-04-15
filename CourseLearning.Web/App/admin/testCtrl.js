(function () {
    'use strict';

    angular
        .module('app')
        .controller('testCtrl', testCtrl);

    testCtrl.$inject = ['$location', '$http', 'config'];

    function testCtrl($location, $http, config) {
        /* jshint validthis:true */
        var vm = this;
        activate();

        function activate() {

        }
    }
})();
