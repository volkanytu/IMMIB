var appMain = angular.module('main');

appMain.controller('EditorCtrl', ['$scope', '$sce', '$http', '$routeParams', 'safeApply', 'alertModal', 'flexSlider', 'commonFunc', function ($scope, $sce, $http, $routeParams, safeApply, alertModal, flexSlider, commonFunc) {
    debugger;
    var id = $routeParams.id;
    var typeName = $routeParams.typename;
    var typeCode = $routeParams.type;
    var fieldName = $routeParams.fieldName;

    $scope.getEntityFieldValueDataUrl = $scope.baseUrl + 'api/editorapi/GetEntityFieldValue';
    $scope.setEntityFieldValueDataUrl = $scope.baseUrl + 'api/editorapi/SetEntityFieldValue';
    $scope.isSaveDisabled = true;

    if (id == null || id == ""
        || typeName == null || typeName == ""
        || typeCode == null || typeCode == ""
        || fieldName == null || fieldName == "") {
         
        $scope.isSaveDisabled = false;
        return;
    }

    CKEDITOR.replace('txtEdit', {
        height: 400,
        //filebrowserBrowseUrl: 'ckfinder/ckfinder.html',
        //filebrowserUploadUrl: 'ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files',
        filebrowserWindowWidth: '1000',
        filebrowserWindowHeight: '700'
    });

    $http({
        url: $scope.getEntityFieldValueDataUrl,
        method: "GET",
        params: {
            id: id,
            typeName: typeName,
            typeCode: typeCode,
            fieldName: fieldName
        }
    }).success(function (data) {
        if (data != null && data.Success) {
            CKEDITOR.instances.txtEdit.setData(data.Result);
        }
        else {
            alertModal(data.Message, "error");
        }
    })
    .error(function (err) {
        alertModal(err.Message, "error");
    });

    $scope.SaveText = function () {

        var request = {};
        request.id = id;
        request.typeName = typeName;
        request.typeCode = typeCode;
        request.fieldName = fieldName;
        request.fieldValue = CKEDITOR.instances.txtEdit.getData();

        $http({
            url: $scope.setEntityFieldValueDataUrl,
            method: "POST",
            params: {
            },
            data: request
        }).success(function (data) {
            if (data && data.Success && data.Result) {
                alertModal(data.Message, "success");
            }
            else {
                alertModal(data.Message, "error");
            }
        })
        .error(function (err) {
            alertModal(err.Message, "error");
        });
    };

}]);