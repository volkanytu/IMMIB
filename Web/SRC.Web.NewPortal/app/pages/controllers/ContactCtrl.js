var appMain = angular.module('main');

appMain.controller('ContactCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'basketProvider', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, basketProvider, commonFunc) {

    $scope.contactPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.contactPageDataUrl,
        method: "GET",
        params: {
            pageType: 5
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Page = data.Result;
        }
    });

}]);