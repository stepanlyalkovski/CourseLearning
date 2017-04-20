(function () {
    "use strict";

    angular
        .module("app")
        .directive("radiobuttonQuestionAnswer", RadiobuttonQuestionAnswer);

    RadiobuttonQuestionAnswer.$inject = [];

    function RadiobuttonQuestionAnswer() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/client/radiobutton/radiobuttonQuestionAnswer.html",
            require: { form: '^^form' },
            scope: {},
            bindToController: {
                question: "=",
                subject: '=',
                isPrintable: '='
            },
            controllerAs: "vm",
            controller: RadiobuttonQuestionAnswerCtrl
        };

        return directive;
    }

    RadiobuttonQuestionAnswerCtrl.$inject = ['$scope', 'customQuestionsSvc'];

    function RadiobuttonQuestionAnswerCtrl($scope, customQuestionsSvc) {
        var vm = this;

        vm.getQstId = getQstId;
        vm.getCntrlId = getCntrlId;

        vm.selectedControlChange = selectedControlChange;

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        activate();

        function activate() {
            _.each(vm.question.controlList, function(control) {
                control.$answer = customQuestionsSvc.getCustomQuestionAnswer(control, vm.subject);
            });

            vm.selectedControl = _.find(vm.question.controlList, function (control) { return control.$answer.boolVal; });
        }

        //#endregion

        //#region ------------------------------------------------------ Event handlers ---------------------------------------- */

        function selectedControlChange(selectedControl) {
            _.each(vm.question.controlList, function (control) {
                control.$answer.boolVal = (selectedControl === control);
            });
        }

        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function getQstId(question) {
            return question.questionId || question.$uid;
        }

        function getCntrlId(control) {
            return control.questionControlId || control.$uid;
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */
        //#endregion
    }
})();