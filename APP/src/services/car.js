import axios from "axios";

export const getAllCars = () => {
  return axios.get("https://localhost:44347/api/Cars");
};

export const getCarById = (id) => {
  return axios.get(`https://localhost:44347/api/Cars/${id}`);
};

export const deleteCar = (id) => {
  return axios.delete(`https://localhost:44347/api/Cars/${id}`);
};
export const postCar = (body) => {
  return axios.post("https://localhost:44347/api/Cars", body);
};

export const putCar = (body) => {
  return axios.put("https://localhost:44347/api/Cars", body);
};
