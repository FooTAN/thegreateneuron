import { app } from './app';

const port:string = process.env.RUNTIME_ENVIRONMENT == "development"? process.env.PORT : "80";

const start = async () => {  
    app.listen(port, () => {
      console.log('Listening on port '+port);
    });
  };
  
  start();