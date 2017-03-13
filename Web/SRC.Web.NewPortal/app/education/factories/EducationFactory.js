angular.module('main')
.factory('educationFactory', ['$rootScope', '$http', function ($rootScope, $http) {

    var educationListDataUrl = $rootScope.baseUrl + 'api/educationapi/GetList';
    return {

        GetList: function (month, year, onSuccess, onError) {
            $http({
                url: educationListDataUrl,
                method: "GET",
                params: {
                    month: month,
                    year: year
                }
            }).success(function (data) {
                if (data && data.Success && data.Result) {
                    onSuccess(data);
                }
                else {
                    onError(data);
                }
            })
            .error(function (err) {
                onError(err);
            });
        }
    };
}]);