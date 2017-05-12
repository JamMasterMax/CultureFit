var cultureFit = cultureFit || {};

cultureFit.submissions = cultureFit.submissions || {};

cultureFit.submissions.getAll = function (data, onSuccess, onError) {
	var url = "/api/submissions";
	var settings = {
		cache: false,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		datatype: "json",
		success: onSuccess,
		error: onError,
		type: "GET"
	};
	$.ajax(url, settings);
};

cultureFit.submissions.selectById = function (id, onSuccess, onError) {
    var url = "/api/submissions/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };
    $.ajax(url, settings);
};

cultureFit.submissions.selectByListingId = function (id, onSuccess, onError) {
    var url = "/api/submissions/applicants/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };
    $.ajax(url, settings);
};

cultureFit.submissions.getApplicantById = function(id, onSuccess, onError) {
    var url = "/api/submissions/applicant/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };
    $.ajax(url, settings);

};