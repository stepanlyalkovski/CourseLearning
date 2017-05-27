(function() {
    'use strict';

    angular
        .module('app')
        .directive('standardPageBuilder', standardPageBuilder);

    standardPageBuilder.$inject = ['$window'];
    
    function standardPageBuilder ($window) {
        var directive = {
            link: link,
            restrict: 'EA',
            templateUrl: '/App/admin/appComponents/lesson/directives/typeBuilders/standardPageBuilder/standardPageBuilder.html',
            controller: standardPageBuilderCtrl,
            scope: {},
            bindToController: {
                lessonPage: '=',
                settings: '='
            },
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

    standardPageBuilderCtrl.$inject = ['apiUrlsBuilderSvc'];
    function standardPageBuilderCtrl(apiUrlsBuilderSvc) {
        var vm = this;
        vm.resourceUrl = apiUrlsBuilderSvc.getAdminUrl('file');
    }

})();