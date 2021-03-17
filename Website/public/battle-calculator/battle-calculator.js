$('#btnCalculate').on('click', () => {
	var battleSides = {
		AttackerId: $('#attackerSelect').val(),
		DefenderId: $('#defenderSelect').val(),
	};
	$.ajax({
		url: '/battle',
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		data: JSON.stringify({ battleSides }),
		dataType: 'json',
		error: function (m) {
			console.log(m.responseText);
		},
		success: function (data) {
			console.log(data);
		},
	});
});
$().ready(getCards);
function getCards() {
	$.ajax({
		url: '/GetCards',
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		dataType: 'json',
		error: function (m) {
			console.log(m.responseText);
		},
		success: function (data) {
			var localData = [];
			if (data) {
				data.forEach((element) => {
					localData.push({
						name: element.name,
						id: element.id,
						atk: element.atk,
						def: element.def,
						hp: element.hp,
					});
					$('#attackerSelect').append(`<option value='${element.id}'>${element.name}</option>`);
					$('#defenderSelect').append(`<option value='${element.id}'>${element.name}</option>`);
				});
				localStorage.setItem('data', JSON.stringify(localData));
			}
		},
	});
}

function setAttacker() {
	var localData = JSON.parse(localStorage.getItem('data'));
	var selectedCard = localData.filter((item) => item.id == $('#attackerSelect').val())[0];
	if (selectedCard) {
		$('#attackerAttack').val(selectedCard.atk);
		$('#attackerDef').val(selectedCard.def);
		$('#attackerHp').val(selectedCard.hp);
	}
}
function setDefender() {
	var localData = JSON.parse(localStorage.getItem('data'));
	var selectedCard = localData.filter((item) => item.id == $('#defenderSelect').val())[0];
	if (selectedCard) {
		$('#defenderAttack').val(selectedCard.atk);
		$('#defenderDef').val(selectedCard.def);
		$('#defenderHp').val(selectedCard.hp);
	}
}
