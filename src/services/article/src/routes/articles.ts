import express, {Request, Response} from 'express';
import { body } from 'express-validator';


const router = express.Router();

router.get('/api/article/list', async(req,res) =>{
    res.send({article: "article"});
});

export { router as articlesRouter };