(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ui.router'
    ])
        .config(config);

    config.$inject = ['$routeProvider', '$locationProvider', '$stateProvider', '$urlRouterProvider'];

    function config($routeProvider, $locationProvider, $stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/check');

        // $stateProvider
        //     .state('test',
        //     {
        //         url: '/Application/test',
        //         templateUrl: '/App/test/test.html',
        //         controller: 'testCtrl as testC'
        //     });
        //$routeProvider
        //    .when('/Application/test', {
        //        templateUrl: '/App/test/test.html',
        //        controller: 'testCtrl as testC'
        //    });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }
})();
