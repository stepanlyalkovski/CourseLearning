'use strict';
angular.module('app')
    .controller('loginController', ['$scope', '$location',
'authService', '$state', function ($scope, $location, authService, $state) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

                $state.go('admin.courseList');

            },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);