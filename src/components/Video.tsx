import React from 'react';

const Video = React.forwardRef<HTMLVideoElement, {}>((props, ref) => {
  return <video ref={ref} playsInline autoPlay />;
});

Video.displayName = 'Video';

export { Video };
