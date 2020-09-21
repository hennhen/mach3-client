let socket = null;

module.exports.set = (newSocket) => {
  socket = newSocket;

  socket.on('close', () => {
    // TODO: Add mechanism to turn off data fetching from udp server
  });

  return socket;
};

module.exports.socket = () => {
  return socket;
};
