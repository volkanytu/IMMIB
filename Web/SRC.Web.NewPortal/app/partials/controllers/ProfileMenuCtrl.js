var appMain = angular.module('main');

appMain.controller('ProfileMenuCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.applyPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';
    $scope.applyEducationDataUrl = $scope.baseUrl + 'api/educationapi/ApplyEducation';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };


}]);