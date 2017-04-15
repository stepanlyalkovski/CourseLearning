(function () {
    'use strict';

    angular
        .module('app')
        .factory('apiUrlsBuilderSvc', apiUrlsBuilderSvc);

    apiUrlsBuilderSvc.$inject = ['$window', 'config'];

    function apiUrlsBuilderSvc($window, config) {
        var service = {
            getUrl: getUrl,
            getAdminUrl: getAdminUrl
        };

        return service;

        function getUrl(path) {
            if (!$window.courseLearningWebApiUrl) {
                throw new Error('Invalid WebAPI URI.');
            }

            if (!config.apiUrls[path]) {
                throw new Error('Unable to find url for: ' + path);
            }

            return $window.courseLearningWebApiUrl + config.apiUrls[path];
        }

        function getAdminUrl(path) {
            if (!$window.courseLearningWebApiUrl) {
                throw new Error('Invalid WebAPI URI.');
            }

            if (!config.adminUrls[path]) {
                throw new Error('Unable to find url for: ' + path);
            }

            return $window.courseLearningWebApiUrl + config.adminUrls[path];
        }
    }
})();
