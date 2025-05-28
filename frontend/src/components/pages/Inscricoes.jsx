import React, { useState } from "react";
import CrudPadrao from "../../components/CrudPadrao.jsx";
import {getInscricoes, getInscricaoById, createInscricao, updateInscricao, deleteInscricao, getInscricoesByCpf, getInscricoesByCursoId, getInscricoesWithProcess} from "../../services/inscricaoService.js";

function Inscricoes() {
  const [filtroCpf, setFiltroCpf] = useState("");
  const [filtroCursoId, setFiltroCursoId] = useState("");
  const [resultadosExtras, setResultadosExtras] = useState([]);

  const campos = ["numeroInscricao", "data", "status"];
  const labels = {
    id: "ID",
    numeroInscricao: "Número da Inscrição",
    NomeCandidato: "Nome Candidato",
    data: "Data",
    status: "Status"
  };

  const buscarPorCpf = async () => {
    if (!filtroCpf) return;
    const data = await getInscricoesByCpf(filtroCpf);
    if (data.length === 0){
      alert("Nenhuma inscrição encontrada para o cpf informado.");
    }
    setResultadosExtras(data);
  };

  const buscarPorCurso = async () => {
    if (!filtroCursoId) return;
    try {
        const data = await getInscricoesByCursoId(filtroCursoId);
    
        if (!data || data.length === 0) {
          alert("Nenhuma inscrição encontrada para o curso informado.");
          setResultadosExtras([]);
        } else {
          setResultadosExtras(data);
        }
      } catch (error) {
        console.error("Erro ao buscar inscrições por curso:", error);
        alert("Informe um id valido.");
      }
  };

  const buscarComProcesso = async () => {
    if (!filtroCpf) return;
    const data = await getInscricoesWithProcess(filtroCpf);
    setResultadosExtras(data);
  };

  return (
    <div className="space-y-8">
      <CrudPadrao
        titulo="Inscrições"
        campos={campos}
        labels={labels}
        getTodos={getInscricoes}
        getById={getInscricaoById}
        post={createInscricao}
        put={updateInscricao}
        remove={deleteInscricao}
      />

      <div className="p-4 border rounded-lg shadow">
        <h3 className="text-lg font-semibold mb-2">Consultas Especiais</h3>

        <div className="flex flex-col sm:flex-row items-center gap-2 mb-4">
          <input
            type="text"
            placeholder="Filtrar por CPF"
            value={filtroCpf}
            onChange={(e) => setFiltroCpf(e.target.value)}
            className="border px-3 py-1 rounded text-sm"
          />
          <button
            onClick={buscarPorCpf}
            className="bg-gray-300 px-3 py-1 rounded text-sm hover:bg-gray-400"
          >
            Buscar por CPF
          </button>
          <button
            onClick={buscarComProcesso}
            className="bg-indigo-500 text-white px-3 py-1 rounded text-sm hover:bg-indigo-600"
          >
            Buscar com Processo
          </button>
        </div>

        <div className="flex flex-col sm:flex-row items-center gap-2 mb-4">
          <input
            type="text"
            placeholder="Filtrar por Curso ID"
            value={filtroCursoId}
            onChange={(e) => setFiltroCursoId(e.target.value)}
            className="border px-3 py-1 rounded text-sm"
          />
          <button
            onClick={buscarPorCurso}
            className="bg-gray-300 px-3 py-1 rounded text-sm hover:bg-gray-400"
          >
            Buscar por Curso
          </button>
        </div>

        {resultadosExtras.length > 0 && (
          <div className="overflow-x-auto">
            <table className="min-w-full text-sm text-left">
              <thead>
                <tr>
                  {Object.keys(resultadosExtras[0]).map((key) => (
                    <th key={key} className="border px-2 py-1 bg-gray-100">
                      {key}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {resultadosExtras.map((item, i) => (
                  <tr key={i}>
                    {Object.values(item).map((valor, j) => (
                      <td key={j} className="border px-2 py-1">
                        {String(valor)}
                      </td>
                    ))}
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </div>
  );
}

export default Inscricoes;