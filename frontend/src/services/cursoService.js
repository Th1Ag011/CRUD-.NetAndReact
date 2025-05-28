import api from "./api";

export const getCursos = async () => {
  const response = await api.get('/curso');
  return response.data;
};

export const getCursoById = async (id) => {
  const response = await api.get(`/curso/${id}`);
  return response.data;
};

export const createCurso = async (data) => {
  const response = await api.post('/curso', data);
  return response.data;
};

export const updateCurso = async (id, data) => {
  const response = await api.put(`/curso/${id}`, data);
  return response.data;
};

export const deleteCurso = async (id) => {
  const response = await api.delete(`/curso/${id}`);
  return response.data;
};
