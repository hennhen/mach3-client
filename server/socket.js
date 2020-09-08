const axios = require('axios');

let socket = null;

module.exports.set = (newSocket) => {
  let interval;
  socket = newSocket;
  socket.on('rtc', async (data) => {
    axios.post('http://localhost:3333/api/rtc', data);
    // Fetch data from UDP Server and pass it on to socket
    interval = setInterval(() => {
      socket.emit('data', {
        x: Math.random() * 10,
        y: Math.random() * 10,
        z: Math.random() * 10,
        a: Math.random() * 10,
        c: Math.random() * 10
      });
    }, 1000);
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
