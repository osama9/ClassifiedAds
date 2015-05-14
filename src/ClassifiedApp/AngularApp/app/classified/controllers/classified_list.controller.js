(function(){
	'use strict';


	angular.module('classified.controllers')
	 .controller('ClassifiedListController', ClassifiedListController);

	 ClassifiedListController.$inject = ['$scope', 'Classified', '$location'];
	 function ClassifiedListController($scope, Classified, $location){
	 	
	 	var vm = this;
	 	vm.categories =[];
	 	vm.cities = [];
	 	vm.added = added;
	 	vm.success = success;
	 	activate();
	 	function added(file, success) {
	 	    //console.log(file);
	 	}

	 	function success(message) {
            //TODO Handlinh the custom server respons
	 	    console.log(message);
	 	}
	 	function activate(){
	 		
	 		//CommonService.transformImagesToPath();
	 		Classified.getClassifiedList().then(getClassifiedListSuccessFn, getClassifiedListErrorFn);

	 		function getClassifiedListSuccessFn(data, status, headers, config) {
	 		    console.log(data.data);
	 			vm.classifiedList = data.data;
	 		}

	 		function getClassifiedListErrorFn(data, status, headers, config ){
	 			console.log("ERROR");
	 			console.log(data);
	 		}

	 		Classified.getCategories().then(getCategoriesSuccessFn, getCategoriesErrorFn);

	 		function getCategoriesSuccessFn(data, status, headers, config){
	 			vm.categories = data.data
	 		}

	 		function getCategoriesErrorFn(data, status, headers, config){
	 			
	 		}

	 		Classified.getCities().then(getCitiesSuccessFn, getCitiesErrorFn);

	 		function getCitiesSuccessFn(data, status, headers, config){
	 			vm.cities = data.data;
	 		}

	 		function getCitiesErrorFn(data, status, headers, config){
	 			
	 		}
	 	}

	 }
})();