(function () {
    'use strict';

    angular
        .module('app')
        .factory('storageFileSvc', storageFileSvc);

    storageFileSvc.$inject = ['$http', 'appEnum', 'Upload', 'apiUrlsBuilderSvc'];

    function storageFileSvc($http, appEnum, Upload, apiUrlsBuilderSvc) {

        var service = {
            uploadFile: uploadFile
        };

        return service;

        function uploadFile(file, storageResource, successCallback, processCallback) {
            var upload = Upload.upload({
                url: apiUrlsBuilderSvc.getAdminUrl('file'),
                data: { storageResource: Upload.json(storageResource), file: file }
            });

            upload.then(function(response) {
                successCallback(response);
            }, function(response) {
                if (response.status > 0) {
                    throw new Error(response.status + ': ' + response.data);
                }
            }, function(evt) {
                processCallback(evt);
            });

            return upload;
        }
    }
})();