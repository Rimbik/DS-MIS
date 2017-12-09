
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

    this.submitRawMaterialDistribution = function (userData) {
        var base_url = window.location.origin;
        var url = base_url + "/api/Accounts/RawMaterialDistribute";
        //
        var req = {
            method: 'POST',
            url: url,
            dataType: 'json',
            data: userData
        }

        var data = $http(req);
        return data;
    };

    
});

//Declaring the Controller
app.controller('AccountsController', function ($scope, AccountsService) {

    $scope.isLoading = true;
    $scope.userName = 'N/A  ';
    $scope.userPassword = "";
    $scope.userDataDetails = {
        UserId: 0,
        FormData: null
    };

    $scope.RawMaterials = null;

  
    //console.log(benefItems);
    //console.log(benefItems[1]);
    $scope.ProcessMatDistribution = function () {
        var data = ($scope.RawMaterials);
        $scope.userMaterialForm = {
            UserId: 1,
            UserMaterial: data
        }

        submitUserData($scope.userMaterialForm);
    }

    function submitUserData(userData)
    {
        var promise = AccountsService.submitRawMaterialDistribution(userData);
        promise.then(function (resp) {
            $scope.isLoading = false;
            var result = resp;
            console.log('submitRawMaterialDistribution', resp);


            //End

        }, function (err) {
            $scope.isLoading = false;

            console.log('printing error starts');
            console.log(err);
            $scope.Message = "Call-Failed";
        });
    }

    GetRawMaterials();

    function GetRawMaterials() {
        var promise = AccountsService.getRawMaterials();
        promise.then(function (resp) {
            $scope.isLoading = false;

            var result = resp;
            console.log('Response :', result);
            $scope.RawMaterials = resp.data; 
            $scope.RawMaterials.forEach(function (item) {
                item["Quantity"] = 0;
                item["Unit"] = 0;
                item["Rate"] = 0;
            });
            console.log('$scope.RawMaterials', $scope.RawMaterials);


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

