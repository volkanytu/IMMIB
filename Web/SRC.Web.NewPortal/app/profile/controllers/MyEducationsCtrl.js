var appMain = angular.module('main');

appMain.controller('MyEducationsCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.educationListByStatusDataUrl = $scope.baseUrl + 'api/educationapi/GetEducationByStatus';
    $scope.educationListDataUrl = $scope.baseUrl + 'api/educationapi/GetList';
    $scope.getProfileDataUrl = $scope.baseUrl + 'api/contactapi/GetContact';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    if ($routeParams.status == 100000000)
    {
        $scope.headerText = "Ödeme Bekleyen Eğitimler";
    }
    else if ($routeParams.status == 100000001)
    {
        $scope.headerText = "Onaylanan Eğitimler";
    }
    else if ($routeParams.status == 100000004) {
        $scope.headerText = "Katıldığım Eğitimler";
    }

    $http({
        url: $scope.getProfileDataUrl,
        method: "GET",
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Contact = data.Result;
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

    $scope.GetList = function () {
        $http({
            url: $scope.educationListByStatusDataUrl,
            method: "GET",
            params: {
                status: $routeParams.status
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                $scope.EducationList = data.Result;

                for (var education in $scope.EducationList) {

                    var obj = $scope.EducationList[education];

                    obj.Apply = function (educationObject) {

                        if ($scope.isLoggedIn == "False") {

                            alertModal("Başvuru yapmak için giriş yapmalısınız!", "warning");

                            return;
                        }

                        var education = educationObject.education;
                        $("#applyModal").modal();

                        $('#applyModal').on('hidden.bs.modal', function () {
                            if ($scope.selectedEducation.operationComplete) {
                                window.location.reload();
                            }
                        });


                        $scope.selectedEducation = education;
                    };

                    obj.Cancel = function (educationObject) {

                        var education = educationObject.education;

                        if (education.Attendance.IsPaymentDone == true) {

                            alertModal("Eğitim katılımını iptal etmek için eğitim birimi ile görüşünüz.", "info");

                            return;
                        }

                        $("#cancelModal").modal();

                        $('#cancelModal').on('hidden.bs.modal', function () {
                            if ($scope.selectedAttendance.operationComplete) {
                                window.location.reload();
                            }
                        });

                        $scope.selectedAttendance = education.Attendance;
                    };

                    obj.Pay = function (educationObject) {

                        var education = educationObject.education;

                        if (education.Attendance.IsPaymentDone == true) {

                            alertModal("Eğitim için ödemeniz alınmıştır.", "info");

                            return;
                        }

                        $("#paymentModal").modal();

                        $('#paymentModal').on('hidden.bs.modal', function () {
                            if ($scope.selectedAttendance.operationComplete) {
                                window.location.reload();
                            }
                        });

                        education.Attendance.Amount = education.EducationAmount;
                        $scope.selectedAttendance = education.Attendance;
                    };

                    if (obj.IsExpired) {
                        obj.class = "label-danger";
                        obj.StatusText = "Eğitim Gerçekleşti";
                        obj.showApply = false;
                    }
                    else if (obj.LeftQuota == null || obj.LeftQuota < 1) {
                        obj.class = "label-warning";
                        obj.StatusText = "Kontenjan Doldu";
                        obj.showApply = false;
                    }
                    else {
                        obj.class = "label-success";
                        obj.StatusText = "Başvuru Açık";
                        obj.showApply = obj.Attendance == null;
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

    $scope.GetList();
}]);