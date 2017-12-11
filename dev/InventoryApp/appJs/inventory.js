
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

    //api/Accounts/UserRawMaterials
    this.getDistributionList = function () {
        var base_url = window.location.origin;
        var url = base_url + "/api/Accounts/UserRawMaterials";
        //
        var req = {
            method: 'GET',
            url: url,
            dataType: 'json'
        }

        var data = $http(req);
        return data;
    };

    this.getBeneficiery = function (refNo) {
        var base_url = window.location.origin;
        var url = base_url + "/api/Accounts/GetBeneficiery/"+refNo;
        //
        var req = {
            method: 'GET',
            url: url,
            dataType: 'json'
        }

        var data = $http(req);
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

    $scope.nameToSearch = "";
    $scope.isLoading = true;
    $scope.beneficieryName = '';
    
    $scope.allotementNumber = '';
    $scope.constituency = '';
    $scope.gpu = '';
    $scope.distance = '';
    $scope.DistributionNumber = '';
    $scope.DistributionList = null;
    $scope.BillNo = 0;

    $scope.userName = 'N/A  ';
    $scope.userPassword = "";
    $scope.beneficieryDetails = "";
    $scope.userDataDetails = {
        AllotementNumber: 0,
        DistributionNumber: 0,
        FormData: null
    };

    $scope.RawMaterials = null;

  
    //console.log(benefItems);
    //console.log(benefItems[1]);
    $scope.ProcessMatDistribution = function () {
        var data = ($scope.RawMaterials);
        $scope.userMaterialForm = {
            AllotementNumber: $scope.allotementNumber,
            DistributionNumber: $scope.BillNo,
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

            $scope.DistributionNumber = resp.data;
            //End

        }, function (err) {
            $scope.isLoading = false;

            console.log('printing error starts');
            console.log(err);
            $scope.Message = "Call-Failed";
        });
    }

    $scope.BeneficieryFound = null;
    $scope.GetBeneficiery = function (refNo) {
        var promise = AccountsService.getBeneficiery(refNo);
        promise.then(function (resp) {
            $scope.isLoading = false;
            var result = resp;
            if(resp){
                //$scope.beneficieryDetails = resp.data.AllotementNumber + '/' + resp.data.Name;
                //$scope.beneficieryName = resp.data.Name;
                //$scope.allotementNumber = resp.data.AllotementNumber;

                //$scope.constituency = resp.data.Constituency;
                //$scope.gpu = resp.data.GPU;
                //$scope.distance = resp.data.Distance;
                $scope.BeneficieryFound = resp.data;
                console.log($scope.BeneficieryFound);
            }
            else {
                //$scope.beneficieryDetails = '';
                //$scope.beneficieryName = '';
                //$scope.allotementNumber = '';
                $scope.BeneficieryFound = null;
                console.log('error');
            }

            //End
        }, function (err) {
            $scope.isLoading = false;

            console.log('printing error starts');
            console.log(err);
            $scope.Message = "Call-Failed";
        });
    }

    $scope.BeneficierySelected = function (index) {
        var beneSelected = $scope.BeneficieryFound[index];
        $scope.beneficieryName = beneSelected.Name;
        $scope.allotementNumber = beneSelected.AllotementNumber;
        $scope.allotementNumber = beneSelected.AllotementNumber;
        $scope.constituency = beneSelected.Constituency;
        $scope.gpu = beneSelected.GPU;
    }

    //BeneficierySelected

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

    $scope.GetDistributionList = function () {
        var promise = AccountsService.getDistributionList();
        promise.then(function (resp) {
            $scope.isLoading = false;

            var result = resp;
            console.log('Response :', result);
            $scope.DistributionList = resp.data;

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

