(function () {
    'use strict';

    angular
        .module('app')
        .controller('questionListCtrl', questionListCtrl);

    questionListCtrl.$inject = ['$location', 'Question', '$state', '$uibModal', 'appEnum'];

    function questionListCtrl($location, Question, $state, $uibModal, appEnum) {
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

            vm.questionControlTypeList = angular.copy(appEnum.questionControlTypes);
            for(var key in vm.questionControlTypeList) {
                if (vm.questionControlTypeList.hasOwnProperty(key)) {
                    if (vm.questionControlTypeList[key].$isHideForStandAloneUsage === true) {
                        delete vm.questionControlTypeList[key];
                    }
                }
            }
        }

        function loadData() {
            vm.questions = Question.query();
        }
        
        function okCallbak() {
            // console.log(vm.createdArticle);
            // Article.save(vm.createdArticle, function(data) {
            //     vm.createdArticle.articleId = data.articleId;
            //     vm.articles.push(vm.createdArticle);
            //     vm.createdArticle = null;
            // })
        }

        function addQuestionClick() {
            var template = angular.copy(vm.modalTemplate);
            template.resolve.additionalData = function () {
                return {
                    title: "Add Custom Question",
                    questionControlTypeList: vm.questionControlTypeList
                };
            };
            var modalInstance = $uibModal.open(template);

            modalInstance.result.then(function (question) {
                console.log(question);

                Question.save(question, function(data) {
                    question.questionId = data.questionId;
                    vm.questions.push(question);
                });
                // addQuestionFn(question);
            });
        }

        vm.modalTemplate = {
            animation: true,
            backdrop: "static",
            keyboard: false,
            templateUrl: "/App/shared/directives/questions/modals/addEditCustomQuestionModal.html",
            controller: "addEditCustomQuestionModalCtrl as vm",
            size: "lg",
            resolve: {
                additionalData: function () {

                }
            }
        };
    }



})();
