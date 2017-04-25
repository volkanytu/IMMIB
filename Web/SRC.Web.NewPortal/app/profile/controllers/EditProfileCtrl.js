var appMain = angular.module('main');

appMain.controller('EditProfileCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', 'commonValues', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc, commonValues) {

    $("input[inputtype='phonenumber']").mask("0(999)-999-9999");

    $scope.getProfileDataUrl = $scope.baseUrl + 'api/contactapi/GetContact';
    $scope.updateNewProfileDataUrl = $scope.baseUrl + 'api/contactapi/UpdateProfile';
    $scope.changePasswordDataUrl = $scope.baseUrl + 'api/contactapi/ChangePassword';

    $scope.checkGetContact = function () {

        if (typeof ($scope.Cities) != "undefined" && typeof ($scope.EducationLevels) != "undefined" && typeof ($scope.GenderCodes) != "undefined"
            && typeof ($scope.Universities) != "undefined") {

            $scope.getContact();
        }
    };

    $scope.getContact = function () {

        $http({
            url: $scope.getProfileDataUrl,
            method: "GET",
            params: {

            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                $scope.Contact = data.Result;

                var obj = $scope.Contact;

                if ($scope.Contact.City != null) {

                    var elementPos = $scope.Cities.map(function (x) { return x.Id; }).indexOf($scope.Contact.City.Id);

                    $scope.Contact.City = $scope.Cities[elementPos];
                }

                if ($scope.Contact.Gender != null) {

                    var elementPos = $scope.GenderCodes.map(function (x) { return x.AttributeValue; }).indexOf($scope.Contact.Gender.AttributeValue);

                    $scope.Contact.Gender = $scope.GenderCodes[elementPos];
                }

                if ($scope.Contact.EducationLevel != null) {

                    var elementPos = $scope.EducationLevels.map(function (x) { return x.AttributeValue; }).indexOf($scope.Contact.EducationLevel.AttributeValue);

                    $scope.Contact.EducationLevel = $scope.EducationLevels[elementPos];
                }

                if ($scope.Contact.CustomerType != null) {

                    if ($scope.Contact.CustomerType.AttributeValue == 1)
                    {
                        $scope.recordType = 0;
                    }
                    else
                    {
                        $scope.recordType = 1;
                    }
                }
            }
            else {
                alertModal(data.Message, "error");
            }
        })
        .error(function (err) {
            alertModal(err.Message, "error");
        });
    };

    $scope.updateContact = function () {

        $http({
            url: $scope.updateNewProfileDataUrl,
            method: "POST",
            params: {

            },
            data: $scope.Contact
        }).success(function (data) {
            if (data && data.Success && data.Result) {

                alertModal(data.Message, "success", function () {
                    window.location.reload();
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

    $scope.changePassword = function () {

        var oldPassword = $scope.oldPassword;
        var newPassword = $scope.newPassword;
        var reNewPassword = $scope.reNewPassword;

        if (oldPassword == null || typeof (oldPassword) == "undefined"
            || newPassword == null || typeof (newPassword) == "undefined"
            || reNewPassword == null || typeof (reNewPassword) == "undefined"
            || newPassword != reNewPassword) {

            alertModal("Tüm alanlar dolu, Şifre ve Şifre Tekrar alanları aynı olmalıdır.", "error");

            return;
        }

        $http({
            url: $scope.changePasswordDataUrl,
            method: "POST",
            params: {
                oldPassword: $scope.oldPassword,
                newPassword: $scope.newPassword,
                reNewPassword: $scope.reNewPassword
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {

                alertModal(data.Message, "success", function () {
                    window.location.reload();
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


    commonValues.getCities(function (data) {
        $scope.Cities = data;

        $scope.checkGetContact();

    });

    commonValues.getEducationLevels(function (data) {
        $scope.EducationLevels = data;

        $scope.checkGetContact();
    });

    commonValues.getGenderCodes(function (data) {
        $scope.GenderCodes = data;

        $scope.checkGetContact();
    });

    commonValues.getUniversities(function (data) {
        $scope.Universities = data;

        $scope.checkGetContact();
    });

}]);