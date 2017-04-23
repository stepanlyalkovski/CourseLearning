(function () {
    'use strict';

    angular
        .module('app')
        .factory('modalSvc', modalSvc);

    modalSvc.$inject = ['$http', '$uibModal', 'appEnum'];

    function modalSvc($http, $uibModal, appEnum) {
        var selectActionModalTemplate = {
            animation: true,
            backdrop: "static",
            keyboard: true,
            templateUrl: "/App/admin/appComponents/modals/selectActionModal/selectActionModal.html",
            controller: "selectActionModalCtrl as vm",
            size: "lg",
            resolve: {
                actionItems: function () {
                    return actionItems;
                }
            }
        };

        var createStorageResourceModalTemplate = {
            animation: true,
            backdrop: "static",
            keyboard: true,
            templateUrl: "/App/admin/appComponents/modals/createStorageResourceModal/createStorageResourceModal.html",
            controller: "createStorageResourceModalCtrl as vm",
            size: "lg"
        };

        var createPreviewModalTemplate = {
            animation: true,
            backdrop: "static",
            keyboard: true,
            templateUrl: "/App/admin/appComponents/modals/addEditPreviewModel/addEditPreviewModal.html",
            controller: "addEditPreviewModalCtrl as vm",
            size: "lg"
        };

        var questionModalTemplate = {
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

        // var questionControlTypeList = angular.copy(appEnum.questionControlTypes);
        // for(var key in questionControlTypeList) {
        //     if (questionControlTypeList.hasOwnProperty(key)) {
        //         if (questionControlTypeList[key].$isHideForStandAloneUsage === true) {
        //             delete questionControlTypeList[key];
        //         }
        //     }
        // }

        var service = {
            addSelectActionModal: addSelectActionModal,
            addCreateStorageResourceModal: addCreateStorageResourceModal,
            addCreatePreviewModal: addCreatePreviewModal,
            addCreateQuestionModal: addCreateQuestionModal
        };

        return service;

        function addSelectActionModal(actionItems) {
            var template = angular.copy(selectActionModalTemplate);
            template.resolve.actionItems = function () {
                return actionItems;
            };

            var modalInstance = $uibModal.open(template);
            return modalInstance.result;
        }

        function addCreateStorageResourceModal(storageFolderId) {
            var template = angular.copy(createStorageResourceModalTemplate);
            template.resolve = {
                storageFolderId: function () {
                    return storageFolderId;
                }
            };

            var modalInstance = $uibModal.open(template);
            return modalInstance.result;
        }

        function addCreatePreviewModal(settings) {
            settings.modalName = settings.modalName || 'Preview Model';
            var template = angular.copy(createPreviewModalTemplate);
            template.resolve = {
                settings: function () {
                    return settings;
                }
            };

            var modalInstance = $uibModal.open(template);
            return modalInstance.result;
        }

        function addCreateQuestionModal() {

            var template = angular.copy(questionModalTemplate);
            template.resolve.additionalData = function () {
                return {
                    title: "Add Custom Question",
                    questionControlTypeList: appEnum.questionControlTypes
                };
            };

            return $uibModal.open(template).result;
        }
    }
})();