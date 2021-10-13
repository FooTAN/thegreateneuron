
import { AxiosResponse } from 'axios';

const axiosResponse: AxiosResponse = {
  data: `[{"userName":"baruser","roles":"user"},{"userName":"foouser","roles":"user"},{"userName":"admin","roles":"user"},{"userName":"hellouser","roles":"user"}]`,
  status: 200,
  statusText: 'OK',
  config: {},
  headers: {},
};

export default {
  default: {
    get: jest.fn().mockImplementation(() => Promise.resolve(axiosResponse)),
  },
  get: jest.fn(() => Promise.resolve(axiosResponse)),
};