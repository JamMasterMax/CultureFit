(function () {
    var myApp = angular.module('myApp', []);

    myApp.controller('dashboardController', function ($scope, $http, $compile) {

        var vm = this;

        vm.listingHeader = '___';
        vm.applicantHeader = '___';
        vm.reviewPercent = 0;

        vm.listings = [];
        vm.submissions = [];
        vm.reviews = [];
        vm.switchApplicant = _switchApplicant;
        vm.setLike = _setLike;
        vm.setDislike = _setDislike;
        vm.submitReview = _submitReview;
        vm.displayApplicant;
        vm.applicants = [];
        vm.likeFlag;
        vm.employee;
        vm.comment;

        UpdateListings = function (response) {
            vm.listings = response.Items;
            $scope.$apply();
        }

        vm.GetSubmissionsByListingID = function (listing, e) {
            // update column headers
            vm.listingHeader = e.target.text;
            vm.applicantHeader = '___';
            $('.listingLink').removeClass('active');
            $(e.target).addClass('active');

            cultureFit.submissions.selectByListingId(listing.ListingID, _onGetSubmissionSuccess, _onGetSubmissionError);
        }

        function _onGetSubmissionSuccess(data) {
            vm.applicants = [];
            vm.displayApplicant = null;
            console.log(data.Items);
            var applicantsRawData = data.Items;
            var listingTable = {};
            var likes = 0;

            if (applicantsRawData) {
                for (var i = 0; i < applicantsRawData.length; i++) {
                    var key = applicantsRawData[i].UserId;
                    listingTable[key] = applicantsRawData[i];
                    listingTable[key].likes = 0;
                    listingTable[key].numOfReviews = 0;
                };

                for (var i = 0; i < applicantsRawData.length; i++) {
                    var key = applicantsRawData[i].UserId;
                    if (listingTable[key].UserId === applicantsRawData[i].UserId) {
                        listingTable[key].numOfReviews = listingTable[key].numOfReviews + 1;
                        if (applicantsRawData[i].Rating === 1) {
                            listingTable[key].likes = listingTable[key].likes + 1;
                        };
                    };
                };

                var keys = _findUniqueKeys(listingTable);

                for (var i = 0; i < keys.length; i++) {
                    var percent = listingTable[keys[i]].likes / listingTable[keys[i]].numOfReviews;
                    listingTable[keys[i]].percent = Math.round(percent * 5);
                    vm.applicants.push(listingTable[keys[i]]);
                };
            }

            _apply();

            // update star ratings
            $('.stars').stars();
        };

        function _findUniqueKeys(table) {
            var keys = [];
            for (var key in table) {
                keys.push(key);
            };
            return keys;
        };

        function _apply() {
            $scope.$apply();
        };

        function _onGetSubmissionError(data) {
            console.log(data);
        };

        function _switchApplicant(applicant, e) {
            vm.applicantHeader = applicant.FirstName + ' ' + applicant.LastName;
            vm.reviewPercent = applicant.percent;
            $('.applicantContainer').removeClass('active');
            var div = null;
            if (e.target.element = 'div')
                div = $(e.target)
            else
                div = $(e.target).parent('div');
            div.addClass('active');            

            vm.displayApplicant = null;
            vm.displayApplicant = applicant;

            var stars = div.find('.stars').clone();
            $('#reviewScore').html(stars);
        };

        function _setLike() {
            vm.likeFlag = true;
        };

        function _setDislike() {
            vm.likeFlag = false;
        };

        function _submitReview() {
            vm.applicantReview = {
                "SubmissionID": vm.displayApplicant.SubmissionId,
                "Comment": vm.comment,
                "Employee": vm.employee,
                "DepartmentId": 1,
            };

            if (vm.likeFlag) {
                vm.applicantReview.Rating = 1;
            } else {
                vm.applicantReview.Rating = 0;
            };

            cultureFit.reviews.Create(vm.applicantReview, _onReviewCreateSuccess, _onReviewCreateError);

        };

        function _onReviewCreateSuccess(data) {
            console.log(data);
        };

        function _onReviewCreateError(data) {
            console.log(data);
        };

        cultureFit.listings.getAll(UpdateListings, Error);

    })
})();

$.fn.stars = function () {
    return $(this).each(function () {
        var rating = $(this).data("rating");
        var numStars = $(this).data("numStars");
        var fullStar = new Array(Math.floor(rating + 1)).join('<i class="fa fa-star"></i>');
        var halfStar = ((rating % 1) !== 0) ? '<i class="fa fa-star-half-empty"></i>' : '';
        var noStar = new Array(Math.floor(numStars + 1 - rating)).join('<i class="fa fa-star-o"></i>');
        $(this).html(fullStar + halfStar + noStar);
    });
}