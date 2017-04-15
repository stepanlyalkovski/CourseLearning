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
        vm.saveCourseForm = function() {
            if($scope.courseForm.$invalid) {
                alert('form is invalid!');
            }

            Course.save(vm.createdCourse, function(data) {
                console.log(data);
            });
        };

        vm.courses = Course.query(function(courses) {

        });
        // $scope.submitForm = function () {
        //     // check to make sure the form is completely valid
        //     if ($scope.userForm.$valid) {
        //         alert('our form is amazing');
        //     }
        // };

        activate();

        function activate() { }
    }
})();
