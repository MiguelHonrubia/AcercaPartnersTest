import {
  LIST_CARS,
  SHOW_CAR,
  NEW_CAR,
  EDIT_CAR,
  DELETE_CAR,
} from "./CarActionTypes.js";

import {
  getAllCars,
  getCarById,
  postCar,
  putCar,
  deleteCar,
} from "../services/car";

export const getCarList = () => async (dispatch) => {
  const response = await getAllCars();
  dispatch({
    type: LIST_CARS,
    payload: response.data,
  });
};
export const getCarDetail = (id) => async (dispatch) => {
  const response = await getCarById(id);
  dispatch({
    type: SHOW_CAR,
    payload: response.data,
  });
};

export const removeCar = (id) => async (dispatch) => {
  await deleteCar(id);
  dispatch({
    type: DELETE_CAR,
    payload: id,
  });
};

export const addCar = (car) => async (dispatch) => {
  const response = await postCar(car);
  dispatch({
    type: NEW_CAR,
    payload: response.data,
  });
};

export const editCar = (car) => async (dispatch) => {
  const response = await putCar(car);
  dispatch({
    type: EDIT_CAR,
    payload: response.data,
  });
};
