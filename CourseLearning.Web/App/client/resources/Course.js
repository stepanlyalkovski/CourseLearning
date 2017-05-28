(function () {
    'use strict';

    angular
        .module('app')
        .factory('Course', Course);

    Course.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Course($http, $resource, apiUrlsBuilderSvc) {
        var courseUrl = apiUrlsBuilderSvc.getUrl('course');
        return $resource(courseUrl +'/:id' + '/:subResource', {},
            {
                getModules: {
                    method:'GET',
                    params: {
                        subResource: 'modules'
                    },
                    isArray: true
                }
            });
    }
})();

// id: '@id'