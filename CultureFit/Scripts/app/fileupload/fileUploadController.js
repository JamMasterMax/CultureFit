(function () {
    "use strict";

    angular.module('hackathon', []).directive('fileInput', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attributes) {
                element.bind('change', function () {
                    $parse(attributes.fileInput)
                    .assign(scope, element[0].files)
                    scope.$apply()
                });
            }
        };
    }]);

    angular.module('hackathon', [])
        .controller(
            'fileUploadController',
            FileUploadController
        );

    FileUploadController.$inject = [
        '$scope',
    ];

    function FileUploadController($scope) {

        var vm = this;

        vm.scope = $scope;
        vm.scope.$on('fileUpload.change', _updateUrl);
        vm.scope.$on('fileUpload.needed', _selectOption);
        vm.scope.$on('fileUpload.mode', _initialize);

        vm.fileRadioBox = 'keep';
        vm.uploadedUrl = null;
        vm.urlNeeded = false;
        vm.mode = null;
        vm.removedPicture = false;
        vm.showSavedPicture = true;
        vm.previewButton = true;
        vm.sendFile = _sendFile;

        render();

        function render() {
            vm.scope.$emit('fileUploadMode.loaded');
        }

        function _initialize(e, mode, url, allowKeep) {
            vm.mode = mode;
            vm.allowKeep = allowKeep;
            _updateUrl(e, url);
            vm.scope.$emit('fileUpload.set', url);
        }

        function _updateUrl(e, url) {
            vm.uploadedUrl = url;
            console.log('url has been set')
            vm.urlNeeded = false;
            vm.resetPicture = true;
            if (vm.allowKeep) {
                vm.fileRadioBox = 'keep';
            } else {
                vm.fileRadioBox = "uploadNew";
            }

        }

        function _selectOption(e) {

            switch (vm.fileRadioBox) {
                case 'remove':
                    vm.uploadedUrl = null;
                    vm.scope.$emit('fileUpload.available', vm.uploadedUrl);
                    break;
                case 'uploadNew':
                    vm.urlNeeded = true;
                    (vm.files && vm.files[0])
                            ? _sendFile()
                            : vm.scope.$emit('fileUrlValidity.change');
                    break;
                default:
                    vm.scope.$emit('fileUpload.available', vm.uploadedUrl);
                    break;
            }
        }

        function _sendFile() {
            console.log('upload');
            uploads.create(vm.files[0],
                _onSuccessFileUpload,
                _onErrorFileUpload);
        }

        function _onSuccessFileUpload(uploadData) {
            vm.uploadedUrl = uploadData.items[0];
            vm.scope.$emit('fileUpload.available', vm.uploadedUrl);
            vm.notify();
        }

        function _onErrorFileUpload(jqXHR) {
            vm.notificationsService.error('There was an error uploading your file!');
            //console.log(jqXHR.responseJSON);
            vm.scope.$emit('fileUpload.error');
        }

       

    }

})();