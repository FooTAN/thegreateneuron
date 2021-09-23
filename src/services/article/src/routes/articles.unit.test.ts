import request from 'supertest';
import {app}  from '../app';

it('response with details about the current user', async() =>{
    const response = await request(app)
        .get('/api/article/list')
        .send({
        })
        .expect(200);

        console.log(response.body);
});