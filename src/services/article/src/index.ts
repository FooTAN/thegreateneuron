import { app } from './app';

const port:string = "PORT" in process.env? process.env.PORT : "8000";
  
const start = async () => {  
    app.listen(port, () => {
      console.log('Listening on port '+port);
    });
  };
  
  start();