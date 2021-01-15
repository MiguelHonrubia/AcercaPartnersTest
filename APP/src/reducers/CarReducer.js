import {
  LIST_CARS,
  SHOW_CAR,
  NEW_CAR,
  EDIT_CAR,
  DELETE_CAR,
} from "../actions/CarActionTypes.js";

export const initialState = {
  cars: [],
  carDetail: {},
};

export const CarReducer = (state = initialState, action) => {
  switch (action.type) {
    case LIST_CARS:
      return {
        ...state,
        cars: action.payload,
      };
    case SHOW_CAR:
      return {
        ...state,
        carDetail: action.payload,
      };
    case EDIT_CAR:
      return {
        ...state,
        cars: state.cars.map((car) =>
          car.id === action.payload ? (car = action.payload) : car
        ),
      };
    case NEW_CAR:
      return {
        ...state,
        cars: [...state.cars, action.payload],
      };
    case DELETE_CAR:
      return {
        ...state,
        cars: state.cars.filter((car) => car.id !== action.payload),
      };
    default:
      return state;
  }
};
