const axios = require('axios');

let socket = null;

module.exports.set = (newSocket) => {
  socket = newSocket;
  socket.on('rtc', async (data) => {
    axios.post('http://654419b33480.ngrok.io/api/rtc', data);
    // TODO: Add mechanism to turn on data fetching from udp server
  });

  socket.on('close', () => {
    // TODO: Add mechanism to turn off data fetching from udp server
  });

  return socket;
};

module.exports.socket = () => {
  return socket;
};
