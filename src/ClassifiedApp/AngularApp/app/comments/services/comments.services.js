 // /classified_ads/:classified_ad_id/comments
 (function(){
	'use strict';
	angular.module('comments.services.CommentsService')
		.factory('Comments', Comments);

		Comments.$inject = ['$http'];

		function Comments($http){

			var Comments = {
				PostComment: PostComment,
				GetComments: GetComments
			}

			return Comments;

			function PostComment(classified_ad_id, comment){
				return $http.post('/ClassifiedAd/'+classified_ad_id+'/Comments',{
					comment: {
						content: comment,
						classifiedAdId: classified_ad_id
					} 
				});
			}

			function GetComments(classified_ad_id){
			    return $http.get('/ClassifiedAd/' + classified_ad_id + '/Comments');
			}
			
		}
})();