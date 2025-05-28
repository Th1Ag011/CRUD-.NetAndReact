import api from "./api";

export const getCandidatos = async () => {
  const response = await api.get('/candidato');
  return response.data;
};

export const getCandidatoById = async (id) => {
  const response = await api.get(`/candidato/${id}`);
  return response.data;
};

export const createCandidato = async (data) => {
  const response = await api.post('/candidato', data);
  return response.data;
};

export const updateCandidato = async (id, data) => {
  const response = await api.put(`/candidato/${id}`, data);
  return response.data;
};

export const deleteCandidato = async (id) => {
  const response = await api.delete(`/candidato/${id}`);
  return response.data;
};
