(function () {
    'use strict';

    var config = {
        adminUrls: {
            course: '/api/admin/course',
            module: '/api/admin/module',
            article: '/api/admin/article',
            question: '/api/admin/question',
            quiz: '/api/admin/quiz',
            storage: '/api/admin/storage',
            storageFolder: '/api/admin/storageFolder',
            file: '/api/admin/file'
        },
        apiUrls : {

        }
    };

    angular
        .module('app')
        .constant('config', config);
})();