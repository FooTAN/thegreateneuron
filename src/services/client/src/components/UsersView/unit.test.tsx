import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";
import { cleanup} from '@testing-library/react';

import axios from 'axios';
import UsersView from ".";

jest.mock('axios');

afterEach(cleanup);

let container:HTMLElement;

beforeEach(() => {
  // setup a DOM element as a render target
  container = document.createElement("div");
  document.body.appendChild(container);
});

afterEach(() => {
  // cleanup on exiting
  unmountComponentAtNode(container);
  container.remove();
});

it("renders user data", async () => {
  //var an = render(<UsersView />, container);
  //jest.spyOn(axios, 'get').mockImplementation(()=> Promise.resolve([user]));

  // Use the asynchronous version of act to apply resolved promises
  /*await act(async () => {
    render(<UsersView/>, container);
  });*/

  //expect(container.querySelector("summary").textContent).toBe(fakeUser.name);
  //expect(container.querySelector("strong").textContent).toBe(fakeUser.age);
  //expect(container.textContent).toContain(fakeUser.address);
});