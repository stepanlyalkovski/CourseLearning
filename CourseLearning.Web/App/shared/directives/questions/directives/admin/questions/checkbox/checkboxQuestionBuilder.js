(function () {
    "use strict";

    angular
        .module("app")
        .directive("checkboxQuestionBuilder", CheckboxQuestionBuilder);

    function CheckboxQuestionBuilder() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/admin/questions/checkbox/checkboxQuestionBuilder.html",
            scope: {},
            bindToController: {
                question: "=",
                countRangeList: "="
            },
            controllerAs: "vm",
            controller: CheckboxQuestionBuilderCtrl
        };

        return directive;
    }

    CheckboxQuestionBuilderCtrl.$inject = ["$scope"];

    function CheckboxQuestionBuilderCtrl($scope) {
        var vm = this;

        vm.setCountRangeFn = setCountRangeFn;

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        activate();

        function activate() {
            vm.countRange = vm.question.controlList.length > 0 ? vm.question.controlList.length : null;
            vm.otherLabel = "Other";

            if (vm.question && vm.question.controlList && vm.question.controlList.length > 0) {
                if (!_.isNil(vm.question.config) && vm.question.config.rules.isOtherCheckbox) {
                    vm.countRange = vm.question.controlList.length - 1;
                } else {
                    vm.countRange = vm.question.controlList.length;
                }
            } else {
                vm.countRange = 1;
            }

            setCountRangeFn();

            registerWatchers();
        }

        //#endregion

        //#region ------------------------------------------------------ Event handlers ---------------------------------------- */

        function registerWatchers() {
            $scope.$watch("chbx.question.config.rules.isRequired", function (newValue, oldValue) {
                if (oldValue === newValue) {
                    return;
                }
                if (!newValue && !_.isNil(vm.question.config.messages)) {
                    vm.question.config.messages.required = null;
                }
            });

            $scope.$watch("vm.question.config.rules.isOtherCheckbox", function (newValue, oldValue) {
                if (oldValue === newValue) {
                    return;
                }

                if ((_.isNil(oldValue) || oldValue === false) && newValue === true) {
                    addOtherCheckbox();
                }

                if (oldValue === true && newValue === false) {
                    vm.question.controlList = deleteOtherCheckboxes(vm.question.controlList);
                }
            });

            $scope.$watch(function () {
                return $scope.chbxQuestion.$$parentForm.$submitted;
            }, function (currentValue) {
                if (currentValue) {
                    $scope.chbxQuestion.$setSubmitted();
                }
            });
        }

        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function setCountRangeFn() {
            if (!vm.question.controlList || vm.question.controlList.length === 0) {
                vm.question.controlList = [];

                setUpUids(0, vm.countRange);
                return;
            }

            if (vm.question.controlList.length > vm.countRange) {
                vm.question.controlList.splice(vm.countRange);

                if (!_.isNil(vm.question.config) && vm.question.config.rules.isOtherCheckbox) {
                    addOtherCheckbox();
                }

                return;
            }

            if (!_.isNil(vm.question.config) && vm.question.config.rules.isOtherCheckbox) {
                vm.question.controlList = deleteOtherCheckboxes(vm.question.controlList);

                setUpUids(vm.question.controlList.length, vm.countRange);

                addOtherCheckbox();
                return;
            }

            setUpUids(vm.question.controlList.length, vm.countRange);
        }

        function setUpUids(idx, end) {
            for (var i = idx; i < end; i++) {
                vm.question.controlList[i] = { $uid: _.uniqueId("ctrlId_") };
            }
        }

        function deleteOtherCheckboxes(arr) {
            return _.filter(arr, function (control) {
                return _.isNil(control.config) || !control.config.rules.isHidden;
            });
        }

        function addOtherCheckbox() {
            vm.question.controlList.push({
                $uid: _.uniqueId("ctrlId_"),
                controlHeading: vm.otherLabel,
                config: {
                    rules: {
                        isHidden: true
                    }
                }
            });
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */

        vm.validationRules = {
            questionHeading: {
                required: false,
                maxlength: 500
            },
            checkboxHeading: {
                maxlength: 500
            },
            requireMessage: {
                maxlength: 250
            }
        };

        //#endregion
    }
})();