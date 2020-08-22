const sio = require('socket.io');

let io = null;

module.exports.io = () => {
  return io;
};

module.exports.initialize = (server) => {
  io = sio(server);
  io.on('connection', (socket) => {
    socket = require('./socket').set(socket);
  });
  return io;
};
