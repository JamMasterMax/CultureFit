(function () {
    'use-strict';

    angular.module("zipHackathon", [])
        .controller("listingsController", ListingsController);

    ListingsController.$inject = ["$scope"];

    function ListingsController($scope) {
        var vm = this;
        vm.scope = $scope;

        vm.submissions = [];

        vm.render = _render;
        vm.getSubmissions = _getSubmissions;



        vm.scope.$on("listingReceived", vm.getSubmissions);

        function _getSubmissions(e, data) {
            cultureFit.submissions.selectByListingId(data.Item[0], _onGetSuccess, _onGetError);
        };

        function _onGetSuccess(data) {
            vm.submissions = data.Items;
        };

        function _onGetError(data) {
            console.log(data);
        };
    };
})();