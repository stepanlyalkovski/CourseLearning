(function() {
    'use strict';

    angular
        .module('app')
        .directive('lessonBuilder', lessonBuilder)
        .controller('lessonBuilderCtrl', lessonBuilderCtrl);

    lessonBuilder.$inject = ['$window'];
    
    function lessonBuilder ($window) {
        var directive = {
            link: link,
            templateUrl: '/App/admin/appComponents/lesson/directives/lessonBuilder.html',
            controller: lessonBuilderCtrl,
            scope: {
                lesson: '='
            },
            bindToController: true,
            controllerAs: 'vm',
            restrict: 'E'
        };
        return directive;

        function link(scope, element, attrs, ctrl) {
        }
    }

    lessonBuilderCtrl.$inject = ['$scope', 'appEnum', 'modalSvc', 'Lesson'];

    function lessonBuilderCtrl($scope, appEnum, modalSvc, Lesson) {
        var vm = this;

        var pageBuilderModes = {
            default: 0,
            transitionPageSelect: 1
        };

        var pageTypeActionItems = [
            {
                actionText: 'Text + Resource',
                pageType: appEnum.lessonPageTypes.standard
            },
            {
                actionText: 'Resource Only',
                pageType: appEnum.lessonPageTypes.resourceOnly
            },
            {
                actionText: 'Text Only',
                pageType: appEnum.lessonPageTypes.textOnly
            },
            {
                actionText: 'Question',
                pageType: appEnum.lessonPageTypes.question
            }
        ];

        var currentTransition = null;

        vm.transitionOptions = [
            {
                type: appEnum.lessonPageTransitionTypes.yesNo,
                name: 'Yes No transition(question page)'
            },
            {
                type: appEnum.lessonPageTransitionTypes.custom,
                name: 'Custom transition(question page)'
            }
        ];

        vm.selectedPage = null;
        vm.selectedTransition = null;
        vm.pageBuilderMode = pageBuilderModes.default;
        vm.transitionTypes = appEnum.lessonPageTransitionTypes;
        vm.pageItemSettings = {
            selectLessonPage: selectLessonPage
        };

        vm.createPage = createPage;
        vm.selectLessonPage = selectLessonPage;
        vm.saveLessonClick = saveLessonClick;
        vm.isQuestionPageType = isQuestionPageType;
        vm.createYesNoTransition = createYesNoTransition;
        vm.isPageSelectMode = isPageSelectMode;
        vm.createCustomTransition = createCustomTransition;

        $scope.$watch('vm.selectedTransition', function(newVal) {
            debugger;
            if(!vm.selectedPage) {
                return;
            }

            if(vm.selectedPage.lessonPageTransitionType === newVal.type) {
                return;
            }

            vm.selectedPage.lessonPageTransitions = [];// clear transitions
        });

        function createPage() {
            modalSvc.addSelectActionModal(pageTypeActionItems).then(function(item) {
                var createdPage = {
                    lessonPageType: item.pageType,
                    lessonId: vm.lesson.lessonId
                };

                Lesson.createPage(createdPage, function(page) {
                    vm.lesson.lessonPages.push(page);
                    vm.selectedPage = page;
                });
            });
        }

        function selectLessonPage(lessonPage) {
            if(isPageSelectMode()) {
                addTransition(lessonPage);
                return;
            }

            vm.selectedPage = lessonPage;

            vm.selectedTransition = _.find(vm.transitionOptions, {type: lessonPage.lessonPageTransitionType});
        }

        function saveLessonClick() {
            Lesson.update(vm.lesson);
        }

        function isQuestionPageType() {
            return !!vm.selectedPage && vm.selectedPage.lessonPageType === appEnum.lessonPageTypes.question;
        }

        function createYesNoTransition(signalYesNoValue) {
            currentTransition = {
                yesNoSignal: signalYesNoValue,
                startPageId: vm.selectedPage.lessonPageId
            };

            vm.pageBuilderMode = pageBuilderModes.transitionPageSelect;
            vm.selectedPage.lessonPageTransitionType = vm.selectedTransition.type;

        }

        function isPageSelectMode() {
            return vm.pageBuilderMode === pageBuilderModes.transitionPageSelect;
        }

        function addTransition(endLessonPage) {
            currentTransition.endPageId = endLessonPage.lessonPageId;
            vm.selectedPage.lessonPageTransitions = vm.selectedPage.lessonPageTransitions || [];
            vm.selectedPage.lessonPageTransitions.push(currentTransition);
            currentTransition = false;
            vm.pageBuilderMode = pageBuilderModes.default;
        }

        function createCustomTransition(customSignalValue) {
            currentTransition = {
                customSignalValue: customSignalValue,
                startPageId: vm.selectedPage.lessonPageId
            };

            vm.pageBuilderMode = pageBuilderModes.transitionPageSelect;
            vm.selectedPage.lessonPageTransitionType = vm.selectedTransition.type;
        }

    }

})();