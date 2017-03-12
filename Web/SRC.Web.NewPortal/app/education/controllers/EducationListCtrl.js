var appMain = angular.module('main');

appMain.controller('EducationListCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    commonFunc();

    $scope.educationListDataUrl = $scope.baseUrl + 'api/educationapi/GetList';

    $scope.nowMonth = new Date().getMonth() + 1;
    $scope.nowYear = new Date().getFullYear();
    $scope.Months = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
    $scope.Years = [2015, 2016, 2017, 2018, 2019, 2020];

    $scope.dateChange = function () {
        $scope.GetList();
    };

    $scope.nextMonth = function () {
        if ($scope.nowMonth == 12) {
            $scope.nowMonth = 1;
            $scope.nowYear = $scope.nowYear + 1;
        }
        else {
            $scope.nowMonth = $scope.nowMonth + 1;
        }

        $scope.dateChange();
    };

    $scope.previousMonth = function () {
        if ($scope.nowMonth == 1) {
            $scope.nowMonth = 12;
            $scope.nowYear = $scope.nowYear - 1;
        }
        else {
            $scope.nowMonth = $scope.nowMonth - 1;
        }

        $scope.dateChange();
    };

    $scope.reload = function () {
        window.location.reload(false);
    };


    $scope.GetList = function () {
        $http({
            url: $scope.educationListDataUrl,
            method: "GET",
            params: {
                month: $scope.nowMonth,
                year: $scope.nowYear
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
        });
    };

    $scope.GetList();

}]);