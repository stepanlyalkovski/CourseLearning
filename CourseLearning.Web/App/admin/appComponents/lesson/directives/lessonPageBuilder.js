(function() {
    'use strict';

    angular
        .module('app')
        .directive('lessonPageBuilder', lessonPageBuilder)
        .controller('lessonPageBuilderCtrl',lessonPageBuilderCtrl);

    lessonPageBuilder.$inject = ['$window'];
    
    function lessonPageBuilder ($window) {
        var directive = {
            link: link,
            templateUrl: '/App/admin/appComponents/lesson/directives/lessonPageBuilder.html',
            controller: lessonPageBuilderCtrl,
            scope: {},
            bindToController: {
                lessonPage: '='
            },
            controllerAs: 'vm',
            restrict: 'EA'
        };
        return directive;

        function link(scope, element, attrs) {
            debugger;
            // scope.$watch('attrs.lessonPage', function (newVal, prevVal) {
            //     // if (newVal == prevVal || newVal == null) {
            //     //     return;
            //     // }
            //     //
            //     //
            // })
        }
    }

    lessonPageBuilderCtrl.$inject = ['modalSvc', 'appEnum'];

    function lessonPageBuilderCtrl(modalSvc, appEnum) {
        var vm = this;
        vm.isCollapsed = false;
        vm.settings = {
            addResourceClick: addResourceClick
        };

        vm.pageTypes = appEnum.lessonPageTypes;

        vm.isQuestionType = isQuestionType;

        function addResourceClick() {
            modalSvc.addCreateStorageResourceModal().then(function(storageResource) {
                debugger;
                //TODO allow multiple resources from client
                vm.lessonPage.storageResources =  []; //vm.lessonPage.storageResources ||
                vm.lessonPage.storageResources.push(storageResource);
            });
        }

        function isQuestionType() {

        }

    }

})();