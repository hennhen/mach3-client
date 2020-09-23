import sio, { Server, Socket } from 'socket.io';
import { getSocket, set } from './socket';

let io: Server = null;

export const getIO = () => {
  return io;
};

export const initialize = (server: any) => {
  io = sio(server);
  io.on('connection', (socket: Socket) => {
    const localSocket = getSocket();
    if (localSocket) {
      socket.on('rtc', (data: string) => {
        localSocket.emit('rtc', { data, id: socket.id });
      });
      socket.on('disconnect', () => {
        localSocket.emit('disconnect', socket.id);
      });
    } else {
      socket = set(socket);
      socket.on('rtc', (dataString: string) => {
        const { data, id } = JSON.parse(dataString);
        io.to(id).emit('rtc', data);
      });
    }
  });
  return io;
};
