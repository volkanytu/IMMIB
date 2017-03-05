// Conceptual Overview - https://docs.angularjs.org/guide/concepts

var appRoot = angular.module('main', ['ngRoute', 'ngGrid', 'ngResource', 'ui.grid', 'ui.grid.pagination', 'ui.bootstrap.buttons', 'ui.bootstrap'])
    .run(["$rootScope", function ($rootScope) {
        $rootScope.baseUrl = baseUrl;
        $rootScope.userId = userId;
    }])

    // DIRECTIVES
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

    // CONFIGS
    .config(['$httpProvider', function($httpProvider) {
        $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
        $httpProvider.interceptors.push("baseInterceptor");
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
    .factory('alertModal', [function () {
        return function (message, dialogType) {
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
            $(modalHtml).modal();
        };
    }])
    .factory("baseInterceptor", ["$q", '$rootScope', function ($q, $rootScope) {
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
                    window.location.reload();
                }
                return $q.reject(rejection);
            }
        };
    }])
    .factory("basketProvider", ['$rootScope', '$http', function ($rootScope, $http) {
        var dataUrl = $rootScope.baseUrl + 'api/AddToBasket';

        return {
            add: function (basketObj, callbackFn) {
                if (typeof basketObj != "undefined" && basketObj != null) {
                    basketObj.userId = $rootScope.userId;
                    basketObj.systemUserId = $rootScope.systemUserId;
                    basketObj.accountId = $rootScope.accountId;
                    basketObj.categoryId = $rootScope.categoryId;
                    basketObj.cityId = $rootScope.cityId;
                    basketObj.oppFrameId = $rootScope.oppFrameId;
                }

                $http({
                    url: dataUrl,
                    method: "POST",
                    data: basketObj,
                }).success(function(data) {
                    if (typeof callbackFn == "function")
                        callbackFn.call(this, data);
                });
            }
        };
    }])
    .factory("flexSlider", [function () {
        return function(){
            $(window).load(function () {
                $('.flexslider').flexslider({
                    animation: "slide",
                    start: function (slider) {
                        $('body').removeClass('loading');
                    }
                });
            });
        };
    }])
    ;