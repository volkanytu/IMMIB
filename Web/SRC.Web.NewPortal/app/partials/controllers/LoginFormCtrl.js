var appMain = angular.module('main');

appMain.controller('LoginFormCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.loginDataUrl = $scope.baseUrl + 'api/contactapi/CheckLogin';
    $scope.userName = null;
    $scope.password = null;

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $scope.RememberPassword = function () {
        alert("REMEMBER");
    };

    $scope.SignIn = function () {
        window.location.href = $scope.baseUrl + "Profile/New/";
    };

    $scope.Login = function () {

        $scope.showWarning = false;
        $scope.disableButtons = true;
        $scope.errorText = null;

        $http({
            url: $scope.loginDataUrl,
            method: "POST",
            params: {
                userName: $scope.$$childHead.userName,
                password: $scope.$$childHead.password
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                $scope.Contact = data.Result;

                window.document.location.reload();
            }
            else {
                $scope.errorText = data.Message;
                $scope.showWarning = true;
            }

            $scope.disableButtons = false;
        });
    };
}]);