(function () {
    "use strict";

    angular.module("common.services")
    .factory("currentUser", ["$http",currentUser])
    function currentUser($http) {
        var profile = {
            isLoggedIn: false,
            username: "",
            token: "",
        };
        var setProfile = function (username, token) {
            profile.username = username;
            profile.token = token;
            profile.isLoggedIn = true;
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;
        };
        var getProfile = function () {
            return profile;
        }
        var deleteProfile = function () {
            profile.username = '';
            profile.token = '';
            profile.isLoggedIn = false;
            $http.defaults.headers.common = {};
        }
        return {
            setProfile: setProfile,
            getProfile: getProfile,
            deleteProfile: deleteProfile,
        }
    }
}());