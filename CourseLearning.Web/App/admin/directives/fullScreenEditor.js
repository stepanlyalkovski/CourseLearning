(function() {
    'use strict';

    angular
        .module('app')
        .directive('fullScreenEditor', fullScreenEditor)
        .controller('fullScreenEditorCtrl', fullScreenEditorCtrl);

    fullScreenEditor.$inject = ['$window'];
    
    function fullScreenEditor ($window) {
        // Usage:
        //     <fullScreenEditor></fullScreenEditor>
        // Creates:
        // 
        var directive = {
            link: link,
            templateUrl: '/App/admin/directives/fullScreenEditor.html',
            transclude: true,
            controller: fullScreenEditorCtrl,
            scope: true,
            bindToController: {
                settings: '='
            },
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

    fullScreenEditorCtrl.$inject = [];

    function fullScreenEditorCtrl() {
        var vm = this;
        vm.title = 'fullScreenEditorCtrl';
        vm.okClick = okClick;
        activate();

        function activate() { }

        function okClick() {
            vm.settings.okCallbak();
        }
    }

})();