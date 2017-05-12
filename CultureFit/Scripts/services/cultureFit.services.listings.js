var cultureFit = cultureFit || {};

cultureFit.listings = cultureFit.listings || {};

cultureFit.listings.getAll = function (onSuccess, onError) {
	var url = "/api/listings";
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