(function () {
    'use strict';



    angular
        .module('app')
        .controller('mainCtrl', mainCtrl);

    mainCtrl.$inject = ['$location', '$scope', '$route', '$routeParams', 'MyService'];

    function mainCtrl($location, $scope, $route, $routeParams, MyService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'mainCtrl';

        activate();

        function activate() {
            MyService.setName('qwerty');
            $scope.$route = $route;
            $scope.$location = $location;
            $scope.$routeParams = $routeParams;
        }
    }
})();
