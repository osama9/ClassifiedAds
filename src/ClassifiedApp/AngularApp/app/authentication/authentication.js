(function () {
    'use strict';

    angular
      .module('authentication.controllers.AuthController', []);
    angular
      .module('authentication.controllers.LoginController', []);
    angular
      .module('authentication.controllers.RegisterController', []);


    angular
      .module('authentication.services.Auth', ['ngCookies']);

})();