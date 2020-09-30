import React, { useRef, useEffect, useState } from 'react';
import { Container, Grid, Button } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import { green, red } from '@material-ui/core/colors';
import io from 'socket.io-client';
import Peer, { Instance } from 'simple-peer';
import { Video } from '../components';

const GreenButton = withStyles((theme) => ({
  root: {
    color: theme.palette.getContrastText(green[700]),
    backgroundColor: green[700],
    '&:hover': {
      backgroundColor: green[900]
    }
  }
}))(Button);

const RedButton = withStyles((theme) => ({
  root: {
    color: theme.palette.getContrastText(red[700]),
    backgroundColor: red[700],
    '&:hover': {
      backgroundColor: red[900]
    }
  }
}))(Button);

const Dashboard = () => {
  const [recording, setRecording] = useState<boolean>(false);
  const [blobOne, setBlobOne] = useState<Blob[]>([]);
  const [blobTwo, setBlobTwo] = useState<Blob[]>([]);

  const videoOne = useRef<HTMLVideoElement>(null);
  const videoTwo = useRef<HTMLVideoElement>(null);
  const mediaRecordingOne = useRef<MediaRecorder>(null);
  const mediaRecordingTwo = useRef<MediaRecorder>(null);
  const socket = useRef<any>(null);
  const peers = useRef<{ [id: string]: Instance }>({});

  const buildPeer = (id: string) => {
    const streams: MediaStream[] = [];

    if (videoOne.current)
      streams.push(videoOne.current.srcObject as MediaStream);

    if (videoTwo.current)
      streams.push(videoTwo.current.srcObject as MediaStream);

    const peer = new Peer({
      initiator: false,
      //@ts-ignore
      streams: streams
    });

    peer.on('signal', (signal) => {
      socket.current.emit('rtc', { signal, id });
    });

    peer.on('error', (error: any) => {
      console.error(error.code);
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

      await navigator.mediaDevices.getUserMedia({
        audio: true,
        video: true
      });

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

        const mediaRecorder = new MediaRecorder(stream, {
          mimeType: 'video/webm'
        });

        let setBlob: React.Dispatch<React.SetStateAction<Blob[]>>;

        if (idx === 0) {
          videoOne.current.srcObject = stream;
          //@ts-ignore
          mediaRecordingOne.current = mediaRecorder;
          setBlob = setBlobOne;
        } else if (idx === 1) {
          videoTwo.current.srcObject = stream;
          //@ts-ignore
          mediaRecordingTwo.current = mediaRecorder;
          setBlob = setBlobTwo;
        }

        // eslint-disable-next-line no-loop-func
        mediaRecorder.ondataavailable = (event: BlobEvent) => {
          const { data: newBlob } = event;
          if (newBlob.size > 0) {
            setBlob((prevBlob: Blob[]) => {
              const newBlobArray = [...prevBlob];
              newBlobArray.push(newBlob);
              return newBlobArray;
            });
          }
        };
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
      socket.current.on('rtc', (data: { signal: string; id: string }) => {
        const { id, signal } = data;
        let peer: Instance;
        if (!peers.current[id]) {
          console.log(id);
          peer = buildPeer(id);
          const newPeers = { ...peers.current };
          newPeers[id] = peer;
          peers.current = newPeers;
        } else peer = peers.current[id];
        peer.signal(signal);
      });
      socket.current.on('data', (data: string) => {
        for (const id in peers.current) {
          const peer = peers.current[id];
          peer.send(data);
        }
      });
    };

    socketConnect();
  }, []);

  const download = (chunks: Blob[]) => {
    const blob = new Blob(chunks, {
      type: 'video/mp4'
    });
    var url = URL.createObjectURL(blob);
    var a = document.createElement('a');
    document.body.appendChild(a);
    a.style.display = 'none';
    a.href = url;
    a.download = 'cameraOneVideo.mp4';
    a.click();
    window.URL.revokeObjectURL(url);
    a.remove();
  };

  const startRecording = () => {
    setRecording(true);
    if (mediaRecordingOne.current) mediaRecordingOne.current.start();

    if (mediaRecordingTwo.current) mediaRecordingTwo.current.start();
  };

  const stopRecording = () => {
    setRecording(false);
    if (mediaRecordingOne.current) mediaRecordingOne.current.stop();
    if (mediaRecordingTwo.current) mediaRecordingTwo.current.stop();
  };

  const buttonNode = recording ? (
    <RedButton onClick={stopRecording}>Stop Recording</RedButton>
  ) : (
    <GreenButton onClick={startRecording}>Start Recording</GreenButton>
  );

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
      {buttonNode}
      <br />
      <br />
      <Button
        variant='contained'
        color='primary'
        onClick={() => {
          download(blobOne);
        }}
        disabled={blobOne.length === 0}
      >
        Download Video One
      </Button>
      <br />
      <br />
      <Button
        variant='contained'
        color='primary'
        onClick={() => {
          download(blobTwo);
        }}
        disabled={blobTwo.length === 0}
      >
        Download Video Two
      </Button>
      <br />
      <br />
      <RedButton
        onClick={() => {
          setBlobOne([]);
          setBlobTwo([]);
        }}
      >
        Clear Video
      </RedButton>
    </Container>
  );
};

export { Dashboard };
