import Peer from 'simple-peer';
import io from 'socket.io-client';

let socket;

const connectVideo = async () => {
  const stream = await navigator.mediaDevices.getUserMedia({
    video: true
  });

  document.getElementById('video').srcObject = stream;
};

const socketConnect = async () => {
  socket = await io('0.0.0.0:4000');

  socket.on('connect', () => {
    console.log('CONNECTED');
  });

  socket.on('video', ({ signal, socketID }) => {
    const peer = new Peer({
      initiator: false,
      stream: document.getElementById('video').srcObject
    });
    peer.on('signal', (data) => {
      socket.emit('video', { signal: data, socketID: socketID });
    });

    peer.on('error', (error) => {
      console.error(error);
      peer.destroy();
    });

    peer.signal(signal);
  });
};

connectVideo();
socketConnect();
