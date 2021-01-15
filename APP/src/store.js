import { createStore } from "redux";
import { CarReducer } from "./reducers/CarReducer";
import thunk from "redux-thunk";
import { applyMiddleware } from "redux";

export default createStore(CarReducer, applyMiddleware(thunk));
