var appMain = angular.module('main');

appMain.controller('HomeCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'flexSlider', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, flexSlider, commonFunc) {
    commonFunc();

    $scope.sliderPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetSliderPageList';
    $scope.comingEducationsDataUrl = $scope.baseUrl + 'api/educationapi/GetComingEducationList';
    $scope.doneEducationsDataUrl = $scope.baseUrl + 'api/educationapi/GetDoneEducationList';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        flexSlider();
    });

    $http({
        url: $scope.sliderPageDataUrl,
        method: "GET",
        params: {
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.SliderData = data.Result;
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

    $http({
        url: $scope.comingEducationsDataUrl,
        method: "GET",
        params: {
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.ComingEducations = data.Result;

            var counter = 0;

            for (var education in $scope.ComingEducations) {

                var obj = $scope.ComingEducations[education];

                if (counter % 2 == 0) {
                    obj.color = "green";
                    obj.alt = "";
                    obj.arrow = "arrow";
                }
                else {
                    obj.color = "red";
                    obj.alt = "alt";
                    obj.arrow = "arrow-alt";
                }

                counter++;
            }
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

    $http({
        url: $scope.doneEducationsDataUrl,
        method: "GET",
        params: {
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.DoneEducations = data.Result;

            var counter = 0;

            for (var education in $scope.DoneEducations) {

                var obj = $scope.DoneEducations[education];

                if (counter % 2 == 0) {
                    obj.color = "green";
                    obj.alt = "";
                    obj.arrow = "arrow";
                }
                else {
                    obj.color = "red";
                    obj.alt = "alt";
                    obj.arrow = "arrow-alt";
                }

                counter++;
            }
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });
}]);