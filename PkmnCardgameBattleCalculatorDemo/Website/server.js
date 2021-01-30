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
//#endregion

app.get('/', function (req, res) {
	res.sendFile(path.join(__dirname + '/public/cardgenerator.html'));
});

app.get('/cards', function (req, res) {
	fetch('/').then(data);
});

app.post('/saveCard', function (req, res) {
	var data = req.body;
	console.log(data);
	require('fs').writeFile(
		__dirname + '/public/generatedCardImages/' + data.name + '.png',
		data.image.replace(/^data:image\/png;base64,/, ''),
		'base64',
		function (err) {
			console.log(err);
		}
	);
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

app.listen(3230, function () {
	console.log('Example app listening on port 3230!');
});
