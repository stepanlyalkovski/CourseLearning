(function () {
    'use strict';

    angular
        .module('app')
        .controller('moduleCtrl', moduleCtrl);

    moduleCtrl.$inject = ['$location', 'Module', '$state', '$uibModal', 'Quiz'];

    function moduleCtrl($location, Module, $state, $uibModal, Quiz) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'moduleCtrl';
        vm.module = null;

        vm.addQuiz = addQuiz;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var moduleId = $state.params.id;
            vm.module = Module.get({id: moduleId}, function() {
                vm.module.quizzes = Module.getQuizzes({id: moduleId});
                vm.module.articles = Module.getArticles({id: moduleId});

            });
        }

        function addQuiz() {
            var modalInstance = $uibModal.open(vm.quizModalTemplate);

            modalInstance.result.then(function (quiz) {
                console.log(quiz);
                Module.addQuiz({id: vm.module.moduleId}, quiz, function(data) {
                    quiz.quizId = data.quizId;
                    $state.go('admin.quiz', {id: quiz.quizId, createdQuiz: quiz});
                });
                // Question.save(question, function(data) {
                //     question.questionId = data.questionId;
                //     vm.questions.push(question);
                // });
                // // addQuestionFn(question);
            });

        }

        vm.quizModalTemplate = {
            animation: true,
            backdrop: 'static',
            templateUrl: "/App/admin/appComponents/modals/addEditQuiz/addEditQuizModal.html",
            controller: "addEditQuizModalCtrl as vm",
            size: "lg",
            resolve: {
                additionalData: function () {

                }
            }
        };
    }
})();
