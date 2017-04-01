(function () {
    'use strict';

    angular
        .module('app')
        .controller('mainCtrl', mainCtrl);

    mainCtrl.$inject = ['$location', '$scope', '$route', '$routeParams'];

    function mainCtrl($location, $scope, $route, $routeParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'mainCtrl';

        activate();

        function activate() {
            $scope.$route = $route;
            $scope.$location = $location;
            $scope.$routeParams = $routeParams;
        }
    }
})();
