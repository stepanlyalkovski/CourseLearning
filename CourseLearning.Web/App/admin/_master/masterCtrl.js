(function () {
    'use strict';

    angular
        .module('app').factory('MyFactory', function() {
        console.log('FACTORY INVOKE');
        var myFactory = {};
        var firstName = '';

        myFactory.setName = function(name) {
            firstName = name;
        };

        myFactory.getName = function() {
            return firstName;
        };

        return myFactory;
    });

    angular
        .module('app').service('MyService', function() {
        console.log('SERVICE INVOKE');
        var myFactory = {};
        var firstName = '';

        myFactory.setName = function(name) {
            firstName = name;
        };

        myFactory.getName = function() {
            return firstName;
        };

        return myFactory;
    });
    angular
        .module('app')
        .controller('masterCtrl', masterCtrl);

    masterCtrl.$inject = ['$location', 'MyService'];

    function masterCtrl($location, MyService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Admin main controller';

        activate();

        function activate() {
            MyService.setName('service qwerty');
        }
    }
})();
