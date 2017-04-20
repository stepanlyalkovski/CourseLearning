(function () {
    'use strict';

    angular
        .module('app')
        .controller('quizCtrl', quizCtrl);

    quizCtrl.$inject = ['$location', 'Module', '$state', '$uibModal', 'Quiz', 'modalSvc', 'questionSvc'];

    function quizCtrl($location, Module, $state, $uibModal, Quiz, modalSvc, questionSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'quizCtrl';
        vm.quiz = null;

        vm.addQuestionClick = addQuestionClick;
        vm.updateQuiz = updateQuiz;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            if(!$state.params.createdQuiz) {
                var quizId = $state.params.id;
                vm.quiz = Quiz.get({id: quizId});
                return;
            }

            vm.quiz = $state.params.createdQuiz;
        }

        function addQuestionClick() {
            var actionItems = [
                {
                    actionText: 'Add Question',
                    clickCallback: addQuestionAction
                },
                {
                    actionText: 'Attach Question', clickCallback: attachQuestionAction
                }
            ];

            modalSvc.addSelectActionModal(actionItems).then(function(item) {
                item.clickCallback();
            });
        }

        function addQuestionAction() {

            var modalInstance = questionSvc.addQuestionModal();

            modalInstance.result.then(function (question) {
                console.log(question);
                var seqNumber = vm.quiz.quizQuestionList.length + 1;
                var quizQuestion = {
                    quizId: vm.quiz.quizId,
                    question: question,
                    sequenceNumber: seqNumber
                };

                vm.quiz.quizQuestionList.push(quizQuestion);
                // Question.save(question, function(data) {
                //     question.questionId = data.questionId;
                //     vm.questions.push(question);
                // });
            });
        }

        function attachQuestionAction() {

        }

        function updateQuiz() {
            Quiz.update(vm.quiz, function(data) {
                console.log('updated!');
                console.log(data);
            })
        }
    }
})();
