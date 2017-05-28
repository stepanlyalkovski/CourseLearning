(function () {
    'use strict';

    angular
        .module('app')
        .factory('Enrollment', Enrollment);

    Enrollment.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Enrollment($http, $resource, apiUrlsBuilderSvc) {
        var enrollmentUrl = apiUrlsBuilderSvc.getUrl('enrollment');
        return $resource(enrollmentUrl + '/:id');
    }
})();