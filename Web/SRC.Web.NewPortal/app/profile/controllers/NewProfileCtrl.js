var appMain = angular.module('main');

appMain.controller('NewProfileCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', 'commonValues', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc, commonValues) {

    $scope.uploadFileText = null;

    $("input[inputtype='phonenumber']").mask("0(999)-999-9999");

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

    commonValues.getUniversities(function (data) {
        $scope.Universities = data;
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

        if ($scope.Contact.FirstName == null || $scope.Contact.LastName == null ||
            $scope.Contact.Gender == null || $scope.Contact.MobilePhone == null ||
            $scope.Contact.EmailAddress == null || $scope.Contact.City == null) {

            alertModal("Tüm alanlar dolu olmalıdır.", "error");

            return;
        }

        if ($scope.recordType == "0") { //Firma ise

            if ($scope.Contact.TaxNumber == null || $scope.Contact.CompanyName == null ||
                $scope.Contact.CompanyPosition == null) {

                alertModal("Tüm alanlar dolu olmalıdır.", "error");

                return;
            }

            $scope.Contact.CustomerType.AttributeValue = 1;
        }
        else {

            if ($scope.Contact.University == null) {
                alertModal("Tüm alanlar dolu olmalıdır.", "error");

                return;
            }

            if ($scope.OriginalFile == null) {
                alertModal("Öğrenci belgesi yükleyiniz.", "error");

                return;
            }

            $scope.Contact.CustomerType.AttributeValue = 2;

            $scope.Contact.PostedFile = $scope.OriginalFile.base64Data.substring($scope.OriginalFile.base64Data.indexOf(',') + 1);
            $scope.Contact.PostedFilename = $scope.OriginalFile.blob.name;
            $scope.Contact.PostedFileSize = $scope.OriginalFile.blob.size;
        }


        if ($scope.recordType == "0") //Firma çalışanı ise
        {
            if ($scope.Contact.ParentCustomer == null || typeof ($scope.Contact.ParentCustomer) == "undefined") {
                alertModal("Firma çalışanı olarak kayıt olabilmek için Vergi numarası ile Firma kontrolü yapmalısınız.", "error");

                return;
            }
        }

        var userNameMessage = "<br> Kullanıcı adınız mail adresinizdir.";
        $http({
            url: $scope.saveNewProfileDataUrl,
            method: "POST",
            params: {},
            data: $scope.Contact
        }).success(function (data) {
            if (data && data.Success && data.Result) {

                alertModal(data.Message + userNameMessage, "success", function () {
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

    $scope.OriginalFile = null;

    $scope.ReadFile = function (input) {

        if (input.files && input.files[0]) {

            var file = input.files[0];
            var reader = new FileReader();
            reader.readAsDataURL(file);

            reader.onload = function (e) {
                var base64Data = reader.result;
                if (file.type.indexOf("image") == -1) {
                    alertModal("Lütfen image türünde bir dosya seçiniz.", "error");

                    return;
                }

                var fileSize = parseInt(file.size / 1024);
                var fileName = file.name;

                safeApply($scope, function () {
                    $scope.uploadFileText = file.name;
                });

                //$("#lblFileSize").html(fileSize + " KB");
                //$("#lblFileName").html(fileName);

                $scope.OriginalFile = {};

                $scope.OriginalFile.blob = file;
                $scope.OriginalFile.fileName = file.name;
                $scope.OriginalFile.base64Data = base64Data;
                $scope.OriginalFile.fileSize = file.size;

            }

            reader.readAsDataURL(input.files[0]);
        }
    };

    $scope.SelectFile = function () {
        $("input[type='file']").click();
    };
}]);