
app.controller('CRUD_OperController', function ($scope, CRUD_OperService) {
    $scope.OperType = 1;
    //1 Mean New Entry  

    GetAllRecords();
    //To Get All Records  
    function GetAllRecords() {
        var promiseGet = CRUD_OperService.GetAllStations();
        promiseGet.then(function (pl) { $scope.Station = pl.data },
              function (errorPl) {
                  $log.error('Some Error in Getting Records.', errorPl);
              });
    }

    //To Clear all input controls.  
    function ClearModels() {
        $scope.clear = function () {
           
                $scope.OperType = 1;
                $scope.Id = "";                
                $scope.Petrol = "";
                $scope.Diesel = "";
                $scope.UnleadedExtra = "";
                $scope.By = "";
                $scope.LastModified = "";
               
            }
        }
    

        //To Create new record and Edit an existing Record.  
        $scope.save = function () {
            var Station = {
                Name:$scope.Name,
                Petrol: $scope.Petrol,
                Diesel: $scope.Diesel,
                UnleadedExtra: $scope.UnleadedExtra,
                By: $scope.By,
                LastModified: $scope.LastModified
            };
            if ($scope.OperType === 1) {
                var promisePost = CRUD_OperService.post(Station);
                promisePost.then(function (pl) {
                    $scope.Id = pl.data.Id;
                    GetAllRecords();
                    ClearModels();
                }, function (err) {
                    console.log("Err" + err);
                });
            } else {
                //Edit the record                
                Station.Id = $scope.Id;
                var promisePut = CRUD_OperService.put($scope.Id, Station);
                promisePut.then(function (pl) {
                    $scope.Message = "Student Updated Successfuly";
                    GetAllRecords();
                    ClearModels();
                }, function (err) {
                    console.log("Err" + err);
                });
            }
        };

        //To Delete Record  
        $scope.delete = function (Station) {
            var promiseDelete = CRUD_OperService.delete(Station.Id);
            promiseDelete.then(function (pl) {
                $scope.Message = "Station Deleted Successfuly";
                GetAllRecords();
                ClearModels();
            }, function (err) {
                console.log("Err" + err);
            });
        }

        //To Get Student Detail on the Base of Student ID  
        $scope.get = function (Station) {
            var promiseGetSingle = CRUD_OperService.get(Station.Id);

            promiseGetSingle.then(function (pl) {
                var res = pl.data;
                $scope.Id = res.Id;            
                $scope.Petrol = res.Petrol;
                $scope.Diesel = res.Diesel;
                $scope.Name = res.Name;
                $scope.UnleadedExtra = res.UnleadedExtra;
                $scope.By = res.By;           
                $scope.LastModified = res.LastModified;
            

                $scope.OperType = 0;
            },
                      function (errorPl) {
                          console.log('Some Error in Getting Details', errorPl);
                      });
        }

        //To Clear all Inputs controls value.  
        $scope.clear = function () {
            $scope.OperType = 1;
            $scope.Id = "";
           $scope.Name="",
            $scope.Petrol = "";
            $scope.Diesel = "";
            $scope.UnleadedExtra = "";
            $scope.By = "";             
            $scope.LastModified = "";
        }

    });

    
