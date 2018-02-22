(function () {
    "use strict";

    angular.module("common.services")
    .factory("cityResource", ["$resource", "appSettings", cityResource])
    function cityResource($resource, appsettings) {
        return $resource(appsettings.serverPath + "/api/cities/:id");
    }
}());