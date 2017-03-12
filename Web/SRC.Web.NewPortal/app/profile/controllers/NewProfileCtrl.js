var appMain = angular.module('main');

appMain.controller('NewProfileCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.getCitiesDataUrl = $scope.baseUrl + 'api/commonapi/GetCities';
    $scope.getEducationLevelsDataUrl = $scope.baseUrl + 'api/commonapi/GetEducationLevels';
    $scope.getGenderCodesDataUrl = $scope.baseUrl + 'api/commonapi/GetGenderCodes';
    $scope.saveNewProfileDataUrl = $scope.baseUrl + 'api/contactapi/SaveNewProfile';

    $scope.Contact = null;
    $scope.recordType = "0";

    $http({
        url: $scope.getCitiesDataUrl,
        method: "GET",
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Cities = data.Result;
        }
    });

    $http({
        url: $scope.getEducationLevelsDataUrl,
        method: "GET",
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.EducationLevels = data.Result;
        }
    });

    $http({
        url: $scope.getGenderCodesDataUrl,
        method: "GET",
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.GenderCodes = data.Result;
        }
    });

    $scope.Save = function () {

        var asd = $scope.Contact;

        $http({
            url: $scope.saveNewProfileDataUrl,
            method: "POST",
            params: {

            },
            data: $scope.Contact
        }).success(function (data) {
            if (data && data.Success && data.Result) {

                alertModal(data.Message, "success", function () {
                    window.location.href = $scope.baseUrl;
                });
            }
            else {
                alertModal(data.Message, "error");
            }

            $scope.disableSave = false;
        })
        .error(function (err) {
            alertModal(err.Message, "error");
            $scope.disableSave = false;
        });
    };
}]);