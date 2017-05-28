(function () {
    'use strict';

    angular
        .module('app')
        .factory('Module', Module);

    Module.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Module($http, $resource, apiUrlsBuilderSvc) {
        var moduleUrl = apiUrlsBuilderSvc.getAdminUrl('module');
        return $resource(moduleUrl +'/:id' + '/:subResource', {id: '@courseId'},
            {
                getQuizzes: {
                    method:'GET',
                    params: {
                        subResource: 'quizzes'
                    },
                    isArray: true
                },
                addQuiz: {
                    method:'POST',
                    params: {
                        subResource: 'quizzes'
                    }
                },
                getArticles: {
                    method:'GET',
                    params: {
                        subResource: 'articles'
                    },
                    isArray: true
                },
                addArticle: {
                    method:'POST',
                    params: {
                        subResource: 'articles'
                    }
                },
                getLessons: {
                    method:'GET',
                    params: {
                        subResource: 'lessons'
                    },
                    isArray: true
                },
                addLesson: {
                    method:'POST',
                    params: {
                        subResource: 'lessons'
                    }
                }
            });
    }
})();