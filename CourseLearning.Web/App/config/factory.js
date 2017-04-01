(function () {
    'use strict';

    var config = {
        apiUrl: 'http://localhost:49558/'
    }

    angular
        .module('app')
        .constant('config', config);
})();