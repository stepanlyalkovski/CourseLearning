(function () {
    'use strict';

    angular
        .module('app')
        .controller('createStorageResourceModalCtrl', createStorageResourceModalCtrl);

    createStorageResourceModalCtrl.$inject = ['$scope', '$uibModalInstance', 'storageFileSvc', '$timeout', 'storageFolderId'];

    function createStorageResourceModalCtrl($scope, $uibModalInstance, storageFileSvc, $timeout, storageFolderId) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        vm.title = 'Add File';
        vm.currentState = 'create_resource';
        vm.okStateText = 'Continue';
        vm.storageResource = { storageFolderId: storageFolderId };
        vm.resourceFile = {};

        vm.cancelClickFn = cancelClickFn;
        vm.okClickFn = okClickFn;
        vm.uploadFile = uploadFile;

        activate();

        function activate() {

        }
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */
        function okClickFn() {
            // if (!$scope.storageResourceForm.$valid) {
            //     // Highlight the empty fields that are required
            //     $scope.storageResourceForm.$setSubmitted();
            //     return;
            // }

            if (vm.currentState == 'create_resource') {
                vm.currentState = 'upload_file';
                vm.okStateText = 'Add';
                return;
            }

            uploadFile();
        }

        function cancelClickFn() {
            $uibModalInstance.dismiss('cancel');
        }

        function uploadFile() {
            storageFileSvc.uploadFile(vm.resourceFile, vm.storageResource, successUpload, processUpload);
        }

        function successUpload(response) {
            $timeout(function () {
                vm.resourceFile.result = response.data;
                vm.storageResource.file = vm.resourceFile;
                $uibModalInstance.close(vm.storageResource);
            });
        }

        function processUpload(evt) {
            vm.resourceFile.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        //#endregion
    }
})();
