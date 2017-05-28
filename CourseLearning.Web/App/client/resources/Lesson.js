(function () {
    'use strict';

    angular
        .module('app')
        .factory('Lesson', Lesson);

    Lesson.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Lesson($http, $resource, apiUrlsBuilderSvc) {
        var lessonUrl = apiUrlsBuilderSvc.getAdminUrl('lesson');
        return $resource(lessonUrl +'/:id' + '/:subResource', {id: '@lessonId'}, {
            update: {
                method: 'PUT'
            },
            createPage: {
                method: 'POST',
                params: {
                    subResource: 'pages'
                }
            }
        });
    }
})();