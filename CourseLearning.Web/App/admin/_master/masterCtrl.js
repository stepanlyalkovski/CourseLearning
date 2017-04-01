(function () {
    'use strict';

    angular
        .module('app')
        .controller('masterCtrl', masterCtrl);

    masterCtrl.$inject = ['$location']; 

    function masterCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Admin main controller';

        activate();

        function activate() { }
    }
})();
