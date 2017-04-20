(function () {
    'use strict';

    angular
        .module('app')
        .factory('Question', Question);

    Question.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Question($http, $resource, apiUrlsBuilderSvc) {
        var questionUrl = apiUrlsBuilderSvc.getAdminUrl('question');
        return $resource(questionUrl +'/:id', {id: '@id'});
    }
})();