(function () {
    'use strict';

    angular
        .module('app')
        .controller('courseListCtrl', courseListCtrl);

    courseListCtrl.$inject = ['$location', '$scope', 'Course', 'Enrollment', 'CourseSession'];

    function courseListCtrl($location, $scope, Course, Enrollment, CourseSession) {
        /* jshint validthis:true */
        var vm = this;

        vm.createdCourse = {};
        vm.title = 'Client Course List';
        vm.courses = null;
        vm.availableCourses = [];

        activate();

        function activate() {
            loadData();
        }

        function loadData() {


            vm.courseSessions = CourseSession.query(function(sessions) {
                console.log(sessions);

                vm.availableCourses = sessions.map(function (session) {
                    session.course.courseSessionId = session.courseSessionId;
                    return session.course;
                });

                vm.enrollments = Enrollment.query(function(data) {
                    console.log(data);
                });
            });


        }

        // function saveCourseForm() {
        //     if($scope.courseForm.$invalid) {
        //         alert('form is invalid!');
        //         return;
        //     }
        //
        //     var createdResource = new Course(vm.createdCourse);
        //     Course.save(createdResource).$promise.then(function(data) {
        //         createdResource.courseId = data.courseId;
        //         vm.courses.push(createdResource);
        //         console.log(vm.courses);
        //     });
        // }
        //
        // function addCourseClick() {
        //     modalSvc.addCreateCourseModal().then(function(course) {
        //         Course.save(course, function(data) {
        //             course.courseId = data.courseId;
        //             vm.courses.push(course);
        //             console.log(vm.courses);
        //         });
        //     });
        // }

    }
})();
