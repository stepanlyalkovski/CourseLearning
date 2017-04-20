(function() {
    'use strict';

    angular
        .module('app')
        .directive('fileExplorer', fileExplorer)
        .controller('fileExplorerCtrl', fileExplorerCtrl);

    fileExplorer.$inject = ['$window'];
    
    function fileExplorer ($window) {
        var directive = {
            link: link,
            restrict: 'EA',
            templateUrl: '/App/admin/storage/directives/fileExplorer.html',
            controller: fileExplorerCtrl,
            controllerAs: 'vm'
    };
        return directive;

        function link(scope, element, attrs) {
        }
    }

    fileExplorerCtrl.$inject = [];

    function fileExplorerCtrl() {
        var vm = this;
        vm.title = 'fileExplorerCtrl';

        activate();

        function activate() { }
    }

})();