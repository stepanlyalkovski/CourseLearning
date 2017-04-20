(function () {
    'use strict';

    angular
        .module('app')
        .factory('questionSvc', questionSvc);

    questionSvc.$inject = ['$http', 'appEnum', '$uibModal'];

    function questionSvc($http, appEnum, $uibModal) {
        var questionControlTypeList = null;
        var modalTemplate = {
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

        var service = {
            addQuestionModal: addQuestionModal
        };

        getControlTypes();

        return service;

        function addQuestionModal() {
            var template = angular.copy(modalTemplate);
            template.resolve.additionalData = function () {
                return {
                    title: "Add Custom Question",
                    questionControlTypeList: questionControlTypeList
                };
            };

            return $uibModal.open(template);
        }

        function getControlTypes() {
            questionControlTypeList = angular.copy(appEnum.questionControlTypes);
            for(var key in questionControlTypeList) {
                if (questionControlTypeList.hasOwnProperty(key)) {
                    if (questionControlTypeList[key].$isHideForStandAloneUsage === true) {
                        delete questionControlTypeList[key];
                    }
                }
            }
        }
    }
})();