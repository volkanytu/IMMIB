var appMain = angular.module('main');

appMain.controller('RememberPasswordCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.rememberPasswordDataUrl = $scope.baseUrl + 'api/contactapi/RememberPassword';

    $scope.userEmailAddress = null;

    $scope.Remember = function () {
        $scope.showWarning = false;
        $scope.disableApply = true;

        if ($scope.$$childHead.userEmailAddress == null || $scope.$$childHead.userEmailAddress == "") {
            $scope.errorText = "E-Posta alanı doldu olmalıdır.";
            $scope.showWarning = true;
            $scope.disableApply = false;
            return;
        }

        $http({
            url: $scope.rememberPasswordDataUrl,
            method: "POST",
            params: {
                emailAddress: $scope.$$childHead.userEmailAddress
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                alertModal(data.Message, "success", function () {
                    window.document.location.reload();
                });
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