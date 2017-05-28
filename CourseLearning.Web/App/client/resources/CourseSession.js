(function () {
    'use strict';

    angular
        .module('app')
        .factory('CourseSession', CourseSession);

    CourseSession.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function CourseSession($http, $resource, apiUrlsBuilderSvc) {
        var courseSessionUrl = apiUrlsBuilderSvc.getUrl('courseSession');
        return $resource(courseSessionUrl + '/:id');
    }
})();