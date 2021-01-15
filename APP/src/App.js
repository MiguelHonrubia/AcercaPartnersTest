import React from "react";
import { Provider } from "react-redux";
import store from "./store";
import CarList from "./components/CarList";

const App = () => (
  <Provider store={store}>
    <main>
      <CarList />
    </main>
  </Provider>
);

export default App;
