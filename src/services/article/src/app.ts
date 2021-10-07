import express from 'express';
import 'express-async-errors';
import cookieSession  from 'cookie-session';

import { articlesRouter } from './routes/articles';
import { errorHandler } from './middleware/error-handler';
import { NotFoundError } from './errors/not-found-error';

const app = express();
app.set('trust proxy', true);

app.use(express.json());

app.use(articlesRouter);

app.all('*', async (req,res,next)=>{
    throw new NotFoundError();
});

app.use(errorHandler);

export {app}