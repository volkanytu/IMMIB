var appMain = angular.module('main');

appMain.controller('HowtoCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'basketProvider', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, basketProvider, commonFunc) {

    $scope.howtoPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.howtoPageDataUrl,
        method: "GET",
        params: {
            pageType: 3
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Page = data.Result;
        }
    });

}]);