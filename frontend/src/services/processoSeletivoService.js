import api from "./api";

export const getProcessosSeletivos = async () => {
  const response = await api.get('/processoseletivo');
  return response.data;
};

export const getProcessoSeletivoById = async (id) => {
  const response = await api.get(`/processoseletivo/${id}`);
  return response.data;
};

export const createProcessoSeletivo = async (data) => {
  const response = await api.post('/processoseletivo', data);
  return response.data;
};

export const updateProcessoSeletivo = async (id, data) => {
  const response = await api.put(`/processoseletivo/${id}`, data);
  return response.data;
};

export const deleteProcessoSeletivo = async (id) => {
  const response = await api.delete(`/processoseletivo/${id}`);
  return response.data;
};
