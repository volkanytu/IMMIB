var appMain = angular.module('main');

appMain.controller('NewProfileCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', 'commonValues', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc, commonValues) {

    $scope.saveNewProfileDataUrl = $scope.baseUrl + 'api/contactapi/SaveNewProfile';
    $scope.getCompanyDataUrl = $scope.baseUrl + 'api/contactapi/GetCompany';

    $scope.Contact = null;
    $scope.recordType = "0";

    commonValues.getCities(function (data) {
        $scope.Cities = data;
    });

    commonValues.getEducationLevels(function (data) {
        $scope.EducationLevels = data;
    });

    commonValues.getGenderCodes(function (data) {
        $scope.GenderCodes = data;
    });

    $scope.Save = function () {

        var password = $scope.Contact.Password;
        var rePassword = $scope.Contact.RePassword;

        if (password == null || typeof (password) == "undefined"
            || rePassword == null || typeof (rePassword) == "undefined"
            || password != rePassword) {

            alertModal("Şifre ve Şifre tekrar alanları dolu ve aynı olmalıdır.", "error");

            return;
        }

        $scope.Contact.CustomerType = {};
        $scope.Contact.CustomerType.AttributeValue = $scope.recordType;

        if ($scope.recordType == "0") //Firma çalışanı ise
        {
            if ($scope.Contact.ParentCustomer == null || typeof ($scope.Contact.ParentCustomer) == "undefined") {
                alertModal("Firma çalışanı olarak kayıt olabilmek için Vergi numarası ile Firma kontrolü yapmalısınız.", "error");

                return;
            }
        }

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

    $scope.checkCompany = function () {

        if ($scope.Contact.TaxNumber == null || typeof ($scope.Contact.TaxNumber) == "undefined") {
            alertModal("Firma arama için vergi numarası girmelisiniz.", "error");

            return;
        }

        $http({
            url: $scope.getCompanyDataUrl,
            method: "GET",
            params: {
                taxNumber: $scope.Contact.TaxNumber
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                $scope.Contact.ParentCustomer = data.Result;
                $scope.Contact.CompanyName = data.Result.Name;
            }
            else {
                alertModal(data.Message, "error");
            }
        })
        .error(function (err) {
            alertModal(err.Message, "error");
        });
    };
}]);