const axios = require('axios');

let socket = null;

module.exports.set = (newSocket) => {
  socket = newSocket;
  socket.on('rtc', async (data) => {
    axios.post('http://localhost:3333/api/rtc', data);
  });
  return socket;
};

module.exports.socket = () => {
  return socket;
};
