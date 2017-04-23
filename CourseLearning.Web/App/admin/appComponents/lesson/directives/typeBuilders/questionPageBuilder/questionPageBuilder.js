(function() {
    'use strict';

    angular
        .module('app')
        .directive('questionPageBuilder', questionPageBuilder);

    questionPageBuilder.$inject = ['$window'];
    
    function questionPageBuilder ($window) {
        var directive = {
            link: link,
            restrict: 'EA',
            templateUrl: '/App/admin/appComponents/lesson/directives/typeBuilders/questionPageBuilder/questionPageBuilder.html',
            controller: questionPageBuilderCtrl,
            scope: {},
            bindToController: {
                lessonPage: '=',
                settings: '='
            },
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

    questionPageBuilderCtrl.$inject = ['modalSvc'];

    function questionPageBuilderCtrl(modalSvc) {
            var vm = this;
            vm.addQuestionClick = addQuestionClick;

            function addQuestionClick() {
                modalSvc.addCreateQuestionModal().then(function(question) {
                    vm.lessonPage.question = question;
                })
            }
    }

})();