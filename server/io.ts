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
    const localSocket = getSocket();
    if (localSocket) {
      const clients = Object.keys(io.sockets.sockets);
      if (clients.length === 2) sendAuthRequest();
      console.log('client socket connected');
      socket.on('rtc', (signal: string) => {
        localSocket.emit('rtc', { signal, id: socket.id });
      });
      socket.on('disconnect', () => {
        const updatedClients = Object.keys(io.sockets.sockets);
        if (updatedClients.length === 2) sendDisconnectRequest();
        console.log('client socket disconnected');
      });
    } else {
      console.log('local socket connected');
      socket = set(socket);
    }
  });
  return io;
};
