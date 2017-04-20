(function() {
    "use strict";

    angular
        .module("app")
        .directive("inputtextQuestionBuilder", InputtextQuestionBuilder);

    function InputtextQuestionBuilder() {
        var directive = {
            restrict: "E",
            templateUrl: "/App/shared/directives/questions/directives/admin/questions/input/inputtextQuestionBuilder.html",
            scope: {},
            bindToController: { question: "=", countRangeList: "=" },
            controllerAs: "vm",
            controller: InputtextQuestionBuilderCtrl
        };

        return directive;
    }

    InputtextQuestionBuilderCtrl.$inject = ["$scope"];

    function InputtextQuestionBuilderCtrl($scope) {
        var vm = this;
        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */

        vm.setCountRangeFn = setCountRangeFn;
        vm.singleMode = true;
        vm.cleanModelOnFalsyValueFn = cleanModelOnFalsyValueFn;
        activate();

        function activate() {
            vm.countRange = vm.question.controlList.length > 0 ? vm.question.controlList.length : 1;
            setCountRangeFn();
        }

        $scope.$watch(function() {
            return $scope.inputQuestion.$$parentForm.$submitted;
        }, function(currentValue) {
            if (currentValue) {
                $scope.inputQuestion.$setSubmitted();
            }
        });

        //#endregion

        //#region ------------------------------------------------------ Actions ----------------------------------------------- */

        function setCountRangeFn() {
            var idx;
            if (!vm.question.controlList || vm.question.controlList.length === 0) {
                //create new array
                vm.question.controlList = [];
                for (idx = 0; idx < vm.countRange; idx++) {
                    vm.question.controlList[idx] = { $uid: _.uniqueId("ctrlId_") };
                }
            } else {
                //selected count less than array length, remove items
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

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */

        function cleanModelOnFalsyValueFn(flg, objs) {
            //Local function to check model and prop and cleanup it
            function checkAndCleanupFn(obj) {
                if (obj.model && obj.prop) {
                    obj.model[obj.prop] = null;
                }
            }

            if (flg === false && objs != null) {
                //Single property
                if (!_.isArray(objs)) {
                    checkAndCleanupFn(objs);
                } else {
                    _.forEach(objs, function(obj) {
                        checkAndCleanupFn(obj);
                    });
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
            inputHeading: {
                maxlength: 500
            },
            requiredValidationMessage: {
                maxlength: 250
            },
            pattern: {
                maxlength: 500
            },
            patternValidationMessage: {
                maxlength: 250
            }
        };

        //#endregion
    }
})();