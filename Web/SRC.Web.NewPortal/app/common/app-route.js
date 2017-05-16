angular.module('main')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/Pages/HowTo/', {
                templateUrl: baseUrl + "app/pages/views/howto.html",
                controller: 'HowtoCtrl'
            })
            .when('/Pages/Contact/', {
                templateUrl: baseUrl + "app/pages/views/contact.html",
                controller: 'ContactCtrl'
            })
            .when('/Education/', {
                templateUrl: baseUrl + "app/education/views/education-list.html",
                controller: 'EducationListCtrl'
            })
            .when('/Education/Index/:id', {
                templateUrl: baseUrl + "app/education/views/education-detail.html",
                controller: 'EducationDetailCtrl'
            })
            .when('/Profile/', {
                templateUrl: baseUrl + "app/profile/views/home-profile.html",
                controller: 'HomeProfileCtrl'
            })
            .when('/Profile/Edit/', {
                templateUrl: baseUrl + "app/profile/views/edit-profile.html",
                controller: 'EditProfileCtrl'
            })
            .when('/Profile/New/', {
                templateUrl: baseUrl + "app/profile/views/new-profile.html",
                controller: 'NewProfileCtrl'
            })
            .when('/Profile/Education/:status', {
                templateUrl: baseUrl + "app/profile/views/my-educations.html",
                controller: 'MyEducationsCtrl'
            })
            .when('/Home/', {
                templateUrl: baseUrl + "app/home/views/index.html",
                controller: 'HomeCtrl'
            })
            .when('/Editor/Index/', {
                templateUrl: baseUrl + "app/editor/views/editor.html",
                controller: 'EditorCtrl'
            })
            .when('/Editor/', {
                templateUrl: baseUrl + "app/editor/views/editor.html",
                controller: 'EditorCtrl'
            })
            .when('/Editor/Index', {
                templateUrl: baseUrl + "app/editor/views/editor.html",
                controller: 'EditorCtrl'
            })
            .when('/Editor', {
                templateUrl: baseUrl + "app/editor/views/editor.html",
                controller: 'EditorCtrl'
            })
            .otherwise({
                redirectTo: '/Home/'
            });
    }]);