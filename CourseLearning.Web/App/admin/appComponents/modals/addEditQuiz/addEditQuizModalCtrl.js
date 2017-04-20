(function () {
    'use strict';

    angular
        .module('app')
        .controller('addEditQuizModalCtrl', addEditQuizModalCtrl);

    addEditQuizModalCtrl.$inject = ['$scope', '$uibModalInstance', 'additionalData'];

    function addEditQuizModalCtrl($scope, $uibModalInstance, additionalData) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.cancelClickFn = cancelClickFn;
        vm.addClickFn = addClickFn;
        vm.isEditMode = false;
        vm.quiz = {};
        vm.title = 'Add Quiz';

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

        function setQuestionAnswer() {
            _.each(vm.question.controlList, function (control) {
                control.isRight = control.$answer.boolVal;
                control.answerValue = control.$answer.stringVal;
            });
        }

        function cancelClickFn() {
            $uibModalInstance.dismiss('cancel');
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        //#endregion
    }
})();
