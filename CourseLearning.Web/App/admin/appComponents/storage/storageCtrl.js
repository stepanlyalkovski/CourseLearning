(function () {
    'use strict';

    angular
        .module('app')
        .controller('storageCtrl', storageCtrl);

    storageCtrl.$inject = ['$location', 'Storage'];

    function storageCtrl($location, Storage) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'storageCtrl';
        vm.storageFolders = [];

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            vm.storageFolders = Storage.get();
        }
    }
})();
