$('#btnGenerate').on('click', () => {
	var name = $('#cname').val();
	var cardAttack = $('#cardAttack').val();
	var cardDef = $('#cardDef').val();
	var cardHp = $('#cardHp').val();
	var cardDesc = $('#cardDesc').val();
	var template = $('.template').html();
	var cardTypes = '';
	typeIconPaths.forEach((element) => {
		cardTypes += `<img src='${element}' />`;
	});
	template = template.replaceAll('{card-name}', name);
	template = template.replace('{card-attack}', cardAttack);
	template = template.replace('{card-health}', cardHp);
	template = template.replace('{card-defence}', cardDef);
	template = template.replace('{card-desc}', cardDesc);
	template = template.replace('{card-image}', imgSrc);
	template = template.replace('{card-types}', cardTypes);
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
let typeIconPaths = [];
$('#btnAddCardType').on('click', () => {
	var type = $('#cardTypes :selected').text();
	console.log(type);
	if (type.toLowerCase().indexOf('glass') > -1) typeIconPaths.push('icons/glass.png');
	if (type.toLowerCase().indexOf('rock') > -1) typeIconPaths.push('icons/rock.png');
	if (type.toLowerCase().indexOf('paper') > -1) typeIconPaths.push('icons/paper.png');
	if (type.toLowerCase().indexOf('sound') > -1) typeIconPaths.push('icons/sound.png');
	if (type.toLowerCase().indexOf('scissors') > -1) typeIconPaths.push('icons/scissors.png');

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
					$('#container').append(`<img src='generatedCardImages/${element.image}' />`);
				});
			}
		},
	});
}
let imgSrc = '';
function onFileSelected(event) {
	var selectedFile = event.target.files[0];
	var reader = new FileReader();
	var imgtag = document.getElementById('cardImage');
	reader.onload = function (event) {
		imgSrc = event.target.result;
	};

	reader.readAsDataURL(selectedFile);
}
