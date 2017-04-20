(function () {
    "use strict";

    angular
        .module("app")
        .directive("radiobuttonQuestionBuilder", RadiobuttonQuestionBuilder);

    RadiobuttonQuestionBuilder.$inject = [];

    function RadiobuttonQuestionBuilder() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/admin/questions/radiobutton/radiobuttonQuestionBuilder.html",
            scope: {},
            bindToController: {
                question: '=',
                countRangeList: '=',
                test: '='
            },
            controllerAs: "vm",
            controller: RadiobuttonQuestionBuilderCtrl
        };

        return directive;
    }

    RadiobuttonQuestionBuilderCtrl.$inject = ['$scope'];

    function RadiobuttonQuestionBuilderCtrl($scope) {
        var vm = this;
        console.log(vm.test);
        vm.setCountRangeFn = setCountRangeFn;

        vm.questionIsRequiredChangeFn = questionIsRequiredChangeFn;

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        activate();

        function activate() {
            if (vm.question && vm.question.controlList && vm.question.controlList.length > 0) {
                vm.countRange = vm.question.controlList.length;
            } else {
                vm.countRange = 2;
            }

            setCountRangeFn();

            registerWatchers();
        }

        //#endregion

        //#region ------------------------------------------------------ Event handlers ---------------------------------------- */

        function registerWatchers() {
            $scope.$watch(function () {
                return $scope.radiobuttonQuestionForm.$$parentForm.$submitted;
            }, function (currentValue) {
                if (currentValue) {
                    $scope.radiobuttonQuestionForm.$setSubmitted();
                }
            });
        }

        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function questionIsRequiredChangeFn() {
            if (vm.question && vm.question.config && vm.question.config.rules && vm.question.config.messages && !vm.question.config.rules.isRequired) {
                vm.question.config.messages.required = null;
            }
        }

        function setCountRangeFn() {
            var idx;
            if (!vm.question.controlList || vm.question.controlList.length === 0) {
                vm.question.controlList = [];
                for (idx = 0; idx < vm.countRange; idx++) {
                    vm.question.controlList[idx] = { $uid: _.uniqueId("ctrlId_") };
                }
            } else {
                if (vm.question.controlList.length > vm.countRange) {
                    vm.question.controlList.splice(vm.countRange);
                } else {
                    for (idx = vm.question.controlList.length; idx < vm.countRange; idx++) {
                        vm.question.controlList[idx] = { $uid: _.uniqueId("ctrlId_") };
                    }
                }
            }
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        vm.validationRules = {
            questionHeading: {
                required: false,
                maxlength: 500
            },
            radiobuttonHeading: {
                maxlength: 500
            },
            requireMessage: {
                maxlength: 250
            }
        };

        //#endregion
    }
})();