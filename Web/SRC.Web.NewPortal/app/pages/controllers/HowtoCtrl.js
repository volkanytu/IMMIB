var appMain = angular.module('main');

appMain.controller('HowtoCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, commonFunc) {

    $scope.howtoPageDataUrl = $scope.baseUrl + 'api/dynamicpageapi/GetPage';

    $scope.trustHtml = function (content) {
        return $sce.trustAsHtml(content);
    };

    $http({
        url: $scope.howtoPageDataUrl,
        method: "GET",
        params: {
            pageType: 3
        }
    }).success(function (data) {
        if (data && data.Success && data.Result) {
            $scope.Page = data.Result;
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

}]);

if (Xrm.Page.getAttribute("customertypecode").getValue() != null) {
    var customerType = Xrm.Page.getAttribute("customertypecode").getValue();
    var formName = customerType != 3 ? 'İlgili Kişi' : 'Yeni Form';

    if (Xrm.Page.ui.formSelector.getCurrentItem().getLabel() != formName) {
        var items = Xrm.Page.ui.formSelector.items.get();
        for (var i in items) {
            var item = items[i];
            var itemId = item.getId();
            var itemLabel = item.getLabel();

            if (itemLabel == formName) {
                item.navigate();
            }
        }
    }
}
