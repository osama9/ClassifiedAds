(function () {
    angular.module('classified.controllers')
        .controller('CreateAdController', CreateAdController);

    CreateAdController.$inject = ['$scope', 'Classified'];

    function CreateAdController($scope, Classified) {
        var vm = this;
        vm.categories = [];
        vm.cities = [];
        images = [];
        vm.success = success;
        //vm.images = [];
        function success(message) {
            images.push(message.replace(/"/g,""));
            vm.images= images.join(';');
            //vm.images.push(message);
            console.log(message);
        }


        Classified.getCategories().then(getCategoriesSuccessFn, getCategoriesErrorFn);

        function getCategoriesSuccessFn(data, status, headers, config) {
            vm.categories = data.data
        }

        function getCategoriesErrorFn(data, status, headers, config) {

        }

        Classified.getCities().then(getCitiesSuccessFn, getCitiesErrorFn);

        function getCitiesSuccessFn(data, status, headers, config) {
            vm.cities = data.data;
        }

        function getCitiesErrorFn(data, status, headers, config) {

        }

    }
})();