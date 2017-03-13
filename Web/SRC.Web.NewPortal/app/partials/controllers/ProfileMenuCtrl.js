var appMain = angular.module('main');

appMain.controller('ProfileMenuCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.contactAttendanceSummaryDataUrl = $scope.baseUrl + 'api/educationapi/GetContactAttendanceSummary';


    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.contactAttendanceSummaryDataUrl,
        method: "GET",
        async: false,
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Summary = data.Result;
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

}]);