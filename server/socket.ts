import { Socket } from 'socket.io';
import { getIO } from './io';

let socket: Socket | undefined = undefined;

export const set = (newSocket: Socket) => {
  socket = newSocket;

  socket.on('disconnect', () => {
    console.log('local socket disconnected');
    socket = undefined;
  });

  socket.on('rtc', (data: { signal: string; id: string }) => {
    const { signal, id } = data;
    const io = getIO();
    if (io) io.to(id).emit('rtc', signal);
  });

  socket.on('disconnect', () => {
    const io = getIO();
    if (io) {
      Object.values(io.of('/').connected).forEach((s) => {
        s.disconnect(true);
      });
    }
  });

  return socket;
};

export const getSocket = () => {
  return socket;
};
