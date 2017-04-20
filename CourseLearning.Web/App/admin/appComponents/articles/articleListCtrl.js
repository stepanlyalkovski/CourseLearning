(function () {
    'use strict';

    angular
        .module('app')
        .controller('articleListCtrl', articleListCtrl);

    articleListCtrl.$inject = ['$location', 'Article', '$state'];

    function articleListCtrl($location, Article, $state) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'articleCtrl';
        vm.articles = [];
        vm.createdArticle = {};
        vm.editorSettings = {
            okBtnText: 'Add Article',
            okCallbak: okCallbak
        };

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var articleId = $state.params.id;
            vm.articles = Article.query();
        }
        
        function okCallbak() {
            console.log(vm.createdArticle);
            Article.save(vm.createdArticle, function(data) {
                vm.createdArticle.articleId = data.articleId;
                vm.articles.push(vm.createdArticle);
                vm.createdArticle = null;
            })
        }
    }
})();
