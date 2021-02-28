function GetCards() {
	$.ajax({
		url: '/GetCards',
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		dataType: 'json',
		error: function (m) {
			console.log(m.responseText);
		},
		success: function (data) {
			if (data) {
				data.forEach((element) => {
					var template = $('.template').html();
					var cardTypes = `<img src='${element.mainCardType}' />`;
					if (element.secondaryCardType != null) cardTypes += `<img src='${element.secondaryCardType}' />`;
					template = template.replaceAll('{card-name}', element.name);
					template = template.replace('{card-attack}', element.atk);
					template = template.replace('{card-health}', element.hp);
					template = template.replace('{card-defence}', element.def);
					template = template.replace('{card-desc}', element.description);
					template = template.replace('{card-id}', element.id);
					if (element.artwork) template = template.replace('{card-image}', element.artwork);
					template = template.replace('{card-types}', cardTypes);
					$('#container').append(template);
				});
			}
		},
	});
}
let card = {};
function changeArtwork(e, id, name) {
	card.id = id;
	card.name = name;
	card.e = e;
	$('#cardImage').click();
}
function sendImage(name) {
	html2canvas(document.getElementById(name)).then((canvas) => {
		var data = canvas.toDataURL('image/png');
		card.image = data;
		console.log(card);
		$.ajax({
			url: '/saveCard',
			type: 'POST',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify({ card }),
			dataType: 'json',
			error: function (m) {
				console.log(m.responseText);
			},
			success: function (data) {},
		});
	});
}
$().ready(GetCards);

function onFileSelected(event) {
	var selectedFile = event.target.files[0];
	var reader = new FileReader();
	reader.onload = function (event) {
		card.artwork = event.target.result;
		$(card.e).attr('src', card.artwork);
		sendImage(card.name);
	};
	reader.readAsDataURL(selectedFile);
}
