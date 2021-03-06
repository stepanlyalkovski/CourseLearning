﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('moduleCtrl', moduleCtrl);

    moduleCtrl.$inject = ['$location', 'Module', '$state', '$uibModal', 'Quiz', 'modalSvc', 'Article'];

    function moduleCtrl($location, Module, $state, $uibModal, Quiz, modalSvc, Article) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'moduleCtrl';
        vm.module = null;

        vm.addLessonClick = addLessonClick;
        vm.addArticleClick = addArticleClick;
        vm.addQuizClick = addQuizClick;


        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var moduleId = $state.params.id;
            vm.module = Module.get({id: moduleId}, function() {
                vm.module.quizzes = Module.getQuizzes({id: moduleId});
                vm.module.articles = Module.getArticles({id: moduleId});
                vm.module.lessons = Module.getLessons({id: moduleId});
            });
        }

        function addQuizClick() {
            var settings = {
                modelName: 'Quiz'
            };

            modalSvc.addCreatePreviewModal(settings).then(addQuiz);
        }

        function addQuiz(quiz) {
            console.log(quiz);
            Module.addQuiz({id: vm.module.moduleId}, quiz, function(data) {
                quiz.quizId = data.quizId;
                $state.go('admin.quiz', {id: quiz.quizId, createdQuiz: quiz});
            });
        }

        function addLessonClick() {
            var settings = {
                modelName: 'Lesson'
            };

            modalSvc.addCreatePreviewModal(settings).then(addLesson);
        }

        function addLesson(lesson) {
            lesson.moduleId = vm.module.moduleId;
            Module.addLesson({id: lesson.moduleId}, lesson, function (data) {
                lesson.lessonId = data.lessonId;
                vm.module.lessons.push(lesson);
            });
        }

        function addArticleClick() {
            var settings = {
                modelName: 'Article'
            };

            modalSvc.addCreatePreviewModal(settings).then(addArticle);
        }

        function addArticle(article) {
            Article.save(article, function(newArticle) {
                article.articleId = newArticle.articleId;
                article.moduleId = vm.module.moduleId;
                Module.addArticle({id: article.moduleId}, article, function (article) {
                    vm.module.articles.push(article);
                    $state.go('admin.article', {id: article.articleId});
                });
            });

        }
    }
})();
