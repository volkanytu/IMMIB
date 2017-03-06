angular.module('main')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/Pages/HowTo', {
                templateUrl: baseUrl + "app/pages/views/howto.html",
                controller: 'HowtoCtrl'
            })
            .when('/Pages/Contact', {
                templateUrl: baseUrl + "app/pages/views/contact.html",
                controller: 'ContactCtrl'
            })
            .when('/Education/', {
                templateUrl: baseUrl + "app/education/views/education-list.html",
                controller: 'EducationListCtrl'
            })
            .when('/Education/detail', {
                templateUrl: baseUrl + "app/education/views/education-detail.html",
                controller: 'EducationDetailCtrl'
            })
            .when('/Home/', {
                templateUrl: baseUrl + "app/home/views/index.html",
                controller: 'HomeCtrl'
            })
            .otherwise({
                redirectTo: '/Home/'
            });
    }]);