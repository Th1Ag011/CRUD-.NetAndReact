import React, { useEffect, useState } from "react";

function CrudPadrao({ titulo, campos, labels, getTodos, getById, post, put, remove }) {
  const [registros, setRegistros] = useState([]);
  const [filtroId, setFiltroId] = useState("");
  const [selecionado, setSelecionado] = useState(null);
  const [mostrarModal, setMostrarModal] = useState(false);
  const [mostrarConfirmacao, setMostrarConfirmacao] = useState(false);
  const [idParaExcluir, setIdParaExcluir] = useState(null);

  useEffect(() => {
    carregarRegistros();
  }, []);

  const carregarRegistros = async () => {
    try {
      const data = await getTodos();
      setRegistros(data);
    } catch (error) {
      console.error("Erro ao carregar dados:", error);
    }
  };

  const handleBuscar = async () => {
    if (!filtroId) {
      alert("Por favor, insira um ID válido antes de buscar.");
      return;
    }
    try {
      const resultado = await getById(filtroId);
      setRegistros([resultado]);
    } catch (error) {
      alert("Registro não encontrado.");
    }
  };

  const handleAdicionar = () => {
    setSelecionado(null);
    setMostrarModal(true);
  };

  const handleEditar = (registro) => {
    setSelecionado(registro);
    setMostrarModal(true);
  };

  const handleSalvar = async (e) => {
    e.preventDefault();
    const form = e.target;
    const novo = {};
    campos.forEach(campo => {
      if (campo !== "id") {
        novo[campo] = form[campo].value;
      }
    });

    try {
      if (selecionado) {
        await put(selecionado.id, novo);
      } else {
        await post(novo);
      }
      setMostrarModal(false);
      await carregarRegistros();
    } catch (error) {
      console.error("Erro ao salvar:", error);
    }
  };

  const confirmarExclusao = async () => {
    try {
      await remove(idParaExcluir);
      await carregarRegistros();
    } catch (error) {
      console.error("Erro ao excluir:", error);
    } finally {
      setMostrarConfirmacao(false);
      setIdParaExcluir(null);
    }
  };

  const abrirConfirmacao = (id) => {
    setIdParaExcluir(id);
    setMostrarConfirmacao(true);
  };

  return (
    <div className="p-4">
      <div className="flex flex-col sm:flex-row justify-between items-center mb-4 gap-2">
        <h2 className="text-xl font-bold">{titulo}</h2>
        <div className="flex flex-col sm:flex-row items-center gap-2">
          <input
            type="text"
            placeholder="Buscar por ID"
            value={filtroId}
            onChange={e => setFiltroId(e.target.value)}
            className="border border-gray-300 rounded px-3 py-1 text-sm"
          />
          <button
            onClick={handleBuscar}
            className="bg-gray-200 hover:bg-gray-300 text-sm px-3 py-1 rounded"
          >
            Buscar
          </button>
          <button
            onClick={carregarRegistros}
            className="bg-green-600 text-white px-3 py-1 rounded text-sm hover:bg-green-700"
          >
            Buscar Todos
          </button>
          <button
            onClick={handleAdicionar}
            className="bg-blue-600 text-white px-4 py-1.5 rounded text-sm hover:bg-blue-700"
          >
            Adicionar
          </button>
        </div>
      </div>

      {registros.length === 0 ? (
        <p>Nenhum registro encontrado.</p>
      ) : (
        <ul>
          {registros.map(reg => (
            <li key={reg.id} className="border p-3 mb-2 rounded shadow-sm flex flex-col sm:flex-row sm:items-center sm:justify-between gap-2">
              <div className="text-sm">
                <p><strong>ID:</strong> {reg.id}</p>
                {campos.map(campo => (
                  <p key={campo}>
                  <strong>{labels[campo]}:</strong>{" "}
                  {["dataInicio", "dataTermino"].includes(campo)
                    ? new Date(reg[campo]).toLocaleDateString("pt-BR")
                    : reg[campo]}
                </p>         
                ))}
              </div>
              <div className="flex gap-2">
                <button
                  onClick={() => handleEditar(reg)}
                  className="bg-yellow-400 text-black px-3 py-1 rounded hover:bg-yellow-500 text-sm"
                >
                  Editar
                </button>
                <button
                  onClick={() => abrirConfirmacao(reg.id)}
                  className="bg-red-600 text-white px-3 py-1 rounded hover:bg-red-700 text-sm"
                >
                  Excluir
                </button>
              </div>
            </li>
          ))}
        </ul>
      )}

      {mostrarModal && (
        <div className="fixed inset-0 bg-black bg-opacity-40 flex justify-center items-center z-50">
          <form
            onSubmit={handleSalvar}
            className="bg-white rounded-lg shadow p-6 w-full max-w-md space-y-3"
          >
            <h3 className="text-lg font-bold mb-2">
              {selecionado ? `Editar ${titulo}` : `Adicionar ${titulo}`}
            </h3>
            {campos.map(campo => (
              campo === "id" ? null : (
                <input
                  key={campo}
                  type="text"
                  name={campo}
                  placeholder={labels[campo]}
                  defaultValue={selecionado?.[campo] || ""}
                  required
                  readOnly={
                    (campo === "cpf" && !!selecionado) ||
                    (campo === "numeroInscricao" && !!selecionado)
                  }
                  className="w-full border px-3 py-2 rounded text-sm"
                />
              )
            ))}
            <div className="flex justify-end gap-2 mt-4">
              <button
                type="button"
                onClick={() => setMostrarModal(false)}
                className="text-sm px-4 py-1 border rounded"
              >
                Cancelar
              </button>
              <button
                type="submit"
                className="text-sm px-4 py-1 bg-blue-600 text-white rounded hover:bg-blue-700"
              >
                Salvar
              </button>
            </div>
          </form>
        </div>
      )}

      {mostrarConfirmacao && (
        <div className="fixed inset-0 bg-black bg-opacity-40 flex justify-center items-center z-50">
          <div className="bg-white p-6 rounded-lg shadow-lg max-w-sm w-full">
            <h2 className="text-lg font-semibold mb-4">Confirmar exclusão</h2>
            <p className="text-gray-700 mb-6">Tem certeza que deseja excluir este registro?</p>
            <div className="flex justify-end gap-3">
              <button
                onClick={() => setMostrarConfirmacao(false)}
                className="px-4 py-2 text-sm border rounded"
              >
                Cancelar
              </button>
              <button
                onClick={confirmarExclusao}
                className="px-4 py-2 text-sm bg-red-600 text-white rounded hover:bg-red-700"
              >
                Confirmar
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default CrudPadrao;