(function () {
    'use strict';

    angular
        .module('app')
        .controller('questionListCtrl', questionListCtrl);

    questionListCtrl.$inject = ['$location', 'Question', '$state', 'modalSvc', 'appEnum'];

    function questionListCtrl($location, Question, $state, modalSvc, appEnum) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'questionCtrl';
        vm.questions = [];
        vm.createdQuestion = {};
        vm.questionControlTypeList = null;
        vm.editorSettings = {
            okBtnText: 'Add Question',
            okCallbak: okCallbak
        };

        vm.addQuestionClick = addQuestionClick;

        activate();

        function activate() {
            loadData();

        }

        function loadData() {
            vm.questions = Question.query();
        }
        
        function okCallbak() {

        }

        function addQuestionClick() {
            modalSvc.addCreateQuestionModal().then(function (question) {
                console.log(question);

                Question.save(question, function(data) {
                    question.questionId = data.questionId;
                    vm.questions.push(question);
                });
            });
        }
    }



})();
