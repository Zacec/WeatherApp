(function () {
    "use strict";

    angular.module("weatherApp").controller("WeatherEditCtrl", [
        "weatherResource",
        "cityResource",
        WeatherEditCtrl
    ]);

    function WeatherEditCtrl(weatherResource, cityResource) {
        var vm = this;
        vm.weather = {};
        vm.message = '';
        vm.id = 0;
        vm.title = "New Weather";
        vm.filterBy = "Warsaw";

        cityResource.query(function (data) {
            vm.cities = data;
        });

        weatherResource.query(function (data) {
            vm.weathers = data;
        });

        vm.getWeather = function() {
            weatherResource.retrieve({ id: vm.id },
                function (data) {
                    vm.weather = data;
                    vm.originalWeather = angular.copy(data);
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    
                    if (response.data.exceptionMessage) {
                        vm.message = response.data.exceptionMessage;
                    }
                });
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.weather.id) {
                vm.weather.$update({ id: vm.weather.id }, function (data) {
                    vm.message = 'Saved!';
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState + "\r\n";
                        }
                    }
                    if (response.data.exceptionMessage) {
                        vm.message = response.data.exceptionMessage;
                    }
                });
            }
            else {
                weatherResource.create(vm.weather, function (data) {
                    vm.originalWeather = angular.copy(data);
                    vm.message = 'Saved!';
                    weatherResource.query(function (data) {
                        vm.weathers = data;
                    });
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState + "\r\n";
                        }
                    }
                    if (response.data.exceptionMessage) {
                        vm.message = response.data.exceptionMessage;
                    }
                });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.weather = angular.copy(vm.originalWeather);
            vm.message = "";
        };

        vm.setTitle = function () {
            vm.title = "New Weather";
        }

        vm.edit = function (weather) {
            vm.weather = weather;
            vm.originalWeather = angular.copy(weather);
            vm.title = "Edit Weather";
            $('.modal').modal('show').on('hidden.bs.modal', function (e) {
                vm.title = "New Weather";
                vm.weather = {};
                vm.message = "";
            });
        };

    }

}());
