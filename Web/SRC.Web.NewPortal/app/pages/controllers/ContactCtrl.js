var appMain = angular.module('main');

appMain.controller('ContactCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

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
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

}]);