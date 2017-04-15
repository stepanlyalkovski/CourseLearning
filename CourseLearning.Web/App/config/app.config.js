(function () {
    'use strict';

    var config = {
        adminUrls: {
            course: '/api/admin/course'
        },
        apiUrls : {

        }
    };

    angular
        .module('app')
        .constant('config', config);
})();