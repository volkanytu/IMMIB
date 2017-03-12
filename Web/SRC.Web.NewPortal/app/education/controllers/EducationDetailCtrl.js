var appMain = angular.module('main');

appMain.controller('EducationDetailCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.educationListDataUrl = $scope.baseUrl + 'api/educationapi/GetEducation';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.educationListDataUrl,
        method: "GET",
        params: {
            id: $routeParams.id
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Education = data.Result;

            var obj = $scope.Education;

            obj.Apply = function (educationObject) {

                if ($scope.isLoggedIn == "False") {

                    alertModal("Başvuru yapmak için giriş yapmalısınız!", "error");

                    return;
                }

                var education = $scope.Education;
                $("#applyModal").modal();
                $('#applyModal').on('hidden.bs.modal', function () {
                    if ($scope.selectedEducation.operationComplete) {
                        window.location.reload();
                    }
                });

                $scope.selectedEducation = education;
            };

            obj.Cancel = function (educationObject) {

                var education = educationObject.Education;

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

                var education = educationObject.Education;

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

            if ($scope.Education.IsExpired) {
                $scope.Education.class = "label-danger";
                $scope.Education.StatusText = "Eğitim Gerçekleşti";
                $scope.showApply = false;
            }
            else if ($scope.Education.LeftQuota == null || $scope.Education.LeftQuota < 1) {
                $scope.Education.class = "label-warning";
                $scope.Education.StatusText = "Kontenjan Doldu";
                $scope.showApply = false;
            }
            else {
                $scope.Education.class = "label-success";
                $scope.Education.StatusText = "Başvuru Açık";
                $scope.showApply = $scope.Education.Attendance == null;
            }
        }
    });
}]);