(function () {
    "use strict";

    angular
        .module("app")
        .directive("checkboxQuestionAnswer", CheckboxQuestionAnswer);

    CheckboxQuestionAnswer.$inject = [];

    function CheckboxQuestionAnswer() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/client/checkbox/checkboxQuestionAnswer.html",
            require: { form: "^^form" },
            scope: {},
            bindToController: {
                question: "=",
                subject: '=',
                isPrintable: '='
            },
            controllerAs: "vm",
            controller: CheckboxQuestionAnswerCntrl
        };

        return directive;
    }

    CheckboxQuestionAnswerCntrl.$inject = ['$scope', 'customQuestionsSvc'];

    function CheckboxQuestionAnswerCntrl($scope, customQuestionsSvc) {
        var vm = this;

        vm.isPrintableHeaderNeeded = isPrintableHeaderNeeded;
        vm.bindMetaToSubject = bindMetaToSubject;
        vm.isOtherCheckboxFilled = isOtherCheckboxFilled;
        vm.generateHeadingPreview = generateHeadingPreview;
        vm.isRequiredErrorVisible = isRequiredErrorVisible;

        vm.requiredValidation = false;
        vm.filteredList = [];
        vm.otherCheckboxRequiredErrorMsg = {
            required: 'Please enter the value for "Other" option.'
        };

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */

        function isPrintableHeaderNeeded() {
            var tempArr = _.filter(vm.question.controlList, function (control) {
                return customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject).boolVal;
            });

            return tempArr.length > 0;
        }

        function generateHeadingPreview() {
            var tempArr = _.filter(vm.question.controlList, function (control, index) {
                if (index === vm.question.controlList.length - 1 && isOtherCheckboxFilled()) {
                    return false;
                }

                return customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject).boolVal;
            });

            var preview = _.map(tempArr, 'controlHeading');

            if (isOtherCheckboxFilled()) {
                preview.push(customQuestionsSvc
                    .getCustomQuestionAnswer(vm.question.controlList[vm.question.controlList.length - 1], vm.subject)
                    .stringVal);
            }

            return _.join(preview, ', ');
        }

        function bindMetaToSubject(isolatedScope, control) {
            var answer = customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject);
            answer.boolVal = !!answer.boolVal;
            isolatedScope.$answer = answer;
            control.$answer = isolatedScope.$answer;
        }

        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function isRequiredErrorVisible() {
            if (vm.question.config && vm.question.config.rules.isRequired) {
                var result = true;
                vm.requiredValidation = true;
                _.each(vm.question.controlList, function (control) {
                    if (customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject).boolVal) {
                        result = false;
                        vm.requiredValidation = false;
                    }
                });
                return result;
            }
            return false;
        }

        function isOtherCheckboxFilled() {
            return vm.question.controlList.length > 1 && !_.isNil(vm.question.config) && vm.question.config.rules.isOtherCheckbox &&
                customQuestionsSvc.getCustomQuestionAnswer(vm.question.controlList[vm.question.controlList.length - 1], vm.subject).boolVal;
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        vm.validationRules = {
            otherChechkboxTxt: {
                maxlength: 100
            }
        };

        //#endregion
    };
})();