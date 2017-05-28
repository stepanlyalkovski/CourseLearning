(function () {
    'use strict';

    angular
        .module('app')
        .controller('landingCtrl', landingCtrl);

    landingCtrl.$inject = ['$location']; 

    function landingCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'landingCtrl';

        activate();

        function activate() { }
    }
})();
