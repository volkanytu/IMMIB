var appMain = angular.module('main');

appMain.controller('LoginFormCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.loginDataUrl = $scope.baseUrl + 'api/contactapi/CheckLogin';
    $scope.userName = null;
    $scope.password = null;

    //$("#loginForm").validate();

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $scope.RememberPassword = function () {
        alertModal("Yapım aşamasında.", "info");
    };

    $scope.SignIn = function () {
        window.location.href = $scope.baseUrl + "Profile/New/";
    };

    $scope.Login = function () {

        var userName = $scope.$$childHead.userName;
        var password = $scope.$$childHead.password;

        if (userName == null || typeof (userName) == "undefined" || userName == ""
            || password == null || typeof (password) == "undefined" || password == "") {

            $scope.errorText = "Kullanıcı adı ve şifre alanları dolu olmalıdır.";
            $scope.showWarning = true;

            return;
        }

        $scope.showWarning = false;
        $scope.disableButtons = true;
        $scope.errorText = null;

        $http({
            url: $scope.loginDataUrl,
            method: "POST",
            params: {
                userName: userName,
                password: password
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
        })
        .error(function (err) {
            $scope.errorText = err.Message;
            $scope.showWarning = true;
        });
    };
}]);