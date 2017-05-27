(function () {
    'use strict';

    angular
        .module('app')
        .controller('articleCtrl', articleCtrl);

    articleCtrl.$inject = ['$location', 'Article', '$state', '$timeout'];

    function articleCtrl($location, Article, $state, $timeout) {
        /* jshint validthis:true */
        var vm = this;
        vm.article = null;
        vm.title = 'Article Content';
        vm.tinymceOptions = {
            onChange: function(e) {
                console.log('test');
                console.log(e);
            },
            inline: false,
            plugins : 'advlist autolink link image lists charmap print preview',
            skin: 'lightgray',
            theme : 'modern'
        };

        vm.save = save;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var articleId = $state.params.id;
            vm.article = Article.get({id: articleId});
        }

        function save() {
            Article.update(vm.article, function() {
                vm.message = 'article was successfully updated';
                $timeout(function () {
                    vm.message = '';
                }, 4000);
            });
        }
    }
})();
