(function () {
    'use strict';

    angular
        .module('app')
        .directive('dynamicFormQuestion', DynamicFormQuestion);

    function DynamicFormQuestion() {
        var directive = {
            restrict: 'E',
            template: "<div id='dynamicFormQuestion_container'></div>",
            scope: { question: '=' },
            controllerAs: 'vm',
            controller: DynamicFormQuestionCtrl

        };

        return directive;
    }

    DynamicFormQuestionCtrl.$inject = ['$scope', '$compile', 'appEnum'];

    function DynamicFormQuestionCtrl($scope, $compile, appEnum) {
        var vm = this;

        activate();

        function activate() {
            vm.question = $scope.question;
            vm.countRangeList = [];
            var questionConfig = _.find(appEnum.questionControlTypes, { questionControlTypeId: vm.question.questionControlType });

            for (var i = questionConfig.$questionsMinLimit; i <= questionConfig.$questionsMaxLimit; i++) {
                vm.countRangeList.push(i);
            }

            registerWatchers();
        }

        function registerWatchers() {
            var controlToLoad = null;
            $scope.$watch('vm.question.questionControlType', function () {
                if (!vm.question.questionControlType) {
                    return;
                }

                switch (vm.question.questionControlType) {
                    case appEnum.questionControlTypes.input.questionControlTypeId:
                        controlToLoad = "<inputtext-question-builder question='vm.question' count-range-list='vm.countRangeList'></inputtext-question-builder>";
                        break;
                    case appEnum.questionControlTypes.checkbox.questionControlTypeId:
                        controlToLoad = "<checkbox-question-builder question='vm.question' count-range-list='vm.countRangeList'></checkbox-question-builder>";
                        break;
                    case appEnum.questionControlTypes.radiobutton.questionControlTypeId:
                        controlToLoad = "<radiobutton-question-builder question='vm.question' count-range-list='vm.countRangeList'></radiobutton-question-builder>";
                        break;
                    default:
                        throw new Error('dynamicFormQuestion: questionControlTypeId is undefined!');
                }

                var container = angular.element(document.querySelector('#dynamicFormQuestion_container'));

                //Refresh container
                _.forEach(container.children(), function (child) {
                    angular.element(child).scope().$destroy();
                    angular.element(child).remove();
                });

                if (controlToLoad != null) {
                    var appendHtml = $compile(controlToLoad)($scope.$new());
                    container.append(appendHtml);
                }
            });
        }
    }
})();
