(function () {
    'use strict';

    angular
        .module('app')
        .controller('addEditCustomQuestionModalCtrl', AddEditCustomQuestionModalCtrl);

    AddEditCustomQuestionModalCtrl.$inject = ['$scope', '$uibModalInstance', 'additionalData'];

    function AddEditCustomQuestionModalCtrl($scope, $uibModalInstance, additionalData) {
        /* jshint validthis:true */
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.cancelClickFn = cancelClickFn;
        vm.addClickFn = addClickFn;
        vm.getOkButtonTitleFn = getOkButtonTitleFn;
        vm.subject = {};
        vm.isEditMode = false;
     
        activate();

        function activate() {
            vm.questionControlTypeList = additionalData.questionControlTypeList;
            vm.title = additionalData.title;
            vm.currentState = additionalData.initialState || "select_type";

            if (additionalData.question != null) {
                vm.isEditMode = true;
                vm.question = angular.copy(additionalData.question);
                vm.question.questionControlType = _.find(vm.questionControlTypeList, { questionControlTypeId: additionalData.question.questionControlType }).questionControlTypeId;
            } else {
                vm.question = {
                    questionHeading: "",
                    $uid: _.uniqueId("qstId_"),
                    questionControlType: null,
                    controlList: []
                }
            }
        }
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */
        function addClickFn() {
            if (!$scope.frmAddCustomQuestionModal.$valid) {
                // Highlight the empty fields that are required
                $scope.frmAddCustomQuestionModal.$setSubmitted();
                return;
            }
            if (vm.currentState === "select_type") {
                vm.currentState = "configure_question";
                var questionControlType = _.find(vm.questionControlTypeList, { questionControlTypeId: vm.question.questionControlType });
                vm.title = "Add Custom " + questionControlType.name + (questionControlType.$count + 1);

                //Make form pristine again
                $scope.frmAddCustomQuestionModal.$setPristine();
                return;
            }

            if(vm.currentState == "configure_question") {
                vm.currentState = 'configure_answer';
                $scope.frmAddCustomQuestionModal.$setPristine();
                return;
            }

            setQuestionAnswer();

            $uibModalInstance.close(vm.question);
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

        function getOkButtonTitleFn() {
            if (vm.currentState === "select_type") {
                return 'Next';
            }

            return vm.isEditMode ? 'Save' : 'Add';
        }
        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */
        vm.validationRules = {
            questionControlTypeList: {
                required: true
            }
        };

        vm.autoFocusConfig = {
            target: [{
                selector: '.vsi-input-validate.ng-invalid',
                scrollTo: '.form-group'
            }],
            isFocusWithoutScrolling: true
        };
        //#endregion
    }
})();
