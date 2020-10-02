import sio, { Server, Socket } from 'socket.io';
import { getSocket, set } from './socket';
import { sendAuthRequest, sendDisconnectRequest } from './tcp';

let io: Server | undefined = undefined;

export const getIO = () => {
  return io;
};

export const initialize = (server: any) => {
  io = sio(server);
  io.on('connection', (socket: Socket) => {
    if (!io) return;
    const localSocket = getSocket();
    const address = socket.handshake.address;
    console.log(`New socket from ${address}`)
    if (localSocket) {
      const nClients = Object.keys(io.sockets.sockets).length - 1;
      if (nClients === 1) sendAuthRequest();
      console.log('client socket connected');
      socket.on('rtc', (signal: string) => {
        localSocket.emit('rtc', { signal, id: socket.id });
      });
      socket.on('disconnect', () => {
        if (!io) return;
        const nClients = Object.keys(io.sockets.sockets).length - 1;
        if (nClients === 1) sendDisconnectRequest();
        console.log('client socket disconnected');
      });
    } else if (address === '::1') {
      console.log('local socket connected');
      socket = set(socket);
    } else {
      socket.disconnect(true);
    }
  });
  return io;
};
