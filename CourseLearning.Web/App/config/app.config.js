(function () {
    'use strict';

    var config = {
        adminUrls: {
            course: '/api/admin/course',
            module: '/api/admin/module',
            article: '/api/admin/article',
            question: '/api/admin/question',
            quiz: '/api/admin/quiz',
            lesson: '/api/admin/lesson',
            storage: '/api/admin/storage',
            storageFolder: '/api/admin/storageFolder',
            file: '/api/admin/file'
        },
        apiUrls : {
            course: '/api/client/course',
            enrollment: '/api/client/enrollment',
            courseSession: '/api/client/courseSession'
        }
    };

    angular
        .module('app')
        .constant('config', config);
})();