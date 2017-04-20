(function () {
    'use strict';

    angular
        .module('app')
        .factory('modalSvc', modalSvc);

    modalSvc.$inject = ['$http', '$uibModal'];

    function modalSvc($http, $uibModal) {
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

        var service = {
            addSelectActionModal: addSelectActionModal,
            addCreateStorageResourceModal: addCreateStorageResourceModal
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

    }
})();