(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ui.router'
    ])
        .config(config);

    config.$inject = ['$routeProvider', '$locationProvider', '$stateProvider', '$urlRouterProvider'];

    function config($routeProvider, $locationProvider, $stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('admin',
            {
                abstract: true,
                url: '/admin',
                templateUrl: '/App/admin/_master/_master.html',
                controller: 'masterCtrl as masterCtrl'
            })
            .state('admin.test',
            {
                url: '/test',
                templateUrl: '/App/test/test.html',
                controller: 'testCtrl as testC'
            })
            .state('admin.course',
            {
                url: '/course',
                templateUrl: '/App/admin/demo/course.html',
                controller: 'courseCtrl as courseCtrl'
            });

        $urlRouterProvider.otherwise('admin/test');
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
