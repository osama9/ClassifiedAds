﻿(function () {
    'use strict';
    angular
    .module('authentication.controllers.LoginController')
    .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', '$scope', 'Authentication'];


    function LoginController($location, $scope, Authentication) {
        var vm = this;

        vm.login = login;

        activate();

        function activate() {
            if (Authentication.isAuthenticated()) {
                $location.url('/');
            }
        }

        function login() {
            Authentication.login(vm.email, vm.password);
        }
    }

})();