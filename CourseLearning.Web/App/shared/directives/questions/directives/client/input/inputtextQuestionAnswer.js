(function() {
    "use strict";

    angular
        .module("app")
        .directive("inputtextQuestionAnswer", InputtextQuestionAnswer);

    function InputtextQuestionAnswer() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/client/input/inputtextQuestionAnswer.html",
            scope: {},
            bindToController: { question: "=", subject: '=', isPrintable: '=' },
            controllerAs: "vm",
            controller: InputtextQuestionAnswerCtrl
        };

        return directive;
    }

    InputtextQuestionAnswerCtrl.$inject = ['customQuestionsSvc'];

    function InputtextQuestionAnswerCtrl(customQuestionsSvc) {
        var vm = this;

        vm.bindMetaToSubjectFn = bindMetaToSubjectFn;
        vm.bindRegexFn = bindRegexFn;
        vm.isNoAnswersFn = isNoAnswersFn;
        vm.controlWithAnswerFilter = controlWithAnswerFilter;

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        activate();

        function activate() {
            vm.questionHeading = vm.question.questionHeading;
        }

        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */

        function bindRegexFn(regexPattern) {
            if (regexPattern) {
                return regexPattern.replace(/^\/|\/$/g, '');
            }

            return null;
        }

        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function controlWithAnswerFilter(control) {
            return !isNoAnswerFn(control);
        }

        function isNoAnswersFn() {
            return _.every(vm.question.controlList, isNoAnswerFn);
        }

        function isNoAnswerFn(control) {
            var answer = customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject);
            return answer == null || answer.stringVal == null || answer.stringVal === '';
        }

        function bindMetaToSubjectFn(isolatedScope, control) {
            var answer = customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject);
            isolatedScope.$answer = answer;
            control.$answer = isolatedScope.$answer;
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        vm.validationRules = {
            input: {
                maxlength: 250
            }
        };

        //#endregion
    }
})();