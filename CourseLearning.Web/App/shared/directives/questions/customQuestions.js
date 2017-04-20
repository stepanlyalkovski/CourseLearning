(function () {
    'use strict';

    angular
        .module('app')
        .directive('customQuestions', CustomQuestions);

    function CustomQuestions() {
        var directive = {
            restrict: 'E',
            templateUrl: '/App/shared/directives/questions/customQuestions.html',
            scope: {},
            bindToController: { isAdminMode: '=', isPrintable: '=', questions: '=', subject: '=', atLeastOneRequired: '@' },
            controllerAs: 'vm',
            controller: CustomQuestionsCtrl
        };

        return directive;
    }

    CustomQuestionsCtrl.$inject = ['$uibModal', 'appEnum', 'config'];

    function CustomQuestionsCtrl($uibModal, appEnum, appConfig) {
        var vm = this;

        //#region ------------------------------------------------------ Init/Reinit ------------------------------------------- */
        vm.addCustomQuestionClickFn = addCustomQuestionClickFn;
        vm.isAppAdmin = true;//appConfig.constants.isAppAdmin;

        activate();

        function activate() {
            vm.questionControlTypeList = angular.copy(appEnum.questionControlTypes);
            for(var key in vm.questionControlTypeList) {
                if (vm.questionControlTypeList.hasOwnProperty(key)) {
                    if (vm.questionControlTypeList[key].$isHideForStandAloneUsage === true) {
                        delete vm.questionControlTypeList[key];
                    }
                }
            }
        }

        //#endregion

        //#region ------------------------------------------------------ Actions ----------------------------------------------- */
        function addQuestionFn(question) {
            question.questionSeqNum = vm.questions.length;

            vm.questions.push(question);

            refreshQuestionControlTypeCounts();
        }


        //#endregion

        //#region ------------------------------------------------------ DOM/Angular events ------------------------------------ */

        function addCustomQuestionClickFn() {
            var template = angular.copy(vm.modalTemplate);
            template.resolve.additionalData = function () {
                return {
                    title: "Add Custom Question",
                    questionControlTypeList: vm.questionControlTypeList
                };
            };
            var modalInstance = $uibModal.open(template);

            modalInstance.result.then(function (question) {
                addQuestionFn(question);
            });
        }
        //#endregion

        //#region ------------------------------------------------------ Helpers/Angular Filters ------------------------------- */
        function getControlType(question) {
            return _.find(vm.questionControlTypeList, { questionControlTypeId: question.questionControlType });
        }

        //#endregion

        //#region ------------------------------------------------------ Configs / Enums --------------------------------------- */
        vm.modalTemplate = {
            animation: true,
            backdrop: "static",
            keyboard: false,
            templateUrl: "/App/shared/directives/questions/modals/addEditCustomQuestionModal.html",
            controller: "addEditCustomQuestionModalCtrl as vm",
            size: "lg",
            resolve: {
                additionalData: function () {

                }
            }
        };
        //#endregion
    }
})();
