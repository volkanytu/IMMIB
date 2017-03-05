angular.module('main')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/index', {
                templateUrl: baseUrl + "app/home/views/index.html",
                controller: 'HomeCtrl'
            })
            .otherwise({
                redirectTo: '/index'
            });
    }]);