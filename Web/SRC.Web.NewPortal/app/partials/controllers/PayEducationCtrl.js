﻿var appMain = angular.module('main');

appMain.controller('PayEducationCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', 'commonValues', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc, commonValues) {

    $scope.payEducationDataUrl = $scope.baseUrl + 'api/educationapi/PayEducation';
    $scope.installmentTypesDataUrl = $scope.baseUrl + 'api/commonapi/GetInstallmentTypes';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    commonValues.getInstallmentTypes(function (data) {
        $scope.InstallmentTypes = data;
    });

    $scope.CreditCardData = {};

    $scope.payEducation = function () {

        if ($scope.$parent.selectedAttendance.isAgreed != true) {
            $scope.errorText = "Ödeme koşullarını kabul ediyorum onaylamalısınız.";
            $scope.showWarning = true;
        }
        else {
            $scope.showWarning = false;
            $scope.disableApply = true;

            var request = $scope.CreditCardData;
            request.AttendanceId = $scope.$parent.selectedAttendance.Id;
            request.Amount = $scope.$parent.selectedAttendance.Amount;

            $scope.disablePay = true;

            $http({
                url: $scope.payEducationDataUrl,
                method: "POST",
                params: {

                },
                data: request
            }).success(function (data) {
                if (data && data.Success && data.Result) {

                    alertModal(data.Message, "success", function () {
                        window.location.reload();
                    });
                }
                else {
                    alertModal(data.Message, "error");
                }

                $scope.disablePay = false;
            })
            .error(function (err) {
                alertModal(err.Message, "error");
                $scope.disablePay = false;
            });
        }
    };
}]);