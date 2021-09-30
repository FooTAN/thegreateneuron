/*import mongoose from 'mongoose';
import request from 'supertest';
import {app} from '../app';

declare global {
    namespace nodeJs{
        interface Global{
            signin(): Promise<string[]>
        }
    }
}
let mongodb: MongoMemoryServer;
beforeAll(async ()=>{
    process.env.JWT_SECRET_KEY = 'super secret very long key';
    mongodb = await MongoMemoryServer.create();
    const mongodbUri = mongodb.getUri();

    await mongoose.connect(mongodbUri,{
        useNewUrlParser: true,
        useUnifiedTopology: true
    });
});

beforeEach(async ()=>{
    const collections = await mongoose.connection.db.collections();

    for(let collection of collections){
        await collection.deleteMany({});
    }
});

afterAll(async ()=>{
    await mongodb.stop();
    await mongoose.connection.close();

});*/