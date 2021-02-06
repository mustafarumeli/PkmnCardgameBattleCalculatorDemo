$('#btnGenerate').on('click', () => {
	var name = $('#cname').val();
	var cardAttack = $('#cardAttack').val();
	var cardDef = $('#cardDef').val();
	var cardHp = $('#cardHp').val();
	var cardDesc = $('#cardDesc').val();
	var template = $('.template').html();
	template = template.replaceAll('{card-name}', name);
	template = template.replace('{card-attack}', cardAttack);
	template = template.replace('{card-health}', cardHp);
	template = template.replace('{card-defence}', cardDef);
	template = template.replace('{card-desc}', cardDesc);

	$('#container').append(template);
	sendImage(name);

	card = {
		name: name,
		str: cardAttack,
		def: cardDef,
		hp: cardHp,
		desc: cardDesc,
		attr: attributes,
		types: types,
	};
});

let attributes = [];
$('#btnSaveAttribute').on('click', () => {
	var text = '';
	var attributeName = $('#cardAttributes :selected').text();
	text += attributeName;
	var AttributeValues = [];
	$('.variable').each((index, item) => {
		AttributeValues.push($(item).val());
		text += $(item).val() + ' ';
	});
	attributes.push({
		attributeName,
		AttributeValues,
	});
	$('#attributeHolder').append(`<li>${text}</li>`);
	$('#cardAttributes :selected').remove();
	$('#cardAttributeVariableContainer').html('');
});

let types = [];
$('#btnAddCardType').on('click', () => {
	var type = $('#cardTypes :selected').text();
	types.push({ TypeName: type });
	$('#typeHolder').append(`<li>${type}</li>`);
	$('#cardTypes :selected').remove();
});

let card = {};
function sendImage(name) {
	html2canvas(document.getElementById(name)).then((canvas) => {
		var data = canvas.toDataURL('image/png');
		card.image = data;
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
$().ready(getCardAttributes);
$().ready(getCardTypes);
function getCardTypes() {
	$('#cardTypes').html('');
	$.ajax({
		url: '/GetCardTypes',
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		dataType: 'json',
		error: function (m) {
			console.log(m.responseText);
		},
		success: function (data) {
			if (data) {
				var lis = '<option>None</option>';
				data.forEach((element) => {
					lis += `<option>${element.name}</option>`;
				});
				$('#cardTypes').html(lis);
			}
		},
	});
}

function getCardAttributes() {
	$('#cardAttributes').html('');
	$.ajax({
		url: '/GetCardAttributes',
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		dataType: 'json',
		error: function (m) {
			console.log(m.responseText);
		},
		success: function (data) {
			if (data) {
				var lis = '<option variableCount="0">None</option>';
				data.forEach((element) => {
					lis += `<option variableCount='${element.variableCount}'>${element.name}</option>`;
				});
				$('#cardAttributes').html(lis);
			}
		},
	});
}
function createCardVariableInputs() {
	var count = $('#cardAttributes option:selected').attr('variableCount');
	var $cardAttributeVariableContainer = $('#cardAttributeVariableContainer');
	$cardAttributeVariableContainer.html('');
	for (var i = 0; i < count; i++) {
		$cardAttributeVariableContainer.append("<input type='number' class='variable' />");
	}
}

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
					template = template.replaceAll('{card-name}', element.name);
					template = template.replace('{card-attack}', element.atk);
					template = template.replace('{card-health}', element.hp);
					template = template.replace('{card-defence}', element.def);
					template = template.replace('{card-desc}', element.description);
					$('#container').append(template);
				});
			}
		},
	});
}
