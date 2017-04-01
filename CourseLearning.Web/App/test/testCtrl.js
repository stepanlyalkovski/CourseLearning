(function () {
    'use strict';

    angular
        .module('app')
        .controller('testCtrl', testCtrl);

    testCtrl.$inject = ['$location', '$http', 'config'];

    function testCtrl($location, $http, config) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'testCtrl';
        vm.values = null;
        activate();

        function activate() {
            var getTestProm = $http.get(config.apiUrl + 'api/Test');

            getTestProm.then(function(response) {
                console.log('Loading completed!');
                vm.values = response.data;
            });
        }
    }
})();
