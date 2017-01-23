$(document).ready(function () {

	$body = $('body');

	function loadPersons(search, e) {

		$.ajax(
		   {
		   	url: '/Home/SearchByName',
		   	type: 'GET',
		   	data: search,
		   	contentType: 'application/json',
		   	success: function (result) {

		   		$("#tblResults tbody").remove();

		   		if (result.length === 0) {
		   			$('#tblResults').hide();
		   			$('#searchError').show();
		   		}
		   		else {
		   			$('#searchError').hide();
		   			$('#tblResults').show()
		   			.append(
					$.map(result, function (person, index) {
						var imageString = result[index].Picture;

						var elem = document.createElement("img");
						elem.setAttribute("src", "data:image/jpeg;base64," + imageString);


						return '<tr><td style="width:10%; padding:5px">' + '<img src="' + elem.getAttribute("src") + '" class="personPic" >'
							+ '</td><td style="width:10%">' + result[index].FirstName
							+ '</td><td style="width:10%">' + result[index].LastName
							+ '</td><td style="width:10%">' + result[index].Age
							+ '</td><td style="width:10%">' + result[index].Address1
							+ '</td><td style="width:10%">' + result[index].Address2
							+ '</td><td style="width:10%">' + result[index].City
							+ '</td><td style="width:10%; text-align:center">' + result[index].State
							+ '</td><td style="width:10%">' + result[index].Zipcode
							+ '</td><td style="width:10%">' + result[index].Intrests
							+ "</td></tr>";
					}).join());
		   		}

		   	}
		   });

		e.preventDefault();
	};

	$(document).keypress(function (e) {
		if (e.which == 13) {
			$('#performSearch').click();
		}
	});

	$('#performSearch').on('click', (function (e) {
		var search = {
			'search': $('#search').val()
		};
		loadPersons(search, e);

	}));

	$('#performSearchLong').on('click', (function (e) {
		var search = {
			'search': $('#search').val(),
			'threadSleep':5
		};

		loadPersons(search, e);

	}));

	

	$('#performSearch').click();

	$(document).on({
		ajaxStart: function () { $body.addClass("loading"); },
		ajaxStop: function () { $body.removeClass("loading"); }
	});
});