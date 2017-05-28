(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseCtrl', courseCtrl);

    courseCtrl.$inject = ['$scope', 'Course', '$state', 'CourseSession', 'Enrollment'];

    function courseCtrl($scope, Course, $state, CourseSession, Enrollment) {
        /* jshint validthis:true */
        var vm = this;

        vm.course = null;
        vm.courseModules = null;

        vm.attendCourse = attendCourse;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var courseSessionId = $state.params.id;
            vm.courseSession = CourseSession.get({id: courseSessionId}, function(courseSession) {
                debugger;
                vm.course = courseSession.course;
                vm.enrollment = Enrollment.get({courseSessionId: courseSessionId});

                vm.courseModules = Course.getModules({id: vm.course.courseId});
            });
        }

        function attendCourse() {
            Enrollment.save({courseSessionId: vm.courseSession.courseSessionId}, function (data) {
                console.log(data);
                vm.enrollment = data;
            });
            console.log('attend!');
        }

    }


})();
