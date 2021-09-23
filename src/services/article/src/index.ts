import mongoose from 'mongoose';
import { app } from './app';

const port: number = 3000;

const start = async () => {

    if(!process.env.JWT_SECRET_KEY)
      throw new Error("Environment variable JWT_SECRET_KEY not defined!")

    try {
      await mongoose.connect('mongodb://article-mongodb-clusterip-srv:27017/article', {
        useNewUrlParser: true,
        useUnifiedTopology: true,
        useCreateIndex: true
      });
      console.log('Connected to MongoDb');
    } catch (err) {
      console.error(err);
    }
  
    app.listen(port, () => {
      console.log('Listening on port '+port);
    });
  };
  
  start();