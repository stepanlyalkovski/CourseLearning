(function () {
    'use strict';

    angular
        .module('app')
        .factory('courseSvc', courseSvc);

    courseSvc.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function courseSvc($http, $resource, apiUrlsBuilderSvc) {
        var courseUrl = apiUrlsBuilderSvc.getAdminUrl('course');
        var Course = $resource(courseUrl +'/:id' + '/:subResource', { id: '@id'},
            {
                modules: {
                    method:'GET',
                    params: {
                        subResource: 'modules'
                    },
                    isArray: true
                }
            });

        var service = {
            getCourseResource: getCourseResource
        };

        return service;

        function getCourseResource() {
            return Course;
        }
    }
})();