var appMain = angular.module('main');

appMain.controller('HomeCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'basketProvider', 'flexSlider', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, basketProvider, flexSlider) {

    $scope.dataUrl = $scope.baseUrl + 'dynamicpageapi/GetSliderPageList';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.dataUrl,
        method: "GET",
        params: {
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.SliderData = data.Result;

            flexSlider();
        }
    });
}]);