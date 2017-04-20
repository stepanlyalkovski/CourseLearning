(function () {
    'use strict';

    angular
        .module('app')
        .constant('appEnum', {

            questionControlTypes: {
                input: { name: 'Input', questionControlTypeId: 1, $count: 0, $questionsMinLimit: 1, $questionsMaxLimit: 20 },
                checkbox: { name: 'Checkbox', questionControlTypeId: 2, $count: 0, $questionsMinLimit: 1, $questionsMaxLimit: 20 },
                radiobutton: { name: 'Radiobutton', questionControlTypeId: 3, $count: 0, $questionsMinLimit: 2, $questionsMaxLimit: 20 }
            }
        });
})();
