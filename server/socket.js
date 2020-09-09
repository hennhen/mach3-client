const axios = require('axios');

let socket = null;

module.exports.set = (newSocket) => {
  let interval;
  socket = newSocket;
  socket.on('rtc', async (data) => {
    axios.post('http://localhost:3333/api/rtc', data);
    // Fetch data from UDP Server and pass it on to socket
  });

  socket.on('close', () => {
    // Stop fetching data from UDP Server
    clearInterval(interval);
  });

  return socket;
};

module.exports.socket = () => {
  return socket;
};
