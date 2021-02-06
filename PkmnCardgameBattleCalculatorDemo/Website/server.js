//#region using
var express = require('express');
var app = express();
var path = require('path');
const bodyParser = require('body-parser');
var axios = require('axios');
const https = require('https');
const axiosFacade = axios.create({
	httpsAgent: new https.Agent({
		rejectUnauthorized: false,
	}),
});
//#endregion
//#region app use
app.use(bodyParser.json({ limit: '50mb' }));
app.use(bodyParser.raw({ limit: '50mb' }));
app.use(express.static('public'));
app.use(express.static('public/cardgenerator'));
app.use(express.static('public/battle-calculator'));
//#endregion
app.get('/', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/default.html'));
});
app.get('/card-generator', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/cardgenerator/cardgenerator.html'));
});
app.get('/battle-calculator', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/battle-calculator/battle-calculator.html'));
});



app.get('/cards', function (req, res) {
	fetch('/').then(data);
});

app.post('/saveCard', function (req, res) {
	var data = req.body.card;
	var imgSrc = __dirname + '/public/generatedCardImages/' + data.name + '.png';
	require('fs').writeFile(imgSrc, data.image.replace(/^data:image\/png;base64,/, ''), 'base64', function (err) {
		console.log(err);
	});
	var card = {
		Name: data.name,
		Atk: data.str,
		Def: data.def,
		Hp: data.hp,
		Description: data.desc,
		Image: data.name + '.png',
		Attributes: data.attr,
		Types: data.types,
	};
	var config = {
		method: 'post',
		url: 'https://localhost:5001/api/Gui/SaveCard',
		headers: {
			'Content-Type': 'application/json',
		},
		data: card,
	};
	console.log(JSON.stringify(card));
	axiosFacade(config);
	res.sendStatus(200);
});

app.post('/GetCardAttributes', function (req, res) {
	axiosFacade
		.get('https://localhost:5001/api/Gui/GetCardAttributes')
		.then((response) => {
			res.send(response.data);
		})
		.catch((err) => {
			res.send(err);
		});
});

app.post('/GetCardTypes', function (req, res) {
	axiosFacade
		.get('https://localhost:5001/api/Gui/GetCardTypes')
		.then((response) => {
			res.send(response.data);
		})
		.catch((err) => {
			res.send(err);
		});
});


app.post('/GetCards', function (req, res) {
	axiosFacade
		.get('https://localhost:5001/api/Gui/GetCards')
		.then((response) => {
			res.send(response.data);
		})
		.catch((err) => {
			res.send(err);
		});
});


app.listen(3230, function () {
	console.log('Example app listening on port 3230!');
});