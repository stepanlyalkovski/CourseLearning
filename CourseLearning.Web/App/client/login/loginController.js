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
        debugger;
        authService.login($scope.loginData).then(function (response) {

                $state.go('client.courseList');

            },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);