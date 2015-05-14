(function(){
	'use strict';

	angular.module('comments.controllers.CommentsController')
	 .controller('CommentsController', CommentsController);

	 CommentsController.$inject = ['$scope', '$http', 'Comments'];

	 function CommentsController($scope, $http, Comments){
	 	var vm = this;
	 	var classified_ad_id;
	 	vm.init = init;
	 	vm.submit = submit;

	 	

	 	function activate(){
	 		console.log('activate');	
	 	

	 		Comments.GetComments(classified_ad_id).then(GetCommentsSuccessFn, GetCommentsErrorFn);

	 		function GetCommentsSuccessFn(data, status, headers, config){
	 			vm.comments= data.data;
	 		}

	 		function GetCommentsErrorFn(data, status, headers, config){
	 			console.log("ERRRROR");
	 		}
	 	}


	 	function init(ad_id){
	 		classified_ad_id = ad_id;
	 		console.log(ad_id)
	 		activate();
	 	}

	 	function submit(classified_ad_id) {
            console.log(vm.comment)
	 		Comments.PostComment(classified_ad_id, vm.comment).then(PostCommentSuccessFn, PostCommentErrorFn);

	 		function PostCommentSuccessFn(data, status, headers, config){
	 		    activate();
	 			vm.comment="";
	 		}

	 		function PostCommentErrorFn(data, status, headers, config){
	 			console.log("ERRRROR GETTING COMMENTS");
	 		}
	 	}
	 	

	 	
	 }
})();