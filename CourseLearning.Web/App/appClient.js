(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ui.router',
        'ngResource',
        'LocalStorageModule',
        'ngSanitize'
    ])
        .config(config);

    config.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider', '$httpProvider'];

    function config($locationProvider, $stateProvider, $urlRouterProvider, $httpProvider) {
        $urlRouterProvider.otherwise('/Application/login');

        $stateProvider
            .state('client',
                {
                    abstract: true,
                    url: '/Application',
                    templateUrl: '/App/client/_master/_master.html',
                    controller: 'masterCtrl as masterCtrl'
                })
            .state('landing',
                {
                    url: '/Application/landing',
                    templateUrl: '/App/client/login/landing.html',
                    controller: 'landingCtrl as landingCtrl'
                })
            .state('login',
                {
                    url: '/Application/login',
                    templateUrl: '/App/client/login/login.html',
                    controller: 'loginController as loginController'
                })
            .state('signup',
                {
                    url: '/Application/signup',
                    templateUrl: '/App/client/login/signup.html',
                    controller: 'signupController as signupController'
                })
            .state('client.landing',
                {
                    url: '/landing',
                    templateUrl: '/App/client/login/landing.html',
                    controller: 'landingCtrl as landingCtrl'
                })
            .state('client.courseList',
                {
                    url: '/course',
                    templateUrl: '/App/client/appComponents/course/courseList/courseList.html',
                    controller: 'courseListCtrl as courseListCtrl'
                })
            .state('client.course',
                {
                    url: '/course/:id',
                    templateUrl: '/App/client/appComponents/course/course.html',
                    controller: 'courseCtrl as courseCtrl'
                });

        $httpProvider.interceptors.push('authInterceptorService');

        $locationProvider.html5Mode({
            enabled: true
        });
    }
})();
