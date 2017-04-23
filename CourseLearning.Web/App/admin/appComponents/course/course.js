(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$scope', 'Course', '$state', 'modalSvc'];

    function courseCtrl($scope, Course, $state, modalSvc) {
        /* jshint validthis:true */
        var vm = this;

        vm.course = null;
        vm.courseModules = null;
        vm.createdModule = {};

        vm.addModule = addModule;
        vm.addModuleClick = addModuleClick;

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

        function addModule(module) {
            module.name = module.title;
            module.course = { courseId: vm.course.courseId };
            Course.addModule({id: vm.course.courseId}, module, function(data) {
                console.log(data);
                module.moduleId = data.moduleId;
                vm.courseModules.push(module);
                console.log(vm.courseModules);
            });
        }

        function addModuleClick() {
            var settings = {
                moduleName: 'Module'
            };

            modalSvc.addCreatePreviewModal(settings).then(addModule);
        }
    }


})();
