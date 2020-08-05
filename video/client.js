import Peer from 'simple-peer';
import io from 'socket.io-client';

let socket;

class WebRTC {
  constructor() {
    this.peer = this.buildPeer();
  }

  buildPeer = () => {
    const peer = new Peer({
      initiator: false
    });

    peer.on('signal', (data) => {
      socket.emit('video', {
        signal: data,
        socketID: document.getElementById('socketID').innerText
      });
    });

    peer.on('error', (error) => {
      console.error(error);
    });

    peer.on('close', () => {
      console.log('peer closed');
      this.peer = this.buildPeer();
      this.peer.addStream(document.getElementById('video1').srcObject);
      this.peer.addStream(document.getElementById('video2').srcObject);
    });

    return peer;
  };
}

const webRTC = new WebRTC();

const connectVideo = async () => {
  const deviceIDs = [];

  const devices = await navigator.mediaDevices.enumerateDevices();

  devices.forEach((device) =>
    device.kind === 'videoinput' ? deviceIDs.push(device.deviceId) : null
  );

  deviceIDs.forEach(async (id, idx) => {
    const stream = await navigator.mediaDevices.getUserMedia({
      video: {
        deviceId: { exact: id }
      }
    });
    document.getElementById(`video${idx + 1}`).srcObject = stream;
    webRTC.peer.addStream(stream);
  });
};

const socketConnect = async () => {
  socket = await io('localhost:4000');

  socket.on('connect', () => {
    console.log('CONNECTED');
  });

  socket.on('video', ({ signal, socketID }) => {
    document.getElementById('socketID').innerText = socketID;
    webRTC.peer.signal(signal);
  });
};

connectVideo();
socketConnect();
