const express = require('express');
const axios = require('axios');
const io = require('socket.io')();
const app = express();
const port = 4000;

app.use(express.json());

const httpServer = app.listen(port, () =>
  console.log(`App is listening on port ${port}`)
);

io.listen(httpServer);

let socket;

io.on('connection', (socketConnected) => {
  socket = socketConnected;
  socketConnected.on('video', async (data) => {
    axios.post('http://837ec57988b8.ngrok.io/video', data);
  });
});

app.post('/', (req, res) => {
  socket.emit('video', req.body);
  res.status(200).end();
});
