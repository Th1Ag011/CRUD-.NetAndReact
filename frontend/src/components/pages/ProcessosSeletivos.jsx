import React from "react";
import CrudPadrao from "../CrudPadrao.jsx";
import {getProcessosSeletivos, getProcessoSeletivoById, createProcessoSeletivo, updateProcessoSeletivo, deleteProcessoSeletivo} from "../../services/processoSeletivoService";

function ProcessosSeletivos() {
  const campos = ["nome", "dataInicio", "dataTermino"];
  const labels = {
    id: "ID",
    nome: "Nome",
    dataInicio: "Data de Início",
    dataTermino: "Data de Término",
  };

  return (
    <CrudPadrao
      titulo="Processos Seletivos"
      campos={campos}
      labels={labels}
      getTodos={getProcessosSeletivos}
      getById={getProcessoSeletivoById}
      post={createProcessoSeletivo}
      put={updateProcessoSeletivo}
      remove={deleteProcessoSeletivo}
    />
  );
}

export default ProcessosSeletivos;
