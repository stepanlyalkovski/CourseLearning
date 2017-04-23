(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ui.router',
        'ngResource',
        'ui.bootstrap',
        'ngFileUpload',
        'ui.tinymce'
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
            .state('admin.courseList',
            {
                url: '/course',
                templateUrl: '/App/admin/appComponents/course/courseList/courseList.html',
                controller: 'courseListCtrl as courseListCtrl'
            })
            .state('admin.course',
                {
                    url: '/course/:id',
                    templateUrl: '/App/admin/appComponents/course/course.html',
                    controller: 'courseCtrl as courseCtrl'
                })
            .state('admin.module',
            {
                url: '/module/:id',
                templateUrl: '/App/admin/appComponents/module/module.html',
                controller: 'moduleCtrl as moduleCtrl'
            })
            .state('admin.storage',
                {
                    url: '/storage',
                    templateUrl: '/App/admin/appComponents/storage/storage.html',
                    controller: 'storageCtrl as storageCtrl'
                })
            .state('admin.folder',
                {
                    url: '/folder/:id',
                    templateUrl: '/App/admin/appComponents/storage/folders/folder.html',
                    controller: 'folderCtrl as folderCtrl'
                })
            .state('admin.article',
                {
                    url: '/article',
                    templateUrl: '/App/admin/appComponents/articles/articleList.html',
                    controller: 'articleListCtrl as articleListCtrl'
                })
            .state('admin.questionList',
                {
                    url: '/question',
                    templateUrl: '/App/admin/appComponents/question/questionList.html',
                    controller: 'questionListCtrl as questionListCtrl'
                })
            .state('admin.quiz',
                {
                    url: '/quiz/:id',
                    params : { createdQuiz: null },
                    templateUrl: '/App/admin/appComponents/quiz/quiz.html',
                    controller: 'quizCtrl as quizCtrl'
                })
            .state('admin.lesson',
                {
                    url: '/lesson/:id',
                    params : { createdQuiz: null },
                    templateUrl: '/App/admin/appComponents/lesson/lesson.html',
                    controller: 'lessonCtrl as lessonCtrl'
                });
        $urlRouterProvider.otherwise('admin/course');
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
