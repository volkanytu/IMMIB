var appMain = angular.module('main');

appMain.controller('EducationListCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'basketProvider', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, basketProvider, commonFunc) {

    commonFunc();

    $scope.educationListDataUrl = $scope.baseUrl + 'api/educationapi/GetList';

    $http({
        url: $scope.educationListDataUrl,
        method: "GET",
        params: {
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.EducationList = data.Result;
        }
    });

}]);