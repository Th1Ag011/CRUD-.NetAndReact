import api from "./api";

export const getInscricoes = async () => {
  const response = await api.get('/inscricao');
  return response.data;
};

export const getInscricaoById = async (id) => {
  const response = await api.get(`/inscricao/${id}`);
  return response.data;
};

export const createInscricao = async (data) => {
  const response = await api.post('/inscricao', data);
  return response.data;
};

export const updateInscricao = async (id, data) => {
  const response = await api.put(`/inscricao/${id}`, data);
  return response.data;
};

export const deleteInscricao = async (id) => {
  const response = await api.delete(`/inscricao/${id}`);
  return response.data;
};

export const getInscricoesByCpf = async (cpf) => {
  const response = await api.get(`/inscricao/cpf/${cpf}`);
  return response.data;
};

export const getInscricoesByCursoId = async (cursoId) => {
  const response = await api.get(`/inscricao/curso/${cursoId}`);
  return response.data;
};

export const getInscricoesWithProcess = async (cpf) => {
  const response = await api.get(`/inscricao/inscricaoWithProcess/${cpf}`);
  return response.data;
};
