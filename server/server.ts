import express from 'express';

import { initialize } from './io';

const app = express();

const PORT = process.env.PORT || 5000;

const server = app.listen(PORT, () => {
  console.log('Express started on PORT: ', PORT);
});

initialize(server);
// require('./udp')(server);
// require('./tcp').initialize(); // Instantiates and start TCP server

app.use(express.json());
