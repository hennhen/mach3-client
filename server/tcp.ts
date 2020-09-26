import net from 'net';
import config from 'config';

export const tcp = () => {
  const handleConnection = (socket: net.Socket) => {
    const remoteAddress = socket.remoteAddress + ':' + socket.remotePort;
    console.log('TCP: new client connection from %s', remoteAddress);

    const onConnData = (d: Buffer) => {
      // TODO: Handle incoming TCP data
      console.log('TCP: connection data from %s: %j', remoteAddress, d);
      socket.write(d);
    };

    const onConnClose = () => {
      console.log('TCP: connection from %s closed', remoteAddress);
    };

    const onConnError = (err: Error) => {
      console.log('TCP: Connection %s error: %s', remoteAddress, err.message);
    };

    socket.on('data', onConnData);
    socket.once('close', onConnClose);
    socket.on('error', onConnError);
  };

  const server = net.createServer();
  server.on('connection', handleConnection);
  server.listen(config.get('tcpPort'), () => {
    console.log('TCP Server bound to port: ', config.get('tcpPort'));
  });
};

// Esbalish request,
const sendTCPPacket = (data: object, cb?: Function) => {
  console.log('sendTCPPacket(): Sending: %s', data);
  // Create new client for the outgoing request, destroy when done
  const client = new net.Socket();

  // Receive response from the Mach3 computer after sending out
  client.on('data', (data) => {
    client.destroy();
    if (cb) cb(data);
  });

  client.setTimeout(3000, () => {
    console.log(
      'TCP Send Auth Request: Connection Timeout. Check if the target Endpoing is correct'
    );
    client.destroy();
  });

  client.on('close', () => {
    console.log('Connection Closed');
  });

  try {
    client.connect(config.get('mach3Port'), '192.168.0.193', () => {
      console.log(`TCP Auth Request: Connected to Mach3`);
      client.write(JSON.stringify(data));
    });
  } catch (e) {
    console.log(e);
    console.log('Probably wrong endpoint or endpoint is incorrect');
    client.destroy();
  }
};

export const sendAuthRequest = (cb?: Function) => {
  const data = {
    type: 'auth_request',
    auth_password: '123',
    auth_udp_port: config.get('udpPort')
  };
  sendTCPPacket(data, cb);
};

export const sendDisconnectRequest = (cb?: Function) => {
  const data = { type: 'disconnect_request' };
  sendTCPPacket(data, cb);
};

export const sendCommand = (data: object, cb?: Function) => {
  data = { ...data, type: 'mach3_command' };
  sendTCPPacket(data, cb);
};
