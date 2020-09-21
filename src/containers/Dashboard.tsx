import React, { useRef, useEffect } from 'react';
import { Container, Grid } from '@material-ui/core';
import { Video } from '../components';

const Dashboard = () => {
  const videoOne = useRef<HTMLVideoElement>(null);
  const videoTwo = useRef<HTMLVideoElement>(null);

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
