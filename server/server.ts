import path from 'path';
import express from 'express';
import cors from 'cors';

import { initialize } from './io';
import { udp } from './udp';
import { tcp } from './tcp';

const app = express();

const PORT = process.env.PORT || 5000;

const server = app.listen(PORT, () => {
  console.log('Express started on PORT: ', PORT);
});

initialize(server);

app.use(express.json());

app.use(cors());

udp(server);
tcp();

const publicPath = path.join(__dirname, '..', 'build');

app.use(express.static(publicPath));

app.get('*', (req, res) => {
  res.sendFile(path.join(publicPath, 'index.html'));
});
