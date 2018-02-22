(function () {
    "use strict";

    angular.module("weatherApp").controller("MainCtrl", [
        "userAccount",
        "currentUser",
        MainCtrl
    ]);

    function MainCtrl(userAccount, currentUser) {
        var vm = this;
        vm.isLoggedIn = function () {
            return currentUser.getProfile().isLoggedIn;
        };
        vm.message = '';
        vm.userData = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: '',
        };

        vm.registerUser = function () {
            vm.userData.confirmPassword = vm.userData.password;

            userAccount.registration.registerUser(vm.userData,
                function (data) {
                    vm.confirmPassword = "";
                    vm.message = "Registration Success";
                    vm.login();
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

        vm.login = function () {
            vm.userData.grant_type = "password";
            vm.userData.userName = vm.userData.email;

            userAccount.login.loginUser(vm.userData,
                function (data) {
                    vm.message = '';
                    vm.password = "";
                    currentUser.setProfile(vm.userData.userName, data.access_token);
                },
                function (response) {
                    vm.password = "";
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

        vm.logout = function () {
            userAccount.logout.logoutUser(
                function (data) {
                    vm.message = '';
                    currentUser.deleteProfile();
                },
                function (response) {
                    vm.password = "";
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
    }

})();