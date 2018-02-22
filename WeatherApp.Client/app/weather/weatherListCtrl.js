(function () {
    "use strict";
    angular.module("weatherApp").controller("WeatherListCtrl", [
        "weatherResource",
        "cityResource",
        WeatherListCtrl
    ]);

    function WeatherListCtrl(weatherResource, cityResource) {
        var vm = this;
        vm.filterBy = "Warsaw";

        cityResource.query(function (data) {
            vm.cities = data;
        });

        weatherResource.query(function (data) {
            vm.weathers = data;
        });

    }
}());
