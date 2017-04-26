var appMain = angular.module('main');

appMain.controller('RememberPasswordCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.rememberPasswordDataUrl = $scope.baseUrl + 'api/contactapi/RememberPassword';

    $scope.emailAddress = null;

    $scope.Remember = function () {
        $scope.showWarning = false;
        $scope.disableApply = true;

        if ($scope.emailAddress == null || $scope.emailAddress == "")
        {
            $scope.errorText = "E-Posta alanı doldu olmalıdır.";
            $scope.showWarning = true;
            $scope.disableApply = false;
            return;
        }

        $http({
            url: $scope.rememberPasswordDataUrl,
            method: "POST",
            params: {
                emailAddress: $scope.emailAddress
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                $scope.Attendance = data.Result;
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
    };
}]);