import { Socket } from 'socket.io';
import { getIO } from './io';

let socket: Socket = null;

export const set = (newSocket: Socket) => {
  socket = newSocket;

  socket.on('close', () => {
    // TODO: Add mechanism to turn off data fetching from udp server
  });

  socket.on('rtc', (dataString: string) => {
    const { data, id } = JSON.parse(dataString);
    getIO().sockets.sockets[id].emit('rtc', data);
  });

  return socket;
};

export const getSocket = () => {
  return socket;
};
