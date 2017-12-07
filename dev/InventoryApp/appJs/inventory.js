
//The Module Declaration
var app = angular.module('AccountsApp', []);

//Declaring Service
app.service('AccountsService', function ($http) {

    this.getRawMaterials = function (userName, callback) {
        var base_url = window.location.origin;
        var url = base_url + "/api/Accounts/RawMaterial";
        //
        var req = {
            method: 'GET',
            url: url,
            dataType: 'json'
        }

        var data = $http(req).then(callback);
        return data;
    };

    
});

//Declaring the Controller
app.controller('AccountsController', function ($scope, AccountsService) {

    $scope.isLoading = true;
    $scope.userName = 'N/A  ';
    $scope.userPassword = "";
    $scope.RawMaterials = null;

    GetRawMaterials();

    function GetRawMaterials() {
        var promise = AccountsService.getRawMaterials();
        promise.then(function (resp) {
            $scope.isLoading = false;

            var result = resp;
            console.log('Response :', result);
            $scope.RawMaterials   = resp.data; 
            //End

        }, function (err) {
            $scope.isLoading = false;

            console.log('printing error starts');
            console.log(err);
            console.log('printing error (GetUserCar) end');
            $scope.Message = "Call-Failed";
        });
    }

    
});

