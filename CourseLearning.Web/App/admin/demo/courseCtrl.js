(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$location', '$scope']; 

    function courseCtrl($location, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'courseCtrl';

        $scope.submitForm = function () {
            // check to make sure the form is completely valid
            if ($scope.userForm.$valid) {
                alert('our form is amazing');
            }
        };

        activate();

        function activate() { }
    }
})();
