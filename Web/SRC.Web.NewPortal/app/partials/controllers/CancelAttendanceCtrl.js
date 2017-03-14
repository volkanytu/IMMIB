var appMain = angular.module('main');

appMain.controller('CancelAttendanceCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.cancelPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';
    $scope.cancelAttendanceDataUrl = $scope.baseUrl + 'api/educationapi/CancelAttendance';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.cancelPageDataUrl,
        method: "GET",
        params: {
            pageType: 8
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Page = data.Result;
        }
    });

    $scope.cancelAttendance = function () {

        if ($scope.$parent.selectedAttendance.isAgreed != true) {
            $scope.errorText = "Eğitim iptalini onaylamalısınız.";
            $scope.showWarning = true;
        }
        else {
            $scope.showWarning = false;
            $scope.disableCancel = true;

            $http({
                url: $scope.cancelAttendanceDataUrl,
                method: "POST",
                params: {
                    id: $scope.$parent.selectedAttendance.Id
                }
            }).success(function (data) {
                if (data && data.Success && data.Result) {

                    $scope.isCancelled = data.Result;
                    $scope.$parent.selectedAttendance.operationComplete = true;
                }
                else {
                    $scope.errorText = data.Message;
                    $scope.showWarning = true;
                }

                $scope.disableCancel = false;
            })
            .error(function (err) {
                $scope.errorText = err.Message;
                $scope.showWarning = true;
                $scope.disableCancel = false;
            });
        }
    };
}]);