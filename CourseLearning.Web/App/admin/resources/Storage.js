(function () {
    'use strict';

    angular
        .module('app')
        .factory('Storage', Storage);

    Storage.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function Storage($http, $resource, apiUrlsBuilderSvc) {
        var storageFolderUrl = apiUrlsBuilderSvc.getAdminUrl('storage');
        return $resource(storageFolderUrl, null, {
            get: {
                method:'GET',
                isArray: true
            }
        });
    }
})();