(function () {
    'use strict';

    angular
        .module('app')
        .controller('folderCtrl', folderCtrl);

    folderCtrl.$inject = ['$location', 'StorageFolder', '$state', '$scope', 'Upload', '$timeout', 'apiUrlsBuilderSvc', 'modalSvc'];

    function folderCtrl($location, StorageFolder, $state, $scope, Upload, $timeout, apiUrlsBuilderSvc, modalSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'folderCtrl';
        vm.folder = null;
        vm.file = null;

        vm.addStorageResource = addStorageResource;

        var storageResource = {
            name: 'myAwesomeFile'
        };

        $scope.uploadFiles = function(file, errFiles) {
            $scope.f = file;
            $scope.errFile = errFiles && errFiles[0];
            if (file) {
                file.upload = Upload.upload({
                    url: apiUrlsBuilderSvc.getAdminUrl('file'),
                    data: {file: file, storageResource: Upload.json(storageResource)}
                });

                file.upload.then(function (response) {
                    $timeout(function () {
                        file.result = response.data;
                    });
                }, function (response) {
                    if (response.status > 0)
                        $scope.errorMsg = response.status + ': ' + response.data;
                }, function (evt) {
                    file.progress = Math.min(100, parseInt(100.0 *
                        evt.loaded / evt.total));
                });
            }
        };

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var storageFolderId = $state.params.id;
            vm.folder = StorageFolder.get({id: storageFolderId});
            storageResource.storageFolderId = storageFolderId
        }

        function addStorageResource() {
            var modalResult = modalSvc.addCreateStorageResourceModal(vm.folder.storageFolderId);
            modalResult.then(function(storageResource) {
                storageResource.storageResourceId = storageResource.file.result.storageResourceId;
                vm.folder.resources.push(storageResource);
            })
        }
    }
})();
