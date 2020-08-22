const dgram = require('dgram');
const config = require('config');

// Passed in an httpServer to be reused with socket.io
const UDP = (server) => {
  // ============= UDP setups ============
  const udpServer = dgram.createSocket('udp4');

  udpServer.on('error', (err) => {
    console.log(`server error:\n${err.stack}`);
    server.close();
  });

  udpServer.on('listening', () => {
    const address = udpServer.address();
    console.log(`UDP server listening ${address.address}:${address.port}`);
  });

  udpServer.bind(config.udpPort);

  // Emit to socket
  udpServer.on('message', (msg) => {
    const socket = require('./socket').socket();
    socket.emit('udpData', msg.toString());
  });

  // TODO: Have mach3 client emit current line of gcode
};

module.exports = UDP;
