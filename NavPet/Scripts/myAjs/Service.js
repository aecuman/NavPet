app.service('CRUD_OperService', function ($http) {

    //Create new record  
    this.post = function (Station) {
        var request = $http({
            method: "post",
            url: "/api/StationApi",
            data: Station
        });
        return request;
    }

    //Get Single Records  
    this.get = function (Id) {
        return $http.get("/api/StationApi/" + Id);
    }

    //Get All Student  
    this.GetAllStations = function () {
        return $http.get("/api/StationApi");
    }

    //Update the Record  
    this.put = function (Id, Station) {
        var request = $http({
            method: "put",
            url: "/api/StationApi/" + Id,
            data: Station
        });
        return request;
    }

    //Delete the Record  
    this.delete = function (Id) {
        var request = $http({
            method: "delete",
            url: "/api/StationApi/" + Id
        });
        return request;
    }
});
