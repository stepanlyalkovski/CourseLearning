(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseListCtrl', courseListCtrl);

    courseListCtrl.$inject = ['$location', '$scope', 'courseSvc'];

    function courseListCtrl($location, $scope, courseSvc) {
        /* jshint validthis:true */
        var vm = this;
        var Course = courseSvc.getCourseResource();
        vm.createdCourse = {};
        vm.title = 'courseListCtrl';
        vm.saveCourseForm = saveCourseForm;
        vm.courses = null;


        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            vm.courses = Course.query(function(courses) {

            });
        }

        function saveCourseForm() {
            if($scope.courseForm.$invalid) {
                alert('form is invalid!');
                return;
            }

            var createdResource = new Course(vm.createdCourse);
            Course.save(createdResource).$promise.then(function(data) {
                createdResource.courseId = data.courseId;
                vm.courses.push(createdResource);
                console.log(vm.courses);
            });
        }
    }
})();
