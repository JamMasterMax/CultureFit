var cultureFit = cultureFit || {};

cultureFit.reviews = cultureFit.reviews || {};

cultureFit.reviews.Create = function (data, onSuccess, onError) {
    var url = "/api/reviews";
	var settings = {
		cache: false,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		datatype: "json",
		data: data,
		success: onSuccess,
		error: onError,
		type: "POST"
	};
	$.ajax(url, settings);
};