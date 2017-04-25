// Conceptual Overview - https://docs.angularjs.org/guide/concepts

var appRoot = angular.module('main', ['ngRoute', 'ngGrid', 'ngResource', 'ui.grid', 'ui.grid.pagination', 'ui.bootstrap.buttons', 'ui.bootstrap'])
    .run(["$rootScope", function ($rootScope) {
        $rootScope.baseUrl = baseUrl;
        $rootScope.userId = userId;
        $rootScope.isLoggedIn = isLoggedIn;
        $rootScope.$on('$routeUpdate', function () {
            $route.reload();
        });
    }])

    // DIRECTIVES
    .directive('isActiveNav', ['$location', function ($location) {
        return {
            restrict: 'A',
            link: function (scope, element) {
                scope.location = $location;
                scope.$watch('location.path()', function (currentPath) {
                    if (currentPath === element[0].attributes['href'].nodeValue) {
                        element.parent().addClass('active');
                    } else {
                        element.parent().removeClass('active');
                    }
                });
            }
        };
    }])
    .directive('formatPhone', ['$location', function ($location) {
        return {
            //restrict: 'A',
            link: function (scope, element) {
                scope.$watch(element, function () {
                    $(element).mask("999-9999999");
                });
            }
        };
    }])
    .directive('loading', ['$http', function ($http) {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                scope.isLoading = function () {
                    return $http.pendingRequests.length > 0;
                };

                scope.$watch(scope.isLoading, function (v) {
                    if (v) {
                        elm.modal();
                    } else {
                        elm.modal("hide");
                    }
                });
            }
        };
    }])
    .directive('onlyNumber', function () {
        return {
            restrict: "A",
            link: function (scope, elm, attrs) {
                elm.on("keydown keypress", function (event) {
                    if ((event.charCode < 48 || event.charCode > 57) && event.charCode != 0) {
                        event.preventDefault();
                    }
                });
            }
        };
    })
    .directive('onFinishRender', ['$timeout', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                if (scope.$last === true) {
                    $timeout(function () {
                        scope.$emit(attr.onFinishRender);
                    });
                }
            }
        }
    }])



    // CONFIGS
    .config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
        $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
        $httpProvider.interceptors.push("baseInterceptor");
        $locationProvider.html5Mode({ enabled: true, requireBase: false });
    }])

    // FILTERS
    .filter('roundToZero', function () {
        return function (input) {
            return input > 0 ? input : 0;
        };
    })

    // SERVICES
    .factory('safeApply', [function () {
        return function ($scope, fn) {
            var phase = $scope.$root.$$phase;
            if (phase == '$apply' || phase == '$digest') {
                if (fn) {
                    $scope.$eval(fn);
                }
            } else {
                if (fn) {
                    $scope.$apply(fn);
                } else {
                    $scope.$apply();
                }
            }
        };
    }])
    .factory('commonValues', ['$rootScope', '$http', function ($rootScope, $http) {

        var getCitiesDataUrl = $rootScope.baseUrl + 'api/commonapi/GetCities';
        var getEducationLevelsDataUrl = $rootScope.baseUrl + 'api/commonapi/GetEducationLevels';
        var getGenderCodesDataUrl = $rootScope.baseUrl + 'api/commonapi/GetGenderCodes';
        var installmentTypesDataUrl = $rootScope.baseUrl + 'api/commonapi/GetInstallmentTypes';
        var universitiesDataUrl = $rootScope.baseUrl + 'api/commonapi/GetUniversities';
        return {
            getCities: function (onSuccess, onError) {
                $http({
                    url: getCitiesDataUrl,
                    method: "GET",
                    async: false,
                    params: {

                    }
                }).success(function (data) {
                    if (data && data.Success && data.Result) {
                        onSuccess(data.Result);
                    }
                })
                    .error(function (err) {
                        onError(err);
                    });
            },
            getEducationLevels: function (onSuccess, onError) {
                $http({
                    url: getEducationLevelsDataUrl,
                    method: "GET",
                    async: false,
                    params: {

                    }
                }).success(function (data) {
                    if (data && data.Success && data.Result) {
                        onSuccess(data.Result);
                    }
                })
                    .error(function (err) {
                        onError(err);
                    });
            },
            getGenderCodes: function (onSuccess, onError) {
                $http({
                    url: getGenderCodesDataUrl,
                    method: "GET",
                    async: false,
                    params: {

                    }
                }).success(function (data) {
                    if (data && data.Success && data.Result) {
                        onSuccess(data.Result);
                    }
                })
                    .error(function (err) {
                        onError(err);
                    });
            },
            getInstallmentTypes: function (onSuccess, onError) {
                $http({
                    url: installmentTypesDataUrl,
                    method: "GET",
                    async: false,
                    params: {

                    }
                }).success(function (data) {
                    if (data && data.Success && data.Result) {
                        onSuccess(data.Result);
                    }
                })
                    .error(function (err) {
                        onError(err);
                    });
            },
            getUniversities: function (onSuccess, onError) {
                $http({
                    url: universitiesDataUrl,
                    method: "GET",
                    async: false,
                    params: {

                    }
                }).success(function (data) {
                    if (data && data.Success && data.Result) {
                        onSuccess(data.Result);
                    }
                })
                    .error(function (err) {
                        onError(err);
                    });
            }
        };

        return function ($scope, fn) {
            var phase = $scope.$root.$$phase;
            if (phase == '$apply' || phase == '$digest') {
                if (fn) {
                    $scope.$eval(fn);
                }
            } else {
                if (fn) {
                    $scope.$apply(fn);
                } else {
                    $scope.$apply();
                }
            }
        };
    }])
    .factory('alertModal', [function () {
        return function (message, dialogType, closeFunction) {
            var bodyClass = "",
                modalTitle = "Bilgi";
            switch (dialogType) {
                case "success":
                    bodyClass = "alert-success";
                    modalTitle = "Başarılı";
                    break;
                case "error":
                    bodyClass = "alert-danger";
                    modalTitle = "Hata";
                    break;
                case "info":
                    bodyClass = "alert-info";
                    break;
            }
            var modalHtml = '' +
                '<div class="modal fade" tabindex="-1" role="dialog" data-keyboard="false">' +
                '   <div class="modal-dialog" role="document">' +
                '       <div class="modal-content">' +
                '           <div class="modal-header">' +
                '               <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '               <h4 class="modal-title">' + modalTitle + '</h4>' +
                '           </div>' +
                '       <div class="modal-body ' + bodyClass + '">' +
                '           ' + message +
                '       </div>' +
                '   </div>' +
                '</div></div>';

            $(modalHtml).modal().on('hidden.bs.modal', function () {
                if (closeFunction != null) {
                    closeFunction();
                }
            });
        };
    }])
    .factory('commonFunc', ['$rootScope', '$location', function ($rootScope, $location) {
        return function () {
            $rootScope.getClass = function (path) {
                return ($location.path().substr(0, path.length) === path) ? 'active' : '';
            };
        };
    }])
    .factory("baseInterceptor", ["$q", '$rootScope', 'alertModal', function ($q, $rootScope, alertModal) {
        return {
            'request': function (config) {
                //config.timeout = 5000;
                return config;
            },
            'requestError': function (rejection) {
                return $q.reject(rejection);
            },
            'response': function (response) {
                return response;
            },
            'responseError': function (rejection) {
                if (rejection.status == 401) {

                    alertModal("İşlem yapmak istediğiniz sayfa için giriş yapmalısınız. </br> Giriş yapıp tekrar deneyiniz.", "error", function () {
                        window.location.href = baseUrl;
                    });

                    isLoggedIn = "False";
                }
                return $q.reject(rejection);
            }
        };
    }])
    .factory("flexSlider", [function () {
        return function () {
            $('.flexslider').flexslider({
                animation: "slide",
                start: function (slider) {
                    $('body').removeClass('loading');
                }
            });
        };
    }])
    ;