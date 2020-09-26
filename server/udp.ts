import dgram from 'dgram';
import config from 'config';
import { getSocket } from './socket';

// Passed in an httpServer to be reused with socket.io
export const udp = (server: any) => {
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

  udpServer.bind(config.get('udpPort'));

  // Emit to socket
  udpServer.on('message', (msg) => {
    const socket = getSocket();
    if (socket) socket.emit('data', msg.toString());
  });

  // TODO: Have mach3 client emit current line of gcode
};
