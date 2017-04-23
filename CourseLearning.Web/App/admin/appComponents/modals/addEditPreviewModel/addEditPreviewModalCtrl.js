(function () {
    'use strict';

    angular
        .module('app')
        .controller('addEditPreviewModalCtrl', addEditPreviewModalCtrl);

    addEditPreviewModalCtrl.$inject = ['$scope', '$uibModalInstance', 'settings'];

    function addEditPreviewModalCtrl($scope, $uibModalInstance, settings) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.previewModel = {};
        vm.title = settings.isEditMode ? 'Edit ' : 'Add ' + settings.modelName;

        vm.cancelClickFn = cancelClickFn;
        vm.addClickFn = addClickFn;

        activate();

        function activate() {

        }
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */
        function addClickFn() {
            if (!$scope.addEditPreviewModalForm.$valid) {
                // Highlight the empty fields that are required
                $scope.addEditPreviewModalForm.$setSubmitted();
                return;
            }

            $uibModalInstance.close(vm.previewModel);
        }


        function cancelClickFn() {
            $uibModalInstance.dismiss('cancel');
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        //#endregion
    }
})();
