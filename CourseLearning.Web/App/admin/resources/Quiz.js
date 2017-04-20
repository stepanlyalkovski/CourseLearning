(function () {
    'use strict';

    angular
        .module('app')
        .factory('Quiz', Quiz);

    Quiz.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Quiz($http, $resource, apiUrlsBuilderSvc) {
        var quizUrl = apiUrlsBuilderSvc.getAdminUrl('quiz');
        return $resource(quizUrl +'/:id', {id: '@quizId'}, {
            update: {
                method: 'PUT'
            }
        });
    }
})();