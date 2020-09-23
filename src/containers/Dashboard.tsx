import React, { useRef, useEffect } from 'react';
import { Container, Grid } from '@material-ui/core';
import io from 'socket.io-client';
import Peer, { Instance } from 'simple-peer';
import { Video } from '../components';

const Dashboard = () => {
  const videoOne = useRef<HTMLVideoElement>(null);
  const videoTwo = useRef<HTMLVideoElement>(null);
  const socket = useRef<any>(null);
  const peers = useRef<{ [id: string]: Instance }>({});

  const buildPeer = (id: string) => {
    const peer = new Peer({
      initiator: false
    });

    if (videoOne.current)
      peer.addStream(videoOne.current.srcObject as MediaStream);

    if (videoTwo.current)
      peer.addStream(videoTwo.current.srcObject as MediaStream);

    peer.on('signal', (signal) => {
      socket.current.emit('rtc', { signal, id });
    });

    peer.on('error', (error) => {
      console.error(error);
    });

    peer.on('close', () => {
      console.log('peer closed');
      const newPeers = { ...peers.current };
      delete newPeers[id];
      peers.current = newPeers;
    });

    peer.on('connect', () => {
      console.log('peer connected');
    });

    return peer;
  };

  useEffect(() => {
    const connectVideo = async () => {
      if (!videoOne.current || !videoTwo.current) return;

      await navigator.mediaDevices.getUserMedia({ audio: true, video: true });

      const deviceIDs: string[] = [];

      const devices = await navigator.mediaDevices.enumerateDevices();

      devices.forEach((device) =>
        device.kind === 'videoinput' ? deviceIDs.push(device.deviceId) : null
      );

      for (let idx = 0; idx < deviceIDs.length; idx++) {
        const id = deviceIDs[idx];

        const stream = await navigator.mediaDevices.getUserMedia({
          video: {
            deviceId: { exact: id }
          },
          audio: idx === 0
        });
        if (idx === 0) videoOne.current.srcObject = stream;
        else if (idx === 1) videoTwo.current.srcObject = stream;
      }
    };

    connectVideo();
  }, [videoOne, videoTwo]);

  useEffect(() => {
    const socketConnect = async () => {
      socket.current = await io('http://localhost:5000');
      socket.current.on('connect', () => {
        console.log('CONNECTED');
      });
      socket.current.on('rtc', (dataString: string) => {
        const { id, signal } = JSON.parse(dataString);
        let peer: Instance;
        if (!peers.current[id]) {
          peer = buildPeer(id);
          const newPeers = { ...peers.current, id: peer };
          peers.current = newPeers;
        } else peer = peers.current[id];
        peer.signal(signal);
      });
    };

    socketConnect();
  }, []);

  return (
    <Container>
      <Grid container spacing={3}>
        <Grid item xs={6}>
          <Video ref={videoOne} />
        </Grid>
        <Grid item xs={6}>
          <Video ref={videoTwo} />
        </Grid>
      </Grid>
    </Container>
  );
};

export { Dashboard };
