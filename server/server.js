const config = require('config');
const express = require('express');

const app = express();

const PORT = process.env.PORT || config.port;

const server = app.listen(PORT, () => {
  console.log('Express started on PORT: ', PORT);
});

require('./io').initialize(server);
require('./udp')(server);
require('./tcp').initialize(); // Instantiates and start TCP server

app.use(express.json());

app.post('/', (req, res) => {
  const socket = require('./socket').socket();
  socket.emit('rtc', req.body);
  res.status(200).end();
});
