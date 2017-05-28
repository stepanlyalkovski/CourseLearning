(function () {
    'use strict';

    angular
        .module('app')
        .factory('Article', Article);

    Article.$inject = ['$http', '$resource', 'config', 'apiUrlsBuilderSvc'];

    function Article($http, $resource, config, apiUrlsBuilderSvc) {
        var articleUrl = apiUrlsBuilderSvc.getAdminUrl('article');
        return $resource(articleUrl +'/:id', {id: '@id'}, {
            update: {
                method: 'PUT'
            }
        });
    }
})();