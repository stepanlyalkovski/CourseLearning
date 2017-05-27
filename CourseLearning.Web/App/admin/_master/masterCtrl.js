(function () {
    'use strict';
    angular
        .module('app')
        .controller('masterCtrl', masterCtrl);

    masterCtrl.$inject = ['$location', '$state', 'authService'];

    function masterCtrl($location, $state, authService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Admin CourseLearning';

        activate();
        vm.logOut = logOut;

        function activate() {

        }

        function logOut() {
            authService.logOut();
            $state.go('landing');
        }
    }
})();
