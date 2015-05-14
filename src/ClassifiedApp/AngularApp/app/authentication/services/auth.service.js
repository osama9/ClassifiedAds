(function () {
    'use strict';
    angular
    .module('thinkster.authentication.services')
    .factory('Authentication', Authentication);

    Authentication.$inject = ['cookies', '$http'];

    function Authentication($cookies, $http) {
        var Authentication = {
            getAuthenticatedAccount: getAuthenticatedAccount,
            isAuthenticated: isAuthenticated,
            login: login,
            logout: logout,
            register: register,
            setAuthenticatedAccount: setAuthenticatedAccount,
            unauthenticate: unauthenticate
        };

        return Authentication;

        function getAuthenticatedAccount() {
            if (!$cookies.authenticatedAccount) {
                return;
            }
            
            return JSON.parse($cookies.authenticatedAccount);
        }

        function isAuthenticated() {
            return !!$cookies.authenticatedAccount;
        }

        function login(email, password) {
            return $http.post('/api/v1/auth/login/', {
                email: email, password: password
            }).then(loginSuccessFn, loginErrorFn);

            function loginSuccessFn(data, status, headers, config) {
                Authentication.setAuthenticatedAccount(data.data);

                window.location.href = '/';
            }

            function loginErrorFn(data, status, headers, config) {
                console.log('Epic failure!');
            }
        }

        function logout() {
            return $http.post('/api/v1/auth/logout/')
            .then(logoutSuccessFn, logoutErrorFn);

            function logoutSuccessFn(data, request, headers, config){
                Authentication.unauthenticate();
                window.location.href = '/';
            }

            function logoutErrorFn(data, request, headers, config) {
                console.log('Epic failure!')
            }
        }
        function register(email, password, username) {
            $http.post('/api/v1/accounts/', {
                username: username,
                password: password,
                email: email
            }).then(registerSuccessFn, registerErrorFn);

            function registerSuccessFn(data, status, headers, config) {
                Authentication.login(email, password);
            }

            function registerErrorFn(data, status, headers, config) {
                console.log('Epic failure!');
            }
        }

        function setAuthenticatedAccount(account) {
            $cookies.authenticatedAccount = JSON.stringify(account);
        }

        function unauthenticate() {
            delete $cookies.authenticatedAccount;
        }
    }
})();