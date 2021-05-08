var http = require("http");

const sleep = (time) =>
	new Promise((resolve) => {
		setTimeout(resolve, time);
	});

const handle = async (res) => {
	res.writeHead(206, {
		"Content-Type": "application/json",
	});

	res.write("[");

	for (let i = 0; i <= 5; i++) {
		res.write(JSON.stringify({ item: i }) + (i !== 5 ? "," : ""));

		await sleep(1000);
	}

	res.write("]");
	res.end();
};

const PORT = 5000;
http.createServer(function (req, res) {
	handle(res);
}).listen(PORT, () => {
	console.log(`Listening on PORT: ${PORT}`);
});
