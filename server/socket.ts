import { Socket } from 'socket.io';
import { getIO } from './io';

let socket: Socket | undefined = undefined;

export const set = (newSocket: Socket) => {
  socket = newSocket;

  socket.on('close', () => {
    // TODO: Add mechanism to turn off data fetching from udp server
  });

  socket.on('rtc', (dataString: string) => {
    const { signal, id } = JSON.parse(dataString);
    getIO().to(id).emit('rtc', signal);
  });

  return socket;
};

export const getSocket = () => {
  return socket;
};
