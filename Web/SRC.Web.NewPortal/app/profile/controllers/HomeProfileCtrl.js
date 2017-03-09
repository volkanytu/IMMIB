var appMain = angular.module('main');

appMain.controller('HomeProfileCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.getProfileDataUrl = $scope.baseUrl + 'api/contactapi/GetContact';

    $http({
        url: $scope.getProfileDataUrl,
        method: "GET",
        params: {

        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Contact = data.Result;

            var obj = $scope.Contact;
        }
    });
}]);