(function () {
    'use strict';

    angular
        .module('app')
        .controller('addEditCourseModalCtrl', addEditCourseModalCtrl);

    addEditCourseModalCtrl.$inject = ['$scope', '$uibModalInstance'];

    function addEditCourseModalCtrl($scope, $uibModalInstance) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.previewModel = {};
        vm.title = 'Add Course';
        vm.course = {};

        vm.cancelClickFn = cancelClickFn;
        vm.addClickFn = addClickFn;

        activate();

        function activate() {

        }
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */
        function addClickFn() {
            if (!$scope.addEditCourseModalForm.$valid) {
                // Highlight the empty fields that are required
                $scope.addEditCourseModalForm.$setSubmitted();
                return;
            }

            $uibModalInstance.close(vm.course);
        }


        function cancelClickFn() {
            $uibModalInstance.dismiss('cancel');
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        //#endregion
    }
})();
