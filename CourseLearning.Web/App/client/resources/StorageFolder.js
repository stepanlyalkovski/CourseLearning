(function () {
    'use strict';

    angular
        .module('app')
        .factory('StorageFolder', StorageFolder);

    StorageFolder.$inject = ['$http', '$resource', 'apiUrlsBuilderSvc'];

    function StorageFolder($http, $resource, apiUrlsBuilderSvc) {
        var storageFolderUrl = apiUrlsBuilderSvc.getAdminUrl('storageFolder');
        return $resource(storageFolderUrl +'/:id', {id: '@id'}, {
            getFiles: {
                method: 'PUT',
                params: {
                    subResource: 'quizzes'
                },
                isArray: true
            }
        });
    }
})();