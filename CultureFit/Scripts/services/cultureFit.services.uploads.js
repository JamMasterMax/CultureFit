
var cultureFit = cultureFit || {};

cultureFit.uploads = cultureFit.uploads || {};

cultureFit.uploads.create = function (file, onSuccess, onError) {
    var formData = new FormData();
    formData.append('file', file);

    var url = '/api/upload';
    var settings = {
        cache: false,
        data: formData,
        processData: false,
        contentType: false,
        success: onSuccess,
        error: onError,
        type: 'POST'
    };

    $.ajax(url, settings);
};

