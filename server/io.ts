import sio, { Server, Socket } from 'socket.io';
import { getSocket, set } from './socket';

let io: Server | undefined = undefined;

export const getIO = () => {
  return io;
};

export const initialize = (server: any) => {
  io = sio(server);
  io.on('connection', (socket: Socket) => {
    const localSocket = getSocket();
    if (localSocket) {
      console.log('client socket connected');
      socket.on('rtc', (signal: string) => {
        localSocket.emit('rtc', { signal, id: socket.id });
      });
    } else {
      console.log('local socket connected');
      socket = set(socket);
    }
  });
  return io;
};
