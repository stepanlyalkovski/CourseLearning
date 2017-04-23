(function () {
    'use strict';

    angular
        .module('app')
        .controller('lessonCtrl', lessonCtrl);

    lessonCtrl.$inject = ['$location', 'Module', '$state', 'Lesson', 'modalSvc'];

    function lessonCtrl($location, Module, $state, Lesson, modalSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'lessonCtrl';
        vm.lesson = {};

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var lessonId = $state.params.id;
            vm.lesson = Lesson.get({id: lessonId});
        }


    }


})();
