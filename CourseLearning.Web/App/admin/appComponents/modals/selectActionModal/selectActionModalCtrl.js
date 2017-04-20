(function () {
    'use strict';

    angular
        .module('app')
        .controller('selectActionModalCtrl', selectActionModalCtrl);

    selectActionModalCtrl.$inject = ['$scope', '$uibModalInstance', 'actionItems'];

    function selectActionModalCtrl($scope, $uibModalInstance, actionItems) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.cancelClickFn = cancelClickFn;
        vm.addClickFn = addClickFn;
        vm.isEditMode = false;
        vm.quiz = {};
        vm.title = 'Select Action';
        vm.actionItems = actionItems;
        vm.selectAction = selectAction;

        activate();

        function activate() {

        }
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */
        function addClickFn() {
            if (!$scope.addEditQuizModalForm.$valid) {
                // Highlight the empty fields that are required
                $scope.addEditQuizModalForm.$setSubmitted();
                return;
            }



            $uibModalInstance.close(vm.quiz);
        }

        function cancelClickFn() {
            $uibModalInstance.dismiss('cancel');
        }

        function selectAction(action) {
            $uibModalInstance.close(action);
        }
        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        //#endregion
    }
})();
