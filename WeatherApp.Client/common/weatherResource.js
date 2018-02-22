(function () {
    "use strict";

    angular.module("common.services")
    .factory("weatherResource", [
        "$resource",
        "appSettings",
        "currentUser",
        weatherResource
    ])
    function weatherResource($resource, appsettings, currentUser) {
        return $resource(appsettings.serverPath + "/api/weather/:id", null,
            {
                'retrieve': {
                    method: 'GET',
                    //headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
                'create': {
                    method: 'POST',
                    //headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
                'update': {
                    method: 'PUT',
                    //headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },
            });
    }
}());