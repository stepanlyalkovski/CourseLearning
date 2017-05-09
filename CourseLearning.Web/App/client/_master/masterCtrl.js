(function () {
    'use strict';
    angular
        .module('app')
        .controller('masterCtrl', masterCtrl);

    masterCtrl.$inject = ['$location', 'MyService'];

    function masterCtrl($location, MyService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Admin main controller';

        activate();

        function activate() {
            MyService.setName('service qwerty');
        }
    }
})();
