var appMain = angular.module('main');

appMain.controller('ApplyEducationCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.applyPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';
    $scope.applyEducationDataUrl = $scope.baseUrl + 'api/educationapi/ApplyEducation';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.applyPageDataUrl,
        method: "GET",
        params: {
            pageType: 6
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Page = data.Result;
        }
    });

    $scope.applyEducation = function () {

        if ($scope.$parent.selectedEducation.isAgreed != true) {
            $scope.errorText = "Eğitim başvuru ve koşullarını kabul ediyorum onaylamalısınız.";
            $scope.showWarning = true;
        }
        else {
            $scope.showWarning = false;
            $scope.disableApply = true;

            $http({
                url: $scope.applyEducationDataUrl,
                method: "POST",
                params: {
                    id: $scope.$parent.selectedEducation.Id
                }
            }).success(function (data) {
                if (data && data.Success && data.Result) {
                    $scope.Attendance = data.Result;

                    $scope.$parent.selectedEducation.operationComplete = true;
                }
                else {
                    $scope.errorText = data.Message;
                    $scope.showWarning = true;
                }

                $scope.disableApply = false;
            })
            .error(function (err) {
                $scope.errorText = err.Message;
                $scope.showWarning = true;
                $scope.disableApply = false;
            });
        }
    };
}]);