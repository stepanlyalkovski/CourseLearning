(function () {
    'use strict';

    angular
        .module('app')
        .factory('Course', Course);

    Course.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Course($http, $resource, apiUrlsBuilderSvc) {
        var courseUrl = apiUrlsBuilderSvc.getAdminUrl('course');
        return $resource(courseUrl +'/:id' + '/:subResource', {},
            {
                getModules: {
                    method:'GET',
                    params: {
                        subResource: 'modules'
                    },
                    isArray: true
                },
                addModule: {
                    method:'POST',
                    params: {
                        subResource: 'modules'
                    }
                }
            });
    }
})();

// id: '@id'