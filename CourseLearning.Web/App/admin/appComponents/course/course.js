(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$scope', 'Course', '$state'];

    function courseCtrl($scope, Course, $state) {
        /* jshint validthis:true */
        var vm = this;

        vm.course = null;
        vm.courseModules = null;
        vm.createdModule = {};

        vm.addModule = addModule;


        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var courseId = $state.params.id;
            vm.course = Course.get({id: courseId});
            vm.courseModules = Course.getModules({id: courseId});
            console.log(vm.courseModules);
        }

        function addModule() {
            vm.createdModule.course = { courseId: vm.course.courseId };
            Course.addModule({id: vm.course.courseId}, vm.createdModule, function(data) {
                console.log(data);
                vm.createdModule.moduleId = data.moduleId;
                vm.courseModules.push(vm.createdModule);
                console.log(vm.courseModules);
            });
        }
    }


})();
