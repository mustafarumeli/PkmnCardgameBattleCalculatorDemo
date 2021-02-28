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
app.get('/card-image-generator', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/cardgenerator/cardgenerator.html'));
});
app.get('/battle-calculator', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/battle-calculator/battle-calculator.html'));
});

// const BASEURL = "http://bapi:80";
const BASEURL = 'https://localhost:5001';

app.get('/cards', function (req, res) {
	fetch('/').then(data);
});

app.post('/saveCard', function (req, res) {
	var data = req.body.card;
	var card = {
		CardId: data.id,
		CardImage: data.image,
		Artwork: data.artwork,
	};
	var config = {
		method: 'post',
		url: BASEURL + '/api/Gui/SaveImage',
		headers: {
			'Content-Type': 'application/json',
		},
		data: card,
	};
	axiosFacade(config);
	res.sendStatus(200);
});

app.post('/GetCards', function (req, res) {
	axiosFacade
		.get(BASEURL + '/api/Gui/GetAllCards')
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
