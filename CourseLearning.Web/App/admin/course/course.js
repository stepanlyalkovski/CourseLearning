(function () {
    'use strict';


    angular
        .module('app')
        .controller('testCtrl', testCtrl);

    testCtrl.$inject = ['$location', '$http', 'config', 'MyService', 'MyFactory'];

    function testCtrl($location, $http, config, MyService, MyFactory) {
        /* jshint validthis:true */
        var vm = this;
        activate();

        function activate() {
            console.log(MyService.getName());
            console.log(MyFactory.getName());
        }
    }
    angular
        .module('app')
        .controller('courseCtrl', courseCtrl);

    //courseCtrl.$inject = ['$scope', 'Course', '$state', 'MyFactory'];

    function courseCtrl($scope, Course, $state, MyFactory, MyService) {
        /* jshint validthis:true */
        var vm = this;
        activate();

        function activate() {
            loadData();
            console.log(MyService.getName());
            console.log(MyFactory.getName());
        }

        function loadData() {
            var courseId = $state.params.id;
            vm.course = Course.get({id: courseId});
            vm.courseModules = Course.modules({id: courseId});
        }
    }


})();
